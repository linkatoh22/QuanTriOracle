-- Them IF
-- CS2
--GIANGVIEN
GRANT NHANVIENCOBAN TO GIANGVIEN;

CREATE OR REPLACE VIEW VIEW_GIANG_VIEN_PHANCONG AS
SELECT * FROM PHANCONG WHERE MAGV = SYS_CONTEXT('USERENV', 'SESSION_USER');
GRANT SELECT ON VIEW_GIANG_VIEN_PHANCONG TO GIANGVIEN;
GRANT SELECT, UPDATE (DIEMTHI, DIEMQT, DIEMCK, DIEMTK) ON DANGKY TO GIANGVIEN;
GRANT EXECUTE ON PROC_UPDATE_DIEMSO TO GIANGVIEN;
