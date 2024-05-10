
--SINHVIEN
--Tr�n quan h? SINHVIEN, sinh vi�n ch? ???c xem th�ng tin c?a ch�nh m�nh, ???c
--Ch?nh s?a th�ng tin ??a ch? (?CHI) v� s? ?i?n tho?i li�n l?c (?T) c?a ch�nh sinh vi�n.

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
--POLICY DELETE
--Sinh vi�n ???c Xem t?t c? th�ng tin tr�n quan h? ?ANGKY t?i c�c d�ng d? li?u li�n
--quan ??n ch�nh sinh vi�n.

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