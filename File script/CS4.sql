-- Truong don vi
-- Nhu mot nguoi dung co vai tro "Giang vien"
GRANT GIANGVIEN TO TRUONGDV;
GRANT SELECT, UPDATE (DIEMTHI, DIEMQT, DIEMCK, DIEMTK) ON DANGKY TO TRUONGDV;
SELECT * FROM NHANSU;
SELECT * FROM PHANCONG;

-- Duoc xem du lieu phan cong giang day cua cac giang vien thuoc cac don vi ma minh lam truong
CREATE OR REPLACE VIEW VIEW_TRUONG_DV_PHANCONGGIANGDAY AS
SELECT * FROM PHANCONG WHERE MAGV IN (SELECT MAGV FROM NHANSU WHERE MADV = 
                                     (SELECT MADV FROM DONVI 
                                      WHERE TRGDV= SYS_CONTEXT('USERENV', 'SESSION_USER')));

GRANT SELECT ON VIEW_TRUONG_DV_PHANCONGGIANGDAY TO TRUONGDV;
SELECT * FROM PHANCONG;
SELECT * FROM HOCPHAN;
/*
- Them, Xoa, Cap nhat du lieu tren PHANCONG, doi voi cac hp duoc phu trach
chuyen mon boi don vi ma m�nh lam truong. */
CREATE OR REPLACE FUNCTION TRUONGDONVI_PHANCONG
    (P_SCHEMA VARCHAR2, P_OBJ VARCHAR2)
RETURN VARCHAR2 AS 
    STR VARCHAR2(1000);
    USR VARCHAR2(100); 
BEGIN
    IF UPPER(FUNC_VAITRO(USER)) = 'TRUONGDV' THEN
        STR := 'MAHP IN (SELECT MAHP FROM HOCPHAN WHERE MADV = (SELECT MADV FROM DONVI 
                      WHERE TRGDV = ''' || SYS_CONTEXT('USERENV','SESSION_USER') || '''))';
    END IF;
    RETURN STR;
END;
/
BEGIN
DBMS_RLS.DROP_POLICY(
    OBJECT_SCHEMA =>'ADMINQL',
    OBJECT_NAME=>'PHANCONG',
    POLICY_NAME =>'TRUONGDV_POLICY'
);
END;
/
BEGIN
DBMS_RLS.ADD_POLICY(
    OBJECT_SCHEMA =>'ADMINQL',
    OBJECT_NAME=>'PHANCONG',
    POLICY_NAME =>'TRUONGDV_POLICY',
    POLICY_FUNCTION=>'TRUONGDONVI_PHANCONG',
    STATEMENT_TYPES=>'SELECT, UPDATE, INSERT, DELETE',
    UPDATE_CHECK => TRUE
 );
END;
/
GRANT SELECT, INSERT, UPDATE, DELETE ON PHANCONG TO TRUONGDV;

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
GRANT EXECUTE ON PROC_DELETE_PHANCONG TO TRUONGDV;

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
GRANT EXECUTE ON PROC_INSERT_PHANCONG TO TRUONGDV;

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
GRANT EXECUTE ON PROC_UPDATE_PHANCONG TO TRUONGDV;