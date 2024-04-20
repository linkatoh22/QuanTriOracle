alter session set current_schema =  ADMINQL;
--CS#3
--1
GRANT NHANVIENCOBAN TO GIAOVU;
--2
GRANT INSERT, UPDATE, SELECT ON SINHVIEN TO GIAOVU;
CREATE OR REPLACE PROCEDURE PROC_THEMSINHVIEN (
    p_MSSV IN VARCHAR2,
    p_HOTEN IN VARCHAR2,
    p_PHAI IN VARCHAR2,
    p_NGSINH IN VARCHAR2,
    p_DIACHI IN VARCHAR2,
    p_DIENTHOAI IN VARCHAR2,
    p_MACT IN VARCHAR2,
    p_MANGANH IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem MSSV ?� t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM SinhVien
    WHERE MASV = p_MSSV;

    -- N?u MSSV ?� t?n t?i, th�ng b�o l?i
    IF v_Count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'MSSV ?� t?n t?i');
    END IF;

    -- N?u MSSV ch?a t?n t?i, th�m sinh vi�n v�o b?ng SinhVien
    INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH) VALUES 
    (p_MSSV, p_HOTEN, p_PHAI, TO_DATE(p_NGSINH, 'YYYY-MM-DD'), p_DIACHI, p_DIENTHOAI, p_MACT, p_MANGANH);
    
    COMMIT;
END;
/
GRANT EXECUTE ON PROC_THEMSINHVIEN TO GIAOVU;
CREATE OR REPLACE PROCEDURE PROC_UPDATE_STUDENT (
    p_MSSV IN VARCHAR2,
    p_TEN IN VARCHAR2,
    p_NGSINH IN DATE,
    p_DIACHI IN VARCHAR2,
    p_DIENTHOAI IN VARCHAR2,
    p_PHAI IN VARCHAR2,
    p_MACT IN VARCHAR2,
    p_MANGANH IN VARCHAR2,
    p_SOTCTL IN NUMBER,
    p_DTBTL IN NUMBER
)
IS
BEGIN
    -- C?p nh?t th�ng tin sinh vi�n
    UPDATE SINHVIEN
    SET HOTEN = p_TEN,
        NGSINH = p_NGSINH,
        DIACHI = p_DIACHI,
        DIENTHOAI = p_DIENTHOAI,
        PHAI = p_PHAI,
        MACT = p_MACT,
        MANGANH = p_MANGANH,
        SOTCTL = p_SOTCTL,
        DTBTL = p_DTBTL
    WHERE MASV = p_MSSV;

    -- Ki?m tra xem c� b?n ghi n�o ???c c?p nh?t kh�ng
    IF SQL%ROWCOUNT = 0 THEN
        DBMS_OUTPUT.PUT_LINE('Kh�ng t�m th?y sinh vi�n c� MSSV l� ' || p_MSSV);
    ELSE
        DBMS_OUTPUT.PUT_LINE('C?p nh?t th�ng tin sinh vi�n th�nh c�ng.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('L?i khi c?p nh?t th�ng tin sinh vi�n: ' || SQLERRM);
END;
/
GRANT EXECUTE ON PROC_UPDATE_STUDENT TO GIAOVU;


GRANT INSERT, UPDATE, SELECT ON DONVI TO GIAOVU;
--THEM DON VI
CREATE OR REPLACE PROCEDURE PROC_THEMDONVI (
    p_MADV IN VARCHAR2,
    p_TENDV IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem MSSV ?� t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM DONVI
    WHERE MADV = p_MADV;

    -- N?u MSSV ?� t?n t?i, th�ng b�o l?i
    IF v_Count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'MADV ?� t?n t?i');
    END IF;

    -- N?u MSSV ch?a t?n t?i, th�m sinh vi�n v�o b?ng SinhVien
    INSERT INTO DONVI (MADV, TENDV) VALUES 
    (p_MADV, p_TENDV);
    
    COMMIT;
END;
/
GRANT EXECUTE ON PROC_THEMDONVI TO GIAOVU;
--UPDATE DONVI
CREATE OR REPLACE PROCEDURE PROC_UPDATEDONVI (
    p_MADV IN VARCHAR2,
    p_TENDV IN VARCHAR2
)
IS
    v_Count NUMBER;
    v_TRGDV_COUNT NUMBER;
BEGIN
    -- Ki?m tra xem MADV ?� t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM DONVI
    WHERE MADV = p_MADV;

    -- N?u MADV kh�ng t?n t?i, th�ng b�o l?i
    IF v_Count = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'MADV kh�ng t?n t?i');
    END IF;
    -- C?p nh?t th�ng tin c?a ??n v?
    UPDATE DONVI
    SET TENDV = p_TENDV
    WHERE MADV = p_MADV;
    
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

GRANT EXECUTE ON PROC_UPDATEDONVI TO GIAOVU;
GRANT INSERT, UPDATE, SELECT ON HOCPHAN TO GIAOVU;
--insert HP
CREATE OR REPLACE PROCEDURE PROC_INSERTHOCPHAN (
    p_MAHP IN VARCHAR2,
    p_TENHP IN NVARCHAR2,
    p_SOTC IN INT,
    p_STLT IN INT,
    p_STTH IN INT,
    p_SOSVTD IN INT,
    p_MADV IN VARCHAR2
)
IS
    v_Count INT;
BEGIN
    -- Ki?m tra xem MAHP ?� t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM HOCPHAN
    WHERE MAHP = p_MAHP;

    IF v_Count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'MAHP ?� t?n t?i');
    END IF;

    -- Th�m h?c ph?n m?i v�o b?ng HOCPHAN
    INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES 
    (p_MAHP, p_TENHP, p_SOTC, p_STLT, p_STTH, p_SOSVTD, p_MADV);
    
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/

GRANT EXECUTE ON PROC_INSERTHOCPHAN TO GIAOVU;

--update hocphan
CREATE OR REPLACE PROCEDURE PROC_UPDATEHOCPHAN (
    p_MAHP IN VARCHAR2,
    p_TENHP IN NVARCHAR2,
    p_SOTC IN INT,
    p_STLT IN INT,
    p_STTH IN INT,
    p_SOSVTD IN INT,
    p_MADV IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem MAHP ?� t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM HOCPHAN
    WHERE MAHP = p_MAHP;

    -- N?u MAHP kh�ng t?n t?i, th�ng b�o l?i
    IF v_Count = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'M� h?c ph?n kh�ng t?n t?i');
    END IF;

    -- C?p nh?t th�ng tin h?c ph?n
    UPDATE HOCPHAN
    SET TENHP = p_TENHP,
        SOTC = p_SOTC,
        STLT = p_STLT,
        STTH = p_STTH,
        SOSVTD = p_SOSVTD,
        MADV = p_MADV
    WHERE MAHP = p_MAHP;
    
    COMMIT;
END;
/
GRANT EXECUTE ON PROC_UPDATEHOCPHAN TO GIAOVU;

GRANT INSERT, UPDATE, SELECT ON KHMO TO GIAOVU;
--insert khmo
CREATE OR REPLACE PROCEDURE PROC_INSERT_KHMO (
    p_MAHP IN VARCHAR2,
    p_HK IN INT,
    p_NAM IN NUMBER,
    p_MACT IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem MAHP ?� t?n t?i trong b?ng KHMO ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM KHMO
    WHERE MAHP = p_MAHP AND HK = p_HK AND NAM = p_NAM AND MACT = p_MACT;

    -- N?u ch?a t?n t?i, th�m m?i
    IF v_Count = 0 THEN
        INSERT INTO KHMO (MAHP, HK, NAM, MACT) VALUES (p_MAHP, p_HK, p_NAM, p_MACT);
        COMMIT;
    ELSE
        -- N?u ?� t?n t?i, th�ng b�o l?i
        raise_application_error(-20001, 'M� h?c ph?n n�y ?� t?n t?i trong k? h?c v� n?m h?c n�y.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        -- X? l� l?i
        ROLLBACK;
        RAISE;
END PROC_INSERT_KHMO;
/

GRANT EXECUTE ON PROC_INSERT_KHMO TO GIAOVU;
--update KHMO
CREATE OR REPLACE PROCEDURE PROC_UPDATE_KHMO (
    p_MAHP_old IN VARCHAR2,
    p_HK_old IN INT,
    p_NAM_old IN NUMBER,
    p_MACT_old IN VARCHAR2,
    p_MAHP_new IN VARCHAR2,
    p_HK_new IN INT,
    p_NAM_new IN NUMBER,
    p_MACT_new IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem gi� tr? c? t?n t?i trong b?ng KHMO hay kh�ng
    SELECT COUNT(*)
    INTO v_Count
    FROM KHMO
    WHERE MAHP = p_MAHP_old AND HK = p_HK_old AND NAM = p_NAM_old AND MACT = p_MACT_old;

    -- N?u gi� tr? c? t?n t?i, ti?n h�nh c?p nh?t
    IF v_Count > 0 THEN
        -- C?p nh?t th�ng tin m?i
        UPDATE KHMO
        SET MAHP = p_MAHP_new,
            HK = p_HK_new,
            NAM = p_NAM_new,
            MACT = p_MACT_new
        WHERE MAHP = p_MAHP_old AND HK = p_HK_old AND NAM = p_NAM_old AND MACT = p_MACT_old;
        
        COMMIT;
    ELSE
        -- N?u kh�ng t?n t?i, th�ng b�o l?i
        raise_application_error(-20002, 'Kh�ng t�m th?y m� h?c ph?n c? trong k? h?c v� n?m h?c n�y.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        -- X? l� l?i
        ROLLBACK;
        RAISE;
END PROC_UPDATE_KHMO;
GRANT EXECUTE ON PROC_UPDATE_KHMO TO GIAOVU;

--3
GRANT SELECT ON PHANCONG TO GIAOVU;
--UPDATE ON PHANCONG
CREATE OR REPLACE FUNCTION VPD_GIAOVU_PHANCONG(P_SCHEMA VARCHAR2,P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
    STR VARCHAR2(1000);
    USR VARCHAR(100);
BEGIN
    IF(UPPER(FUNC_VAITRO(USER))='GIAOVU') THEN
        STR:='MAGV IN (SELECT MANV FROM NHANSU WHERE MADV = ''DVVPK'')';
    END IF;
    RETURN STR;
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'PHANCONG',   
        policy_name     => 'POL_GIAOVU_PHANCONG',
        policy_function => 'VPD_GIAOVU_PHANCONG',
        STATEMENT_TYPES => 'UPDATE'
    );
END;
/
CREATE OR REPLACE PROCEDURE PROC_UPDATE_PHANCONG (
    p_MAGV_old IN VARCHAR2,
    p_MAHP_old IN VARCHAR2,
    p_HK_old IN INT,
    p_NAM_old IN NUMBER,
    p_MACT_old IN VARCHAR2,
    p_MAGV_new IN VARCHAR2,
    p_MAHP_new IN VARCHAR2,
    p_HK_new IN INT,
    p_NAM_new IN NUMBER,
    p_MACT_new IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem d�ng c? t?n t?i trong b?ng PHANCONG kh�ng
    SELECT COUNT(*)
    INTO v_Count
    FROM PHANCONG
    WHERE MAGV = p_MAGV_old
      AND MAHP = p_MAHP_old
      AND HK = p_HK_old
      AND NAM = p_NAM_old
      AND MACT = p_MACT_old;

    -- N?u t?n t?i d�ng c?, th� c?p nh?t
    IF v_Count > 0 THEN
        UPDATE PHANCONG
        SET MAGV = p_MAGV_new,
            MAHP = p_MAHP_new,
            HK = p_HK_new,
            NAM = p_NAM_new,
            MACT = p_MACT_new
        WHERE MAGV = p_MAGV_old
          AND MAHP = p_MAHP_old
          AND HK = p_HK_old
          AND NAM = p_NAM_old
          AND MACT = p_MACT_old;

        COMMIT;
    ELSE
        -- N?u kh�ng t�m th?y d�ng c?, b�o l?i
        RAISE_APPLICATION_ERROR(-20002, 'Kh�ng t�m th?y d�ng d? li?u c?.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        -- X? l� ngo?i l?
        ROLLBACK;
        RAISE;
END PROC_UPDATE_PHANCONG;
/
GRANT EXECUTE ON PROC_UPDATE_PHANCONG TO GIAOVU;
GRANT UPDATE ON PHANCONG TO GIAOVU;
--DANGKY GIAOVU
CREATE OR REPLACE FUNCTION VPD_GIAOVU_DANGKY(P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
    STR VARCHAR2(1000);
    NAM_KHADUNG NUMBER;
    TIMESPACE NUMBER;
BEGIN
    -- L?Y N?M HI?N T?I
    SELECT EXTRACT(YEAR FROM SYSDATE) INTO NAM_KHADUNG FROM DUAL;
    -- T�NH TO�N KHO?NG TH?I GIAN T�NH T? NG�Y 1/5 C?A N?M HI?N T?I ??N NG�Y HI?N T?I
    SELECT TO_DATE('01-09-' || EXTRACT(YEAR FROM SYSDATE), 'DD-MM-YYYY') - SYSDATE INTO TIMESPACE FROM dual;
    --SELECT TO_DATE('01-09-' || EXTRACT(YEAR FROM SYSDATE), 'DD-MM-YYYY') - TO_DATE('15-04-' || EXTRACT(YEAR FROM SYSDATE), 'DD-MM-YYYY') FROM dual
    -- KH?I T?O GI� TR? M?C ??NH CHO STR
    STR := '';

    IF (UPPER(FUNC_VAITRO(USER)) = 'GIAOVU') THEN
        IF (TIMESPACE >= 14) THEN
            -- N?U TH?I GIAN C�N TRONG KHO?NG 14 NG�Y TR??C NG�Y 1/5
            STR := 'HK = 3 AND NAM >= ' || NAM_KHADUNG;
        ELSIF (TIMESPACE >= 138) THEN
            -- N?U TH?I GIAN ?� V??T QU� NG�Y 1/5
            STR := 'HK >= 2 AND NAM >= ' || NAM_KHADUNG;
        END IF;
    END IF;

    RETURN STR;
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'DANGKY',   
        policy_name     => 'POL_GIAOVU_DANGKY'
    );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'DANGKY',   
        policy_name     => 'POL_GIAOVU_DANGKY',
        policy_function => 'VPD_GIAOVU_DANGKY',
        STATEMENT_TYPES => 'INSERT, DELETE',
        update_check => true
    );
END;
/
GRANT SELECT, INSERT, DELETE ON DANGKY TO GIAOVU;
--PROC INSERT DK
CREATE OR REPLACE PROCEDURE PROC_INSERT_DANGKY (
    p_MASV IN VARCHAR2,
    p_MAGV IN VARCHAR2,
    p_MAHP IN VARCHAR2,
    p_HK IN INT,
    p_NAM IN NUMBER,
    p_MACT IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem d? li?u ?� t?n t?i trong b?ng DANGKY ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM DANGKY
    WHERE MASV = p_MASV
        AND MAGV = p_MAGV
        AND MAHP = p_MAHP
        AND HK = p_HK
        AND NAM = p_NAM
        AND MACT = p_MACT;

    -- N?u d? li?u ?� t?n t?i, th�ng b�o l?i
    IF v_Count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'D? li?u ?� t?n t?i trong b?ng DANGKY.');
    END IF;

    -- N?u d? li?u ch?a t?n t?i, th�m m?i v�o b?ng DANGKY
    INSERT INTO DANGKY (MASV, MAGV, MAHP, HK, NAM, MACT)
    VALUES (p_MASV, p_MAGV, p_MAHP, p_HK, p_NAM, p_MACT);
    
    COMMIT;
END PROC_INSERT_DANGKY;
/
GRANT EXECUTE ON PROC_INSERT_DANGKY TO GIAOVU;

--xoa dangky
CREATE OR REPLACE PROCEDURE PROC_DELETE_DANGKY (
    p_MASV IN VARCHAR2,
    p_MAGV IN VARCHAR2,
    p_MAHP IN VARCHAR2,
    p_HK IN INT,
    p_NAM IN NUMBER,
    p_MACT IN VARCHAR2
)
IS
BEGIN
    DELETE FROM DANGKY
    WHERE MASV = p_MASV
    AND MAGV = p_MAGV
    AND MAHP = p_MAHP
    AND HK = p_HK
    AND NAM = p_NAM
    AND MACT = p_MACT;

    COMMIT;

    DBMS_OUTPUT.PUT_LINE('D? li?u ?� ???c x�a th�nh c�ng.');
EXCEPTION
    WHEN OTHERS THEN
        -- X? l� l?i
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('L?i khi x�a d? li?u: ' || SQLERRM);
END PROC_DELETE_DANGKY;
/
GRANT EXECUTE ON PROC_DELETE_DANGKY TO GIAOVU;
SELECT * FROM DANGKY;

--CS#5
--UPDATE ON PHANCONG
CREATE OR REPLACE FUNCTION VPD_TRUONGKHOA_PHANCONG(P_SCHEMA VARCHAR2,P_OBJ VARCHAR2)
RETURN VARCHAR2
AS
    STR VARCHAR2(1000);
    USR VARCHAR(100);
BEGIN
    IF(UPPER(FUNC_VAITRO(USER))='TRUONGKHOA') THEN
        STR:='MAHP IN (SELECT MAHP FROM HOCPHAN WHERE MADV = ''DVVPK'')';
    END IF;
    RETURN STR;
END;
/
BEGIN
    DBMS_RLS.DROP_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'PHANCONG',   
        policy_name     => 'POL_TRUONGKHOA_PHANCONG'
    );
END;
/

BEGIN
    DBMS_RLS.ADD_POLICY(
        object_schema   => 'ADMINQL', 
        object_name     => 'PHANCONG',   
        policy_name     => 'POL_TRUONGKHOA_PHANCONG',
        policy_function => 'VPD_TRUONGKHOA_PHANCONG',
        STATEMENT_TYPES => 'UPDATE, INSERT, DELETE',
        UPDATE_CHECK => TRUE
    );
END;
/
GRANT EXECUTE ON PROC_UPDATE_PHANCONG TO TRUONGKHOA;

--proc xoa phancong
CREATE OR REPLACE PROCEDURE PROC_DELETE_PHANCONG (
    p_MAGV IN VARCHAR2,
    p_MAHP IN VARCHAR2,
    p_HK IN INT,
    p_NAM IN NUMBER,
    p_MACT IN VARCHAR2
)
IS
BEGIN
    DELETE FROM PHANCONG
    WHERE MAGV = p_MAGV
    AND MAHP = p_MAHP
    AND HK = p_HK
    AND NAM = p_NAM
    AND MACT = p_MACT;

    COMMIT;

    DBMS_OUTPUT.PUT_LINE('D? li?u ?� ???c x�a th�nh c�ng.');
EXCEPTION
    WHEN OTHERS THEN
        -- X? l� l?i
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('L?i khi x�a d? li?u: ' || SQLERRM);
END PROC_DELETE_PHANCONG;
/
GRANT EXECUTE ON PROC_DELETE_PHANCONG TO TRUONGKHOA;

--insert phancong
CREATE OR REPLACE PROCEDURE PROC_INSERT_PHANCONG (
    p_MAGV IN VARCHAR2,
    p_MAHP IN VARCHAR2,
    p_HK IN INT,
    p_NAM IN NUMBER,
    p_MACT IN VARCHAR2
)
AS
BEGIN
    INSERT INTO PHANCONG (MAGV, MAHP, HK, NAM, MACT)
    VALUES (p_MAGV, p_MAHP, p_HK, p_NAM, p_MACT);
    
    COMMIT;
    
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('L?i khi ch�n d? li?u: ' || SQLERRM);
END PROC_INSERT_PHANCONG;
/
GRANT EXECUTE ON PROC_INSERT_PHANCONG TO TRUONGKHOA;
GRANT SELECT ON HOCPHAN TO TRUONGKHOA;
GRANT SELECT,INSERT, UPDATE, DELETE ON PHANCONG TO TRUONGKHOA;

--nhansu
--insert
CREATE OR REPLACE PROCEDURE PROC_INSERT_NHANSU (
    p_MANV IN VARCHAR2,
    p_HOTEN IN NVARCHAR2,
    p_PHAI IN NVARCHAR2,
    p_NGSINH IN VARCHAR2,
    p_PHUCAP IN FLOAT,
    p_DIENTHOAI IN CHAR,
    p_VAITRO IN NVARCHAR2,
    p_MADV IN VARCHAR2
)
AS
    v_NGSINH DATE;
BEGIN
    -- Chuy?n ??i ng�y sinh t? chu?i th�nh ki?u DATE
    v_NGSINH := TO_DATE(p_NGSINH, 'yyyy-mm-dd');

    INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV)
    VALUES (p_MANV, p_HOTEN, p_PHAI, v_NGSINH, p_PHUCAP, p_DIENTHOAI, p_VAITRO, p_MADV);

    COMMIT;
    DBMS_OUTPUT.PUT_LINE('Th�m nh�n s? th�nh c�ng.');
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('L?i khi th�m nh�n s?: ' || SQLERRM);
END PROC_INSERT_NHANSU;
/
GRANT EXECUTE ON PROC_INSERT_NHANSU TO TRUONGKHOA;

--UPDATE NHANSU
CREATE OR REPLACE PROCEDURE PROC_UPDATE_NHANSU (
    p_MANV IN VARCHAR2,
    p_HOTEN IN NVARCHAR2,
    p_PHAI IN NVARCHAR2,
    p_NGSINH IN NVARCHAR2,
    p_PHUCAP IN FLOAT,
    p_DIENTHOAI IN CHAR,
    p_VAITRO IN NVARCHAR2,
    p_MADV IN VARCHAR2
)
AS
    v_NGSINH DATE;
BEGIN
    -- Chuy?n ??i chu?i ng�y sinh th�nh ki?u DATE
    v_NGSINH := TO_DATE(p_NGSINH, 'yyyy-mm-dd');
    
    -- Th?c hi?n c?p nh?t th�ng tin nh�n s?
    UPDATE NHANSU
    SET HOTEN = p_HOTEN,
        PHAI = p_PHAI,
        NGSINH = v_NGSINH, -- S? d?ng ng�y sinh ?� chuy?n ??i
        PHUCAP = p_PHUCAP,
        DIENTHOAI = p_DIENTHOAI,
        VAITRO = p_VAITRO,
        MADV = p_MADV
    WHERE MANV = p_MANV;

    -- Commit n?u kh�ng c� l?i
    COMMIT;
    
    -- Th�ng b�o th�nh c�ng
    DBMS_OUTPUT.PUT_LINE('C?p nh?t th�ng tin nh�n s? th�nh c�ng.');
EXCEPTION
    WHEN OTHERS THEN
        -- Rollback n?u c� l?i
        ROLLBACK;
        -- Th�ng b�o l?i
        DBMS_OUTPUT.PUT_LINE('L?i khi c?p nh?t th�ng tin nh�n s?: ' || SQLERRM);
END PROC_UPDATE_NHANSU;
/

GRANT EXECUTE ON PROC_UPDATE_NHANSU TO TRUONGKHOA;

GRANT SELECT, INSERT, DELETE, UPDATE ON NHANSU TO TRUONGKHOA
GRANT SELECT ANY TABLE TO TRUONGKHOA;


--GIANGVIEN
CREATE OR REPLACE FUNCTION GIANGVIEN_UPDATE_DIEMSO
    (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2 AS 
    STR VARCHAR2(1000);
    USR VARCHAR2(100); 
BEGIN
    IF(UPPER(FUNC_VAITRO(USER))='GIANGVIEN') THEN
        STR:='MAGV = ''' || SYS_CONTEXT('USERENV','SESSION_USER') || '''';
    ELSIF (UPPER(FUNC_VAITRO(USER))='TRUONGDONVI') THEN
        STR:='MAGV = ''' || SYS_CONTEXT('USERENV','SESSION_USER') || '''';
    END IF;
    RETURN STR;
END;
/
BEGIN
DBMS_RLS.DROP_POLICY(
    OBJECT_SCHEMA =>'ADMINQL',
    OBJECT_NAME=>'DANGKY',
    POLICY_NAME =>'GIANGVIEN_UPDATE_POLICY'
);
END;
/
BEGIN
DBMS_RLS.ADD_POLICY(
    OBJECT_SCHEMA =>'ADMINQL',
    OBJECT_NAME=>'DANGKY',
    POLICY_NAME =>'GIANGVIEN_UPDATE_POLICY',
    POLICY_FUNCTION=>'GIANGVIEN_UPDATE_DIEMSO',
    STATEMENT_TYPES=>'SELECT, UPDATE',
    UPDATE_CHECK => TRUE
 );
END;
/
GRANT SELECT, UPDATE (DIEMTHI, DIEMQT, DIEMCK, DIEMTK) ON DANGKY TO GIANGVIEN;
