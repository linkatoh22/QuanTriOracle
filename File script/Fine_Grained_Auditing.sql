--FGA
--MO PHONG LAI QUA TRINH SINH VIEN CAP NHAT DIEM CUA MINH 

CREATE OR REPLACE FUNCTION AUDITIF_DK
RETURN NUMBER 
AS
BEGIN
IF ADMINQL.FUNC_VAITRO(SYS_CONTEXT('USERENV', 'SESSION_USER')) != 'GIANGVIEN' OR
    ADMINQL.FUNC_VAITRO(SYS_CONTEXT('USERENV', 'SESSION_USER')) != 'TRUONGDV' OR
    ADMINQL.FUNC_VAITRO(SYS_CONTEXT('USERENV', 'SESSION_USER')) != 'TRUONGKHOA'
    THEN RETURN 1;
    ELSE RETURN 0;
END IF;
END;
/

BEGIN 
    DBMS_FGA.DROP_POLICY(
        object_schema     => 'ADMINQL',
        object_name       => 'DANGKY',
        policy_name       => 'POLICY_DANGKY_SCORE_UPDATE'
    );
END;
/
BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema     => 'ADMINQL',
        object_name       => 'DANGKY',
        policy_name       => 'POLICY_DANGKY_SCORE_UPDATE',
        audit_column      => 'DIEMTHI, DIEMQT, DIEMCK, DIEMTK',
        enable            => TRUE,
        statement_types   => 'UPDATE',
        audit_condition   => 'AUDITIF_DK = 1',
        audit_trail       => DBMS_FGA.DB + DBMS_FGA.EXTENDED, 
        audit_column_opts => DBMS_FGA.ANY_COLUMNS
    );
END;
/

--MO PHONG HANH VI NGUOI DUNG NAY DOC DUOC PHU CAP CUA NGUOI DUNG KHAC
alter session set current_schema =  SYS;
BEGIN 
    DBMS_FGA.DROP_POLICY(
        object_schema     => 'ADMINQL',
        object_name       => 'NHANSU',
        policy_name       => 'POLICY_CHK_PHUCAP_NS'
    );
END;
/
BEGIN
    DBMS_FGA.ADD_POLICY(
        object_schema     => 'ADMINQL',
        object_name       => 'NHANSU',
        policy_name       => 'POLICY_CHK_PHUCAP_NS',
        audit_column      => 'PHUCAP',
        enable            => TRUE,
        statement_types   => 'SELECT',
        audit_condition   => 'MANV != SYS_CONTEXT(''USERENV'', ''SESSION_USER'')',
        audit_trail       => DBMS_FGA.DB + DBMS_FGA.EXTENDED,
        audit_column_opts => DBMS_FGA.ANY_COLUMNS
    );
END;
--DANG NHAP VOI ACCOUNT S001 VA CHAY LENH SAU 
UPDATE ADMINQL.DANGKY
    SET DIEMTHI = 10
    WHERE MASV = 'S001';
--THUC HIEN KIEM TRA BANG LENH SAU 
SELECT * FROM SYS.FGA_LOG$;
--DANG NHAP VOI ACCOUNT BAT KY VA CHON LENH NAY
select PHUCAP from adminql.nhansu where manv = 'N005';
--KIEM TRA BANG LENH SAU 
SELECT DBUID, LSQLTEXT, NTIMESTAMP# FROM SYS.FGA_LOG$;