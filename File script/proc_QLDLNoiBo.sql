--PROC CS1

--NHANVIENCOBAN
DROP PROCEDURE PROC_UPD_SDT;
CREATE OR REPLACE PROCEDURE PROC_UPD_SDT(SDT IN VARCHAR2)
AS
BEGIN
    IF SDT IS NULL THEN
        RAISE_APPLICATION_ERROR(-20001, 'SDT không ???c ?? tr?ng');
    END IF;
    IF LENGTH(SDT) > 10 THEN
        RAISE_APPLICATION_ERROR(-20002, 'S? ?I?N THO?I CH? CÓ 10 S?');
    END IF;
    
    UPDATE NHANSU 
    SET DIENTHOAI = SDT
    WHERE MANV = SYS_CONTEXT('USERENV','SESSION_USER');
    
    IF SQL%ROWCOUNT = 0 THEN
        RAISE_APPLICATION_ERROR(-20003, 'Không tìm th?y nhân viên t??ng ?ng');
    END IF;
    
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('L?i: ' || SQLCODE || ' - ' || SQLERRM);
END;
/

CREATE OR REPLACE FUNCTION FUNC_VAITRO(USRNAME VARCHAR2)
RETURN VARCHAR2
AS
    CURSOR CUR IS 
    (
        SELECT GRANTED_ROLE FROM DBA_ROLE_PRIVS
        WHERE UPPER(GRANTEE)=UPPER(USRNAME)
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

--PROC CS2

CREATE OR REPLACE PROCEDURE PROC_UPDATE_DIEMSO (
    p_MASV VARCHAR2,
    p_MAGV VARCHAR2,
    p_MAHP VARCHAR2,
    p_HK INT,
    p_NAM NUMBER,
    p_MACT VARCHAR2,
    p_DIEMTHI NUMBER,
    p_DIEMQT NUMBER,
    p_DIEMCK NUMBER,
    p_DIEMTK NUMBER
) IS
BEGIN
    -- C?p nh?t ?i?m s?
    UPDATE DANGKY
    SET DIEMTHI = p_DIEMTHI,
        DIEMQT = p_DIEMQT,
        DIEMCK = p_DIEMCK,
        DIEMTK = p_DIEMTK
    WHERE MASV = p_MASV AND MAGV = p_MAGV AND MAHP = p_MAHP AND HK = p_HK AND
          NAM = p_NAM AND MACT = p_MACT;

    -- Ki?m tra xem có b?n ghi nào ???c c?p nh?t không
    IF SQL%ROWCOUNT = 0 THEN
        DBMS_OUTPUT.PUT_LINE('Thông tin ??ng ký ?ã nh?p không ?úng');
    ELSE
        DBMS_OUTPUT.PUT_LINE('C?p nh?t ?i?m s? thành công.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('L?i khi c?p nh?t ?i?m s?: ' || SQLERRM);
END;
--PROC CS3
/

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
    -- Ki?m tra xem MSSV ?ã t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM SinhVien
    WHERE MASV = p_MSSV;

    -- N?u MSSV ?ã t?n t?i, thông báo l?i
    IF v_Count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'MSSV ?ã t?n t?i');
    END IF;

    -- N?u MSSV ch?a t?n t?i, thêm sinh viên vào b?ng SinhVien
    INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH) VALUES 
    (p_MSSV, p_HOTEN, p_PHAI, TO_DATE(p_NGSINH, 'YYYY-MM-DD'), p_DIACHI, p_DIENTHOAI, p_MACT, p_MANGANH);
    
    COMMIT;
END;
/
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
    -- C?p nh?t thông tin sinh viên
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

    -- Ki?m tra xem có b?n ghi nào ???c c?p nh?t không
    IF SQL%ROWCOUNT = 0 THEN
        DBMS_OUTPUT.PUT_LINE('Không tìm th?y sinh viên có MSSV là ' || p_MSSV);
    ELSE
        DBMS_OUTPUT.PUT_LINE('C?p nh?t thông tin sinh viên thành công.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('L?i khi c?p nh?t thông tin sinh viên: ' || SQLERRM);
END;
/
CREATE OR REPLACE PROCEDURE PROC_THEMDONVI (
    p_MADV IN VARCHAR2,
    p_TENDV IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem MSSV ?ã t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM DONVI
    WHERE MADV = p_MADV;

    -- N?u MSSV ?ã t?n t?i, thông báo l?i
    IF v_Count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'MADV ?ã t?n t?i');
    END IF;

    -- N?u MSSV ch?a t?n t?i, thêm sinh viên vào b?ng SinhVien
    INSERT INTO DONVI (MADV, TENDV) VALUES 
    (p_MADV, p_TENDV);
    
    COMMIT;
END;
/
CREATE OR REPLACE PROCEDURE PROC_UPDATEDONVI (
    p_MADV IN VARCHAR2,
    p_TENDV IN VARCHAR2
)
IS
    v_Count NUMBER;
    v_TRGDV_COUNT NUMBER;
BEGIN
    -- Ki?m tra xem MADV ?ã t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM DONVI
    WHERE MADV = p_MADV;

    -- N?u MADV không t?n t?i, thông báo l?i
    IF v_Count = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'MADV không t?n t?i');
    END IF;
    -- C?p nh?t thông tin c?a ??n v?
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
    -- Ki?m tra xem MAHP ?ã t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM HOCPHAN
    WHERE MAHP = p_MAHP;

    IF v_Count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'MAHP ?ã t?n t?i');
    END IF;

    -- Thêm h?c ph?n m?i vào b?ng HOCPHAN
    INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES 
    (p_MAHP, p_TENHP, p_SOTC, p_STLT, p_STTH, p_SOSVTD, p_MADV);
    
    COMMIT;
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/
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
    -- Ki?m tra xem MAHP ?ã t?n t?i ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM HOCPHAN
    WHERE MAHP = p_MAHP;

    -- N?u MAHP không t?n t?i, thông báo l?i
    IF v_Count = 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'Mã h?c ph?n không t?n t?i');
    END IF;

    -- C?p nh?t thông tin h?c ph?n
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
CREATE OR REPLACE PROCEDURE PROC_INSERT_KHMO (
    p_MAHP IN VARCHAR2,
    p_HK IN INT,
    p_NAM IN NUMBER,
    p_MACT IN VARCHAR2
)
IS
    v_Count NUMBER;
BEGIN
    -- Ki?m tra xem MAHP ?ã t?n t?i trong b?ng KHMO ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM KHMO
    WHERE MAHP = p_MAHP AND HK = p_HK AND NAM = p_NAM AND MACT = p_MACT;

    -- N?u ch?a t?n t?i, thêm m?i
    IF v_Count = 0 THEN
        INSERT INTO KHMO (MAHP, HK, NAM, MACT) VALUES (p_MAHP, p_HK, p_NAM, p_MACT);
        COMMIT;
    ELSE
        -- N?u ?ã t?n t?i, thông báo l?i
        raise_application_error(-20001, 'Mã h?c ph?n này ?ã t?n t?i trong k? h?c và n?m h?c này.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý l?i
        ROLLBACK;
        RAISE;
END PROC_INSERT_KHMO;
/
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
    -- Ki?m tra xem giá tr? c? t?n t?i trong b?ng KHMO hay không
    SELECT COUNT(*)
    INTO v_Count
    FROM KHMO
    WHERE MAHP = p_MAHP_old AND HK = p_HK_old AND NAM = p_NAM_old AND MACT = p_MACT_old;

    -- N?u giá tr? c? t?n t?i, ti?n hành c?p nh?t
    IF v_Count > 0 THEN
        -- C?p nh?t thông tin m?i
        UPDATE KHMO
        SET MAHP = p_MAHP_new,
            HK = p_HK_new,
            NAM = p_NAM_new,
            MACT = p_MACT_new
        WHERE MAHP = p_MAHP_old AND HK = p_HK_old AND NAM = p_NAM_old AND MACT = p_MACT_old;
        
        COMMIT;
    ELSE
        -- N?u không t?n t?i, thông báo l?i
        raise_application_error(-20002, 'Không tìm th?y mã h?c ph?n c? trong k? h?c và n?m h?c này.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý l?i
        ROLLBACK;
        RAISE;
END PROC_UPDATE_KHMO;
/
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
    -- Ki?m tra xem dòng c? t?n t?i trong b?ng PHANCONG không
    SELECT COUNT(*)
    INTO v_Count
    FROM PHANCONG
    WHERE MAGV = p_MAGV_old
      AND MAHP = p_MAHP_old
      AND HK = p_HK_old
      AND NAM = p_NAM_old
      AND MACT = p_MACT_old;

    -- N?u t?n t?i dòng c?, thì c?p nh?t
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
        -- N?u không tìm th?y dòng c?, báo l?i
        RAISE_APPLICATION_ERROR(-20002, 'Không tìm th?y dòng d? li?u c?.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý ngo?i l?
        ROLLBACK;
        RAISE;
END PROC_UPDATE_PHANCONG;


/
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
    -- Ki?m tra xem d? li?u ?ã t?n t?i trong b?ng DANGKY ch?a
    SELECT COUNT(*)
    INTO v_Count
    FROM DANGKY
    WHERE MASV = p_MASV
        AND MAGV = p_MAGV
        AND MAHP = p_MAHP
        AND HK = p_HK
        AND NAM = p_NAM
        AND MACT = p_MACT;

    -- N?u d? li?u ?ã t?n t?i, thông báo l?i
    IF v_Count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'D? li?u ?ã t?n t?i trong b?ng DANGKY.');
    END IF;

    -- N?u d? li?u ch?a t?n t?i, thêm m?i vào b?ng DANGKY
    INSERT INTO DANGKY (MASV, MAGV, MAHP, HK, NAM, MACT)
    VALUES (p_MASV, p_MAGV, p_MAHP, p_HK, p_NAM, p_MACT);
    
    COMMIT;
END PROC_INSERT_DANGKY;
/
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

    DBMS_OUTPUT.PUT_LINE('D? li?u ?ã ???c xóa thành công.');
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý l?i
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('L?i khi xóa d? li?u: ' || SQLERRM);
END PROC_DELETE_DANGKY;
/

--PROC CS4

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

    DBMS_OUTPUT.PUT_LINE('D? li?u ?ã ???c xóa thành công.');
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý l?i
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('L?i khi xóa d? li?u: ' || SQLERRM);
END PROC_DELETE_PHANCONG;
/


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
        DBMS_OUTPUT.PUT_LINE('L?i khi chèn d? li?u: ' || SQLERRM);
END PROC_INSERT_PHANCONG;
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
    -- Ki?m tra xem dòng c? t?n t?i trong b?ng PHANCONG không
    SELECT COUNT(*)
    INTO v_Count
    FROM PHANCONG
    WHERE MAGV = p_MAGV_old
      AND MAHP = p_MAHP_old
      AND HK = p_HK_old
      AND NAM = p_NAM_old
      AND MACT = p_MACT_old;

    -- N?u t?n t?i dòng c?, thì c?p nh?t
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
        -- N?u không tìm th?y dòng c?, báo l?i
        RAISE_APPLICATION_ERROR(-20002, 'Không tìm th?y dòng d? li?u c?.');
    END IF;
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý ngo?i l?
        ROLLBACK;
        RAISE;
END PROC_UPDATE_PHANCONG;
/


--PROC CS5



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

    DBMS_OUTPUT.PUT_LINE('D? li?u ?ã ???c xóa thành công.');
EXCEPTION
    WHEN OTHERS THEN
        -- X? lý l?i
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('L?i khi xóa d? li?u: ' || SQLERRM);
END PROC_DELETE_PHANCONG;
/


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
        DBMS_OUTPUT.PUT_LINE('L?i khi chèn d? li?u: ' || SQLERRM);
END PROC_INSERT_PHANCONG;
/


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
    -- Chuy?n ??i ngày sinh t? chu?i thành ki?u DATE
    v_NGSINH := TO_DATE(p_NGSINH, 'yyyy-mm-dd');

    INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV)
    VALUES (p_MANV, p_HOTEN, p_PHAI, v_NGSINH, p_PHUCAP, p_DIENTHOAI, p_VAITRO, p_MADV);

    COMMIT;
    DBMS_OUTPUT.PUT_LINE('Thêm nhân s? thành công.');
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        DBMS_OUTPUT.PUT_LINE('L?i khi thêm nhân s?: ' || SQLERRM);
END PROC_INSERT_NHANSU;
/



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
    -- Chuy?n ??i chu?i ngày sinh thành ki?u DATE
    v_NGSINH := TO_DATE(p_NGSINH, 'yyyy-mm-dd');
    
    -- Th?c hi?n c?p nh?t thông tin nhân s?
    UPDATE NHANSU
    SET HOTEN = p_HOTEN,
        PHAI = p_PHAI,
        NGSINH = v_NGSINH, -- S? d?ng ngày sinh ?ã chuy?n ??i
        PHUCAP = p_PHUCAP,
        DIENTHOAI = p_DIENTHOAI,
        VAITRO = p_VAITRO,
        MADV = p_MADV
    WHERE MANV = p_MANV;

    -- Commit n?u không có l?i
    COMMIT;
    
    -- Thông báo thành công
    DBMS_OUTPUT.PUT_LINE('C?p nh?t thông tin nhân s? thành công.');
EXCEPTION
    WHEN OTHERS THEN
        -- Rollback n?u có l?i
        ROLLBACK;
        -- Thông báo l?i
        DBMS_OUTPUT.PUT_LINE('L?i khi c?p nh?t thông tin nhân s?: ' || SQLERRM);
END PROC_UPDATE_NHANSU;
/


--PROC CS6

/

CREATE OR REPLACE PROCEDURE PROC_UPDATESINHVIEN(DCHI IN VARCHAR2, DT IN VARCHAR2)
AS
BEGIN
    UPDATE SINHVIEN 
    SET DIACHI=DCHI,
    DIENTHOAI=DT 
    WHERE MASV=SYS_CONTEXT('USERENV','SESSION_USER');
END;


/

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

