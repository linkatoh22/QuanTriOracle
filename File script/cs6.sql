
--SINHVIEN
--Tr�n quan h? SINHVIEN, sinh vi�n ch? ???c xem th�ng tin c?a ch�nh m�nh, ???c
--Ch?nh s?a th�ng tin ??a ch? (?CHI) v� s? ?i?n tho?i li�n l?c (?T) c?a ch�nh sinh vi�n.
/
CREATE OR REPLACE FUNCTION VPD_SV_SINHVIEN(P_SCHEMA VARCHAR2,P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
    
    STR VARCHAR2(1000);
    USR VARCHAR(100);
BEGIN
    IF(UPPER(FUNC_VAITRO(USER))='SINHVIEN') THEN
        STR:='MASV = ''' || SYS_CONTEXT('USERENV','SESSION_USER') || '''';
        RETURN STR;
    END IF;
    RETURN '1=1';
END;
/
BEGIN
DBMS_RLS.DROP_POLICY(
 OBJECT_SCHEMA => 'ADMINQL',
 OBJECT_NAME =>'SINHVIEN',
 POLICY_NAME => 'POL_VPD_SV_SINHVIEN');
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'SINHVIEN',   
        policy_name     => 'POL_VPD_SV_SINHVIEN',
        policy_function => 'VPD_SV_SINHVIEN',
        STATEMENT_TYPES=>'SELECT,UPDATE'
    );
END;
/

CREATE OR REPLACE PROCEDURE PROC_UPDATESINHVIEN(DCHI IN VARCHAR2, DT IN VARCHAR2)
AS
BEGIN
    UPDATE VIEW_SV_SINHVIEN 
    SET DIACHI=DCHI,
    DIENTHOAI=DT 
    WHERE MASV=SYS_CONTEXT('USERENV','SESSION_USER');
END;



--Xem danh s�ch t?t c? h?c ph?n (HOCPHAN), k? ho?ch m? m�n (KHMO) c?a ch??ng
--tr�nh ?�o t?o m� sinh vi�n ?ang theo h?c.

/
CREATE OR REPLACE FUNCTION VPD_SV_HOCPHAN(
    P_SCHEMA IN VARCHAR2,
    P_OBJECT IN VARCHAR2)
    RETURN VARCHAR2
AS
    STRSQL VARCHAR2(2000); 
    MA VARCHAR(20);
    CURSOR CUR IS (SELECT MAHP
 FROM KHMO
 WHERE MACT =(SELECT MACT FROM SINHVIEN WHERE MASV= SYS_CONTEXT('USERENV','SESSION_USER'))); 
BEGIN
    IF(UPPER(FUNC_VAITRO(USER))='SINHVIEN') THEN
    OPEN CUR;
     LOOP
     FETCH CUR INTO MA;
     EXIT WHEN CUR%NOTFOUND;
     IF (STRSQL IS NOT NULL) THEN
        STRSQL := STRSQL ||''',''';
     END IF;
        STRSQL := STRSQL || MA;
     END LOOP;
        RETURN 'MAHP IN ('''||STRSQL||''')'; 
    END IF;
    RETURN '1=1';
END;
/
CREATE OR REPLACE FUNCTION VPD_SV_HOCPHAN_KHMO(
    P_SCHEMA IN VARCHAR2,
    P_OBJECT IN VARCHAR2)
    RETURN VARCHAR2
AS
    is_dba varchar(5);
    PREDICATED_VAR VARCHAR2(4000);
    STRQL VARCHAR(2000);
    MACT VARCHAR(20);
BEGIN
    IF(UPPER(FUNC_VAITRO(USER))='SINHVIEN') THEN
    STRQL:='SELECT MACT FROM SINHVIEN WHERE MASV=''' || SYS_CONTEXT('USERENV','SESSION_USER') || '''';
    EXECUTE IMMEDIATE(STRQL) INTO MACT;
    
    PREDICATED_VAR:='MACT = ''' || MACT || '''';
    RETURN PREDICATED_VAR;
    END IF;
    RETURN '1=1';
END;
/
BEGIN
DBMS_RLS.DROP_POLICY(
 OBJECT_SCHEMA => 'ADMINQL',
 OBJECT_NAME =>'HOCPHAN',
 POLICY_NAME => 'POL_VPD_SV_HOCPHAN');
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'HOCPHAN',   
        policy_name     => 'POL_VPD_SV_HOCPHAN',
        policy_function => 'VPD_SV_HOCPHAN',
        STATEMENT_TYPES=>'SELECT'
    );
END;
/

BEGIN
DBMS_RLS.DROP_POLICY(
 OBJECT_SCHEMA => 'ADMINQL',
 OBJECT_NAME =>'KHMO',
 POLICY_NAME => 'POL_VPD_SV_KHMO');
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'KHMO',   
        policy_name     => 'POL_VPD_SV_KHMO',
        policy_function => 'VPD_SV_HOCPHAN_KHMO',
        STATEMENT_TYPES=>'SELECT'
    );
END;
/

--Th�m, X�a c�c d�ng d? li?u ??ng k� h?c ph?n (?ANGKY) li�n quan ??n ch�nh sinh
--vi�n ?� trong h?c k? c?a n?m h?c hi?n t?i (n?u th?i ?i?m hi?u ch?nh ??ng k� c�n h?p
--l?).
CREATE OR REPLACE FUNCTION FUNC_DAY
RETURN VARCHAR2
AS
    CURSOR CUR IS 
    (
        SELECT EXTRACT(day FROM SYSDATE)  FROM dual
    );
    VAITRO1 VARCHAR2(20);
    STR VARCHAR2(1000);
    USR VARCHAR(100);
BEGIN
    OPEN CUR;
    --STR := 'alter session set "_ORACLE_SCRIPT"=true';
    LOOP
        FETCH CUR INTO USR;
        EXIT WHEN CUR%NOTFOUND;
        STR:=USR;
    END LOOP;
    RETURN STR;
END;
/
CREATE OR REPLACE FUNCTION FUNC_MONTH
RETURN VARCHAR2
AS
    CURSOR CUR IS 
    (
        SELECT EXTRACT(MONTH FROM SYSDATE) FROM dual
    );
    VAITRO1 VARCHAR2(20);
    STR VARCHAR2(1000);
    USR VARCHAR(100);
BEGIN
    OPEN CUR;
    --STR := 'alter session set "_ORACLE_SCRIPT"=true';
    LOOP
        FETCH CUR INTO USR;
        EXIT WHEN CUR%NOTFOUND;
        STR:=USR;
    END LOOP;
    RETURN STR;
END;
/
CREATE OR REPLACE FUNCTION FUNC_YEAR
RETURN VARCHAR2
AS
    CURSOR CUR IS 
    (
        SELECT EXTRACT(year FROM SYSDATE)  FROM dual
    );
    VAITRO1 VARCHAR2(20);
    STR VARCHAR2(1000);
    USR VARCHAR(100);
BEGIN
    OPEN CUR;
    --STR := 'alter session set "_ORACLE_SCRIPT"=true';
    LOOP
        FETCH CUR INTO USR;
        EXIT WHEN CUR%NOTFOUND;
        STR:=USR;
    END LOOP;
    RETURN STR;
END;
/
--POLICY DELETE
CREATE OR REPLACE FUNCTION VPD_SV_DANGKY_EDIT (
    P_SCHEMA    IN VARCHAR2,
    P_OBJECT     IN VARCHAR2)
RETURN VARCHAR2
AS
    YEAR1 VARCHAR2(4);
BEGIN
    IF(UPPER(FUNC_VAITRO(USER))='SINHVIEN') THEN
        YEAR1:=FUNC_YEAR();
            IF FUNC_DAY() < '15' THEN
                    IF FUNC_MONTH() = '1' THEN
                        RETURN 'HK=1 AND MASV = ''' || SYS_CONTEXT('USERENV','SESSION_USER') || ''' AND NAM= '||YEAR1;
                    ELSIF FUNC_MONTH() = '5' THEN
                        RETURN 'HK=2 AND MASV = ''' || SYS_CONTEXT('USERENV','SESSION_USER') || ''' AND NAM= '||YEAR1;
                    ELSIF FUNC_MONTH() = '9' THEN
                        RETURN 'HK=3 AND MASV = ''' || SYS_CONTEXT('USERENV','SESSION_USER') || ''' AND NAM= '||YEAR1;
                        END IF;
            END IF;
        RETURN '1=0' ;
    END IF;
        RETURN '1=1';
END;
BEGIN
DBMS_RLS.DROP_POLICY(
 OBJECT_SCHEMA => 'ADMINQL',
 OBJECT_NAME =>'DANGKY',
 POLICY_NAME => 'POL_VPD_SV_DANGKY_EDIT');
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'DANGKY',   
        policy_name     => 'POL_VPD_SV_DANGKY_EDIT',
        policy_function => 'VPD_SV_DANGKY_EDIT',
        STATEMENT_TYPES=>'DELETE,INSERT',
        UPDATE_CHECK => TRUE
    );
END;
/
--Sinh vi�n ???c Xem t?t c? th�ng tin tr�n quan h? ?ANGKY t?i c�c d�ng d? li?u li�n
--quan ??n ch�nh sinh vi�n.
CREATE OR REPLACE FUNCTION VPD_SV_DANGKY(
    P_SCHEMA IN VARCHAR2,
    P_OBJECT IN VARCHAR2)
    RETURN VARCHAR2
AS
    is_dba varchar(5);
    PREDICATED_VAR VARCHAR2(4000);
BEGIN
IF(UPPER(FUNC_VAITRO(USER))='SINHVIEN') THEN
    PREDICATED_VAR:='MASV = ''' || SYS_CONTEXT('USERENV','SESSION_USER') || '''';
    RETURN PREDICATED_VAR;
    END IF;
    RETURN '1=1';
END;
/
BEGIN
DBMS_RLS.DROP_POLICY(
 OBJECT_SCHEMA => 'ADMINQL',
 OBJECT_NAME =>'DANGKY',
 POLICY_NAME => 'POL_VPD_SV_DANGKY_SEL');
END;
/
BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'DANGKY',   
        policy_name     => 'POL_VPD_SV_DANGKY_SEL',
        policy_function => 'VPD_SV_DANGKY',
        STATEMENT_TYPES=>'SELECT'
    );
END;
/
CREATE OR REPLACE PROCEDURE PROC_IN_DANGKY_SV(MAHOCPHAN IN VARCHAR2, HOCKY IN INT, NAM1 IN NUMBER)
AS
    MACT1 VARCHAR2(4);
BEGIN
    SELECT MACT INTO MACT1 FROM SINHVIEN WHERE MASV=SYS_CONTEXT('USERENV','SESSION_USER');
    INSERT INTO DANGKY(MASV,MAGV,MAHP,HK,NAM,MACT) VALUES(SYS_CONTEXT('USERENV','SESSION_USER'),'CPC',MAHOCPHAN,
    HOCKY,NAM1,MACT1);
END;
/
CREATE OR REPLACE PROCEDURE PROC_DEL_DANGKY (MAHOCPHAN IN VARCHAR2, HOCKY IN INT, NAM1 IN NUMBER)
AS
BEGIN
    DELETE FROM DANGKY WHERE MAHOCPHAN = MAHOCPHAN AND HOCKY = HOCKY AND NAM1 = NAM1;
END;
/
GRANT EXECUTE ON PROC_IN_DANGKY_SV TO SINHVIEN;
GRANT EXECUTE ON PROC_DEL_DANGKY TO SINHVIEN;
GRANT EXECUTE ON PROC_UPDATESINHVIEN TO SINHVIEN;
GRANT SELECT,UPDATE(DIACHI,DIENTHOAI) ON SINHVIEN TO SINHVIEN;
GRANT SINHVIEN TO N006;
GRANT SELECT ON DANGKY TO SINHVIEN;
GRANT INSERT(MASV, MAGV, MAHP, HK, NAM, MACT) ON DANGKY TO SINHVIEN;
GRANT DELETE ON DANGKY TO SINHVIEN;
GRANT SELECT ON KHMO TO SINHVIEN;
GRANT SELECT ON HOCPHAN TO SINHVIEN;
GRANT SINHVIEN TO N006;