--ALTER SESSION SET CONTAINER= QLDLNOIBO;



GRANT ACCESS_QLNB_DBA TO ADMINQL;
/
BEGIN
 SA_SYSDBA.CREATE_POLICY(
 policy_name => 'ACCESS_QLNB',
 column_name => 'COLL_QLNB'
);
END;
/
--ENABLE POLICY V?A T?O -> KHOI DONG L?I SQLDEV
--EXEC SA_SYSDBA.DROP_POLICY ('ACCESS_QLNB');
EXEC SA_SYSDBA.ENABLE_POLICY ('ACCESS_QLNB');
/
--T?O COMPONENT C?A LABEL
--->T?O LEVEL
EXECUTE SA_COMPONENTS.CREATE_LEVEL('ACCESS_QLNB',100,'L1','SINHVIEN');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('ACCESS_QLNB',200,'L2','NHANVIENCOBAN');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('ACCESS_QLNB',300,'L3','GIAOVU');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('ACCESS_QLNB',400,'L4','GIANGVIEN');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('ACCESS_QLNB',500,'L5','TRUONGDONVI');
EXECUTE SA_COMPONENTS.CREATE_LEVEL('ACCESS_QLNB',800,'L6','TRUONGKHOA'); 
--->T?O COMPARTMENT
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ACCESS_QLNB',50,'H','HTTT');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ACCESS_QLNB',51,'C','CNPM');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ACCESS_QLNB',52,'K','KHMT');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ACCESS_QLNB',53,'CN','CNTT');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ACCESS_QLNB',54,'T','TGMT');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ACCESS_QLNB',55,'M','MMT');
EXECUTE SA_COMPONENTS.CREATE_COMPARTMENT('ACCESS_QLNB',56,'V','VPK');
--->T?O GROUP
EXECUTE SA_COMPONENTS.CREATE_GROUP('ACCESS_QLNB',25,'CS1','CO SO 1');
EXECUTE SA_COMPONENTS.CREATE_GROUP('ACCESS_QLNB',26,'CS2','CO SO 2');
EXECUTE SA_USER_ADMIN.SET_USER_PRIVS('ACCESS_QLNB','ADMINQL','FULL,PROFILE_ACCESS');
---TAO LABEL
/*
SELECT * FROM DBA_SA_LEVELS;
SELECT * FROM DBA_SA_COMPARTMENTS;
SELECT * FROM DBA_SA_GROUPS;
SELECT * FROM DBA_SA_GROUP_HIERARCHY; */
/
BEGIN
 SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
 POLICY_NAME => 'ACCESS_QLNB',
 SCHEMA_NAME => 'ADMINQL',
 TABLE_NAME => 'THONGBAO',
 TABLE_OPTIONS => 'NO_CONTROL'
 );
END; 
/
--- HANG PHAT TAN
--H�y cho biet nh�n cua d�ng th�ng b�o t1 de t1 dc ph�t t�n (doc) boi tat ca Truong
BEGIN sa_label_admin.drop_label('ACCESS_QLNB', 1310);
END;
/
BEGIN
 SA_LABEL_ADMIN.CREATE_LABEL  ('ACCESS_QLNB',1310,'L5', TRUE);
END;
/
--don vi
UPDATE THONGBAO
SET COLL_QLNB = CHAR_TO_LABEL('ACCESS_QLNB','L5')
WHERE MATHONGBAO = 'T1';
---H�y cho biet nh�n cua d�ng th�ng b�o t2 de ph�t t�n t2 den Sinh vi�n thuoc ng�nh
--HTTT hoc ? Co so 1.
/
    BEGIN sa_label_admin.drop_label('ACCESS_QLNB',200);
END;
/
BEGIN
 SA_LABEL_ADMIN.CREATE_LABEL  ('ACCESS_QLNB',200,'L1:H:CS1', TRUE);
END;
/

UPDATE THONGBAO
SET COLL_QLNB = CHAR_TO_LABEL('ACCESS_QLNB','L1:H:CS1')
WHERE MATHONGBAO = 'T2';
--H�y cho bi?t nh�n cua d�ng th�ng b�o t3 de ph�t t�n t3 den Truong bo m�n KHMT o
--Co so 1.
/
BEGIN
sa_label_admin.drop_label('ACCESS_QLNB', 800);
END;
/
BEGIN
 SA_LABEL_ADMIN.CREATE_LABEL  ('ACCESS_QLNB',800,'L5:K:CS1',TRUE);
END;
/
UPDATE THONGBAO
SET COLL_QLNB = CHAR_TO_LABEL('ACCESS_QLNB','L5:K:CS1')
WHERE MATHONGBAO = 'T3';
/
SELECT * FROM THONGBAO;
--Cho biet nh�n cua d�ng th�ng b�o t4 ?? ph�t t�n t4 den Truong bo m�n KHMT ? Co
--so 1 v� Co so 2.
/


BEGIN
sa_label_admin.drop_label
('ACCESS_QLNB', 900);
END;
/
BEGIN
 SA_LABEL_ADMIN.CREATE_LABEL  ( 'ACCESS_QLNB',900,'L5:K:CS1,CS2', TRUE);
END;
/

UPDATE THONGBAO
SET COLL_QLNB = CHAR_TO_LABEL('ACCESS_QLNB','L5:K:CS1,CS2')
WHERE MATHONGBAO = 'T4';
--tbao t5  ph�t t�n toi gi�o vu co so 1

/
    BEGIN
sa_label_admin.drop_label
('ACCESS_QLNB', 600);
END;
/
BEGIN
 SA_LABEL_ADMIN.CREATE_LABEL  ('ACCESS_QLNB',600,'L3:V:CS1,CS2',TRUE);
END;
/

UPDATE THONGBAO
SET COLL_QLNB = CHAR_TO_LABEL('ACCESS_QLNB','L3:V:CS1,CS2')
WHERE MATHONGBAO = 'T5';
--tin nh?n ph�t t�n toi sinh vi�n thuoc co so 2
/
    BEGIN
sa_label_admin.drop_label
('ACCESS_QLNB',480);
END;
/
BEGIN
 SA_LABEL_ADMIN.CREATE_LABEL  ('ACCESS_QLNB',480,'L1::CS2',TRUE);
END;
/

UPDATE THONGBAO
SET COLL_QLNB = CHAR_TO_LABEL('ACCESS_QLNB','L1::CS2')
WHERE MATHONGBAO = 'T6';
--tin nh?n ph�t t�n toi sinh vi�n HTTT co so 1 v� co so 2
/
    BEGIN
sa_label_admin.drop_label
('ACCESS_QLNB',450);
END;
/
BEGIN
 SA_LABEL_ADMIN.CREATE_LABEL  ('ACCESS_QLNB',450,'L1:H:CS1,CS2',TRUE);
END;
/
UPDATE THONGBAO
SET COLL_QLNB = CHAR_TO_LABEL('ACCESS_QLNB','L1:H:CS1,CS2')
WHERE MATHONGBAO = 'T7';
/
SELECT * FROM THONGBAO;
/
BEGIN
SA_POLICY_ADMIN.REMOVE_TABLE_POLICY('ACCESS_QLNB','ADMINQL','THONGBAO');
END;
/
BEGIN
SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
 policy_name => 'ACCESS_QLNB',
 schema_name => 'ADMINQL',
 table_name => 'THONGBAO',
 table_options => 'READ_CONTROL,WRITE_CONTROL,CHECK_CONTROL',
predicate => NULL
);
END;
/


--QUYEN NGUOI DUNG
-- G�N NH�N CHO NGuoI D�NG TRuoNG KHOA co the doc het tat ca cac thongbao
/
BEGIN
    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB','N000','L6:H,C,K,CN,T,M,V:CS1,CS2');
END;
/
GRANT SELECT ON ADMINQL.THONGBAO TO N000;
--H�y g�n nh�n cho c�c Tr??ng b? m�n ph? tr�ch C? s? 2 c� th? ??c ???c to�n b? th�ng b�o. d�nh cho tr??ng b? m�n kh�ng ph�n bi?t v? tr� ??a l�.
CREATE OR REPLACE PROCEDURE USP_LABEL_TDV
AS
 CURSOR CUR IS (SELECT MANV,COSO,MADV
 FROM NHANSU
 WHERE MANV IN (SELECT USERNAME
 FROM ALL_USERS) AND VAITRO='TRUONGDV');
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
 DONVI1 NVARCHAR2(20);
 COSO1 VARCHAR(20);
 LABEL VARCHAR(20);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR,COSO1,DONVI1;
 EXIT WHEN CUR%NOTFOUND;
    IF(COSO1='CO SO 1') THEN
                IF (DONVI1='HTTT') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L5:H:CS1');
                        EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='CNPM') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L5:C:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='KHMT') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L5:K:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='CNTT') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L5:CN:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='TGMT') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L5:T:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='MMT') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L5:M:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='VT') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L5:V:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                END IF;
    ELSIF (COSO1='CO SO 2') THEN
                    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L5:H,C,K,CN,T,M:CS1,CS2'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
            END IF;
        
 END LOOP;
 CLOSE CUR;
END;
/
EXEC USP_LABEL_TDV;

/
--H�y g�n nh�n cho 01 Gi�o v? c� th? ??c to�n b? th�ng b�o d�nh cho gi�o v?
BEGIN
    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB','N009','L3:V:CS1,CS2');
END;
/
GRANT SELECT ON THONGBAO TO N009;
/
--  PHAN OLS CHO GIAO VU
CREATE OR REPLACE PROCEDURE USP_LABEL_GV
AS
 CURSOR CUR IS (SELECT MANV,COSO,MADV
 FROM NHANSU
 WHERE MANV IN (SELECT USERNAME
 FROM ALL_USERS) AND VAITRO='GIAOVU' AND MANV!='N009');
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
 DONVI1 NVARCHAR2(20);
 COSO1 VARCHAR(20);
 LABEL VARCHAR(20);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR,COSO1,DONVI1;
 EXIT WHEN CUR%NOTFOUND;
    IF(COSO1='CO SO 1') THEN      
        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L3:V:CS1');EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
    ELSIF (COSO1='CO SO 2') THEN
        STRSQL := 'L3:V:CS2';
        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L3:V:CS2');EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
    END IF;
        
 END LOOP;
 CLOSE CUR;
END;
/
EXEC USP_LABEL_GV;
/
--PHAN QUYEN SV
CREATE OR REPLACE PROCEDURE USP_LABEL_SV
AS
 CURSOR CUR IS (SELECT MASV,MANGANH,COSO
 FROM SINHVIEN
 WHERE MASV IN (SELECT USERNAME
 FROM ALL_USERS));
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
 DONVI1 NVARCHAR2(20);
 COSO1 VARCHAR(20);
 LABEL VARCHAR(20);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR,DONVI1,COSO1;
 EXIT WHEN CUR%NOTFOUND;
    IF(COSO1='CO SO 1') THEN
                IF (DONVI1='HTTT') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:H:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='CNPM') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:C:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='KHMT') THEN
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:K:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='CNTT') THEN
                        
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:CN:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='TGMT') THEN
                        
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:T:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='MMT') THEN
                        
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:M:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                        ELSIF(DONVI1 ='VT') THEN
                        
                        SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:V:CS1'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                END IF;
    ELSIF (COSO1='CO SO 2') THEN
            IF (DONVI1='HTTT') THEN
                    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:H:CS2'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                    ELSIF(DONVI1 ='CNPM') THEN
                    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:C:CS2'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                    ELSIF(DONVI1 ='KHMT') THEN
                    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:K:CS2'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                    ELSIF(DONVI1 ='CNTT') THEN
                    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:CN:CS2'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                    ELSIF(DONVI1 ='TGMT') THEN
                    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:T:CS2'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                    ELSIF(DONVI1 ='MMT') THEN
                    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:M:CS2'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                    ELSIF(DONVI1 ='VT') THEN
                    SA_USER_ADMIN.SET_USER_LABELS('ACCESS_QLNB',USR,'L1:V:CS2'); EXECUTE IMMEDIATE ('GRANT SELECT ON THONGBAO TO '||USR);
                    END IF;
            END IF;
      
 END LOOP;
 CLOSE CUR;
END;
/
EXEC USP_LABEL_SV;
/*
BEGIN
SA_POLICY_ADMIN.REMOVE_TABLE_POLICY('ACCESS_QLNB','ADMINQL','THONGBAO');
END;
/
BEGIN
SA_POLICY_ADMIN.APPLY_TABLE_POLICY (
 policy_name => 'ACCESS_QLNB',
 schema_name => 'ADMINQL',
 table_name => 'THONGBAO',
 table_options => 'LABEL_DEFAULT,READ_CONTROL',
predicate => NULL
);
END;
/

EXEC USP_LABEL_SV;
SELECT * FROM ALL_SA_LABELS;
SELECT * FROM DBA_SA_USERS;
SELECT * FROM THONGBAO;*/