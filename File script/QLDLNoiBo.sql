--tao csdl qlbanhang
--SINHVIEN (MASV, HOTEN, PHAI, NGSINH, ?CHI, ?T, MACT, MANGANH, SOTCTL, ?TBTL)


-- XAI SYS CHAY DONG SAU
ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE;
DROP USER ADMINQL CASCADE;
CREATE USER ADMINQL IDENTIFIED BY ADMINQL;
GRANT DBA TO ADMINQL;
GRANT SELECT ON DBA_ROLE_PRIVS TO ADMINQL;
GRANT EXECUTE ANY PROCEDURE TO ADMINQL;
grant create procedure to ADMINQL;
GRANT CREATE USER TO ADMINQL;
GRANT CREATE SESSION TO ADMINQL CONTAINER = ALL;
GRANT ALL PRIVILEGES TO ADMINQL WITH ADMIN OPTION;
alter session set current_schema =  ADMINQL;
GRANT SELECT ON DBA_ROLE_PRIVS TO ADMINQL;
-- DANG NHAP VAO SYS CHAY

DROP TABLE DANGKY;
CREATE TABLE DANGKY
(
    MASV VARCHAR(4),
    MAGV VARCHAR(4),
    MAHP VARCHAR(4),
    HK int,
    NAM NUMBER(4),
    MACT VARCHAR(4),
    DIEMTHI NUMBER(6, 3),
    DIEMQT NUMBER(6, 3),
    DIEMCK NUMBER(6, 3),
    DIEMTK NUMBER(6, 3),
    PRIMARY KEY(MAGV, MAHP, HK, NAM, MACT)
);
--PHANCONG (MAGV, MAHP, HK, NAM, MACT)
DROP TABLE PHANCONG;
CREATE TABLE PHANCONG
(
    MAGV VARCHAR(4),
    MAHP VARCHAR(4),
    HK int,
    NAM NUMBER(4),
    MACT VARCHAR(4),
    PRIMARY KEY(MAGV, MAHP, HK, NAM, MACT)
);

--KHMO (MAHP, HK, NAM, MACT)
DROP TABLE KHMO;
CREATE TABLE KHMO
(
    MAHP VARCHAR(4),
    HK int,
    NAM NUMBER(4),
    MACT VARCHAR(4),
    PRIMARY KEY(MAHP, HK, NAM, MACT)
);

--HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVT?, MA?V)
DROP TABLE HOCPHAN;
CREATE TABLE HOCPHAN
(
    MAHP VARCHAR(4),
    TENHP NVARCHAR2(50),
    SOTC int,
    STLT int,
    STTH int,
    SOSVTD int,
    MADV VARCHAR(10),
    PRIMARY KEY(MAHP)
);

DROP TABLE SINHVIEN;
CREATE TABLE SINHVIEN
(
    MASV VARCHAR(4),
    HOTEN NVARCHAR2(50),
    PHAI NVARCHAR2(10),
    NGSINH DATE,
    DIACHI NVARCHAR2(100),
    DIENTHOAI CHAR(12),
    MACT VARCHAR(4),
    MANGANH VARCHAR(4),
    SOTCTL int,
    DTBTL NUMBER(6, 3),
    PRIMARY KEY(MASV)
);
--NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, ?T, VAITRO, MA?V)
ALTER TABLE NHANSU
DROP CONSTRAINT fk_NS_DV;
ALTER TABLE DONVI
DROP CONSTRAINT fk_DV_NS;

DROP TABLE NHANSU;
CREATE TABLE NHANSU
(
    MANV VARCHAR(4),
    HOTEN NVARCHAR2(50),
    PHAI NVARCHAR2(10),
    NGSINH DATE,
    PHUCAP float,
    DIENTHOAI CHAR(12),
    VAITRO NVARCHAR2(20),
    MADV VARCHAR(10),
    PRIMARY KEY(MANV)
);

--?ONVI (MA?V, TEN?V, TRG?V)
DROP TABLE DONVI;
CREATE TABLE DONVI
(
    MADV VARCHAR(10),
    TENDV NVARCHAR2(50),
    TRGDV VARCHAR(4),
    PRIMARY KEY(MADV)
);


--?ANGKY (MASV, MAGV, MAHP, HK, NAM, MACT, ?IEMTH, ?IEMQT, ?IEMCK, ?IEMTK)

--Noi qua DONVI


ALTER TABLE NHANSU
ADD CONSTRAINT fk_NS_DV FOREIGN KEY (MADV)
REFERENCES DONVI(MADV);

ALTER TABLE HOCPHAN
ADD CONSTRAINT fk_HP_DV FOREIGN KEY (MADV)
REFERENCES DONVI(MADV);

--Noi qua NHANSU


ALTER TABLE DONVI
ADD CONSTRAINT fk_DV_NS FOREIGN KEY (TRGDV)
REFERENCES NHANSU(MANV);


ALTER TABLE PHANCONG
ADD CONSTRAINT fk_PC_NS FOREIGN KEY (MAGV)
REFERENCES NHANSU(MANV);

--Noi qua SINHVIEN


ALTER TABLE DANGKY
ADD CONSTRAINT fk_DK_SV FOREIGN KEY (MASV)
REFERENCES SINHVIEN(MASV);


--Noi qua KHMO


ALTER TABLE PHANCONG
ADD CONSTRAINT fk_PC_KHMO FOREIGN KEY (MAHP, HK, NAM, MACT)
REFERENCES KHMO(MAHP, HK, NAM, MACT);


--Noi qua PHANCONG
ALTER TABLE DANGKY
DROP CONSTRAINT fk_DK_PC;

ALTER TABLE DANGKY
ADD CONSTRAINT fk_DK_PC FOREIGN KEY (MAGV, MAHP, HK, NAM, MACT)
REFERENCES PHANCONG(MAGV, MAHP, HK, NAM, MACT);

--Noi qua SINHVIEN


--MOCK DATA
-- D? li?u cho b?ng DONVI
DELETE FROM DONVI;
INSERT INTO DONVI (MADV, TENDV, TRGDV) VALUES ('VPK', N'Van Phong Khoa', NULL);
INSERT INTO DONVI (MADV, TENDV, TRGDV) VALUES ('HTTT', N'Bo Mon HTTT', NULL);
INSERT INTO DONVI (MADV, TENDV, TRGDV) VALUES ('CNPM', N'Bo Mon CNPM', NULL);
INSERT INTO DONVI (MADV, TENDV, TRGDV) VALUES ('KHMT', N'Bo Mon KHMT', NULL);
INSERT INTO DONVI (MADV, TENDV, TRGDV) VALUES ('CNTT', N'Bo Mon CNTT', NULL);
INSERT INTO DONVI (MADV, TENDV, TRGDV) VALUES ('TGMT', N'Bo Mon TGMT', NULL);
INSERT INTO DONVI (MADV, TENDV, TRGDV) VALUES ('MMT', N'Bo Mon MMT', NULL);
INSERT INTO DONVI (MADV, TENDV, TRGDV) VALUES ('VT', N'Vien Thong', NULL);
SELECT * FROM DONVI;
DELETE FROM NHANSU;

--TRUONG KHOA
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N000', N'Nguyen Van A', N'Nam', TO_DATE('1990-01-01', 'YYYY-MM-DD'), 500000, '0987654321', N'TRUONGKHOA', 'VPK');
-- TRUONGDONVI
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N001', N'Nguyen Van A', N'Nam', TO_DATE('1990-01-01', 'YYYY-MM-DD'), 500000, '0987654321', N'TRUONGDV', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N002', N'Tran Thi B', N'N?', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456489', N'TRUONGDV', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N003', N'Nguyen Van C', N'Nam', TO_DATE('1990-01-01', 'YYYY-MM-DD'), 500000, '0987654321', N'TRUONGDV', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N004', N'Tran Thi D', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456589', N'TRUONGDV', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N005', N'Tran Thi D', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456689', N'TRUONGDV', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N006', N'Tran Thi E', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'TRUONGDV', 'MMT');
--VPK GIAOVU
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N009', N'Tran Van E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N010', N'Tran Van F', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N011', N'Tran Van G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N012', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N013', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N014', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N015', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N016', N'Tran Lan E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N017', N'Tran Lan F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N018', N'Tran Lan G', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N019', N'Tran Lan K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK');

--Cac giangvien
--HTTT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N020', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N021', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N022', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N023', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N024', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N025', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N026', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N027', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N028', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N029', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT');
--DVCNPM
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N030', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N031', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N032', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N033', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N034', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N035', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N036', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N037', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N038', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N039', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM');
--DVKHMT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N040', N'Tran Quang E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N041', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N042', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N043', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N044', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N045', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N046', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N047', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N048', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N049', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT');
--DVCNTT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N050', N'Tran Quang O', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N051', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N052', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N053', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N054', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N055', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N056', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N057', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N058', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N059', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT');
--DVTGMT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N060', N'Tran Quang O', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N061', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N062', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N063', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N064', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N065', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N066', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N067', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N068', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N069', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT');
--DVMMT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N070', N'Tran Quang Q', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457789', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N071', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N072', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N073', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N074', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457789', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N075', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N076', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N077', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N078', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N079', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT');
--DVVT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N080', N'Tran Quang T', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456889', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N081', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458889', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N082', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N083', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N084', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458889', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N085', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458889', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N086', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N087', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N088', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N089', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N090', N'Tran Quang ANDREE', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456889', N'GIANGVIEN', 'VT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N091', N'Tran Anh WON', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458889', N'GIANGVIEN', 'VT');
--NHANVIENCOBAN
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N092', N'Tran Quang Q', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123459989', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N093', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123459889', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N094', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N095', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N096', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123459989', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N097', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123459889', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N098', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N099', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N100', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N102', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK');
--GIANGVIEN
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N103', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N104', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457789', N'GIANGVIEN', 'CNPM');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N105', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'KHMT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N106', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N107', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT');
SELECT * FROM NHANSU;
--Truong Don Vi
UPDATE DONVI SET donvi.trgdv = 'N001' WHERE donvi.madv = 'VPK';
UPDATE DONVI SET donvi.trgdv = 'N002' WHERE donvi.madv = 'HTTT';
UPDATE DONVI SET donvi.trgdv = 'N003' WHERE donvi.madv = 'CNPM';
UPDATE DONVI SET donvi.trgdv = 'N004' WHERE donvi.madv = 'KHMT';
UPDATE DONVI SET donvi.trgdv = 'N005' WHERE donvi.madv = 'CNTT';
UPDATE DONVI SET donvi.trgdv = 'N006' WHERE donvi.madv = 'TGMT';


-- D? li?u cho b?ng SINHVIEN
DELETE FROM SINHVIEN;
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S001', N'Pham Van C', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CLC', 'KH01', 80, 7.5);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S002', N'Ly Thi D', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'CQ', 'KH02', 75, 8.0);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S003', N'Pham Van E', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CTTT', 'KH01', 80, 7.5);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S004', N'Ly Thi E', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'VP', 'KH02', 75, 8.0);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S005', N'Pham Van F', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CQ', 'KH01', 80, 7.5);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S006', N'Ly Thi F', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'CLC', 'KH02', 75, 8.0);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S007', N'Pham Van G', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CTTT', 'KH01', 80, 7.5);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S008', N'Ly Thi G', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'CQ', 'KH02', 75, 8.0);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S009', N'Pham Van H', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CLC', 'KH01', 80, 7.5);
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL) VALUES ('S010', N'Ly Thi H', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'CLC', 'KH02', 75, 8.0);
SELECT * FROM SINHVIEN;
-- D? li?u cho b?ng HOCPHAN
DELETE FROM HOCPHAN;
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES ('H001', N'Lap trinh Java', 3, 2, 1, 40, 'CNPM');
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES ('H002', N'Co so du lieu', 4, 3, 1, 50, 'HTTT');
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES ('H003', N'Nhap mon CNTT', 3, 2, 1, 40, 'CNTT');
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES ('H004', N'Co so du lieu nang cao', 4, 3, 1, 50, 'HTTT');
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES ('H005', N'Phat trien phan mem', 3, 2, 1, 40, 'CNPM');
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES ('H006', N'He quan tri CSDL', 4, 3, 1, 50, 'HTTT');
INSERT INTO HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVTD, MADV) VALUES ('H007', N'Tri tue nhan tao', 3, 2, 1, 40, 'KHMT');
SELECT * FROM HOCPHAN;
-- D? li?u cho b?ng KHMO
DELETE FROM KHMO;
INSERT INTO KHMO (MAHP, HK, NAM, MACT) VALUES ('H001', 1, 2023, 'CQ');
INSERT INTO KHMO (MAHP, HK, NAM, MACT) VALUES ('H002', 2, 2023, 'CLC');
INSERT INTO KHMO (MAHP, HK, NAM, MACT) VALUES ('H003', 1, 2024, 'CTTT');
INSERT INTO KHMO (MAHP, HK, NAM, MACT) VALUES ('H004', 2, 2024, 'VP');
INSERT INTO KHMO (MAHP, HK, NAM, MACT) VALUES ('H005', 3, 2024, 'CQ');
INSERT INTO KHMO (MAHP, HK, NAM, MACT) VALUES ('H006', 1, 2024, 'CLC');
SELECT * FROM KHMO;

-- D? li?u cho b?ng PHANCONG
DELETE FROM PHANCONG;
INSERT INTO PHANCONG (MAGV, MAHP, HK, NAM, MACT) VALUES ('N012', 'H002', 2, 2023, 'CLC');
INSERT INTO PHANCONG (MAGV, MAHP, HK, NAM, MACT) VALUES ('N016', 'H001', 1, 2023, 'CQ');
INSERT INTO PHANCONG (MAGV, MAHP, HK, NAM, MACT) VALUES ('N001', 'H004', 2, 2024, 'VP');
SELECT * FROM PHANCONG;
-- D? li?u cho b?ng DANGKY
DELETE FROM DANGKY;
INSERT INTO DANGKY (MASV, MAGV, MAHP, HK, NAM, MACT, DIEMTHI, DIEMQT, DIEMCK, DIEMTK) VALUES ('S001', 'N012', 'H002', 2, 2023, 'CLC', 7.5, 8.0, 7.0, 7.5);
INSERT INTO DANGKY (MASV, MAGV, MAHP, HK, NAM, MACT, DIEMTHI, DIEMQT, DIEMCK, DIEMTK) VALUES ('S002', 'N016', 'H001', 1, 2023, 'CQ', 8.0, 8.5, 9.0, 8.5);
SELECT * FROM DANGKY;

CREATE OR REPLACE PROCEDURE USP_CREATEUSER
AS
 CURSOR CUR IS (SELECT MANV
 FROM NHANSU
 WHERE MANV NOT IN (SELECT USERNAME
 FROM ALL_USERS)
 );
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
BEGIN
 OPEN CUR;
 STRSQL := 'ALTER SESSION SET "_ORACLE_SCRIPT" = TRUE';
 EXECUTE IMMEDIATE(STRSQL);
 LOOP
 FETCH CUR INTO USR;
 EXIT WHEN CUR%NOTFOUND;
 STRSQL := 'CREATE USER '||USR||' IDENTIFIED BY '||USR;
 EXECUTE IMMEDIATE(STRSQL);
 STRSQL := 'GRANT CREATE SESSION TO '||USR;
 EXECUTE IMMEDIATE(STRSQL);
 END LOOP;
 STRSQL := 'ALTER SESSION SET "_ORACLE_SCRIPT" = FALSE';
 EXECUTE IMMEDIATE(STRSQL);
 CLOSE CUR;
END;
/
EXEC USP_CREATEUSER;
/
CREATE OR REPLACE PROCEDURE USP_GRANTROLE
 (STRROLE VARCHAR)
AS
 CURSOR CUR IS (SELECT MANV
 FROM NHANSU
 WHERE MANV IN (SELECT USERNAME
 FROM ALL_USERS)
 AND VAITRO = STRROLE);
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR;
 EXIT WHEN CUR%NOTFOUND;
 STRSQL := 'GRANT '||STRROLE||' TO '||USR;
 EXECUTE IMMEDIATE (STRSQL);
 END LOOP;
 CLOSE CUR;
END;
/
CREATE OR REPLACE PROCEDURE DROP_NHANSU
AS
 CURSOR CUR IS (SELECT MANV
 FROM NHANSU
 WHERE MANV IN (SELECT USERNAME
 FROM ALL_USERS));
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR;
 EXIT WHEN CUR%NOTFOUND;
 STRSQL := 'DROP USER '||USR||' CASCADE ';
 EXECUTE IMMEDIATE(STRSQL);
 END LOOP;
 CLOSE CUR;
END;
/
CREATE OR REPLACE PROCEDURE DROP_SINHVIEN
AS
 CURSOR CUR IS (SELECT MASV
 FROM SINHVIEN
 WHERE MASV IN (SELECT USERNAME
 FROM ALL_USERS));
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR;
 EXIT WHEN CUR%NOTFOUND;
 STRSQL := 'DROP USER '||USR||' CASCADE ';
 EXECUTE IMMEDIATE(STRSQL);
 END LOOP;
 CLOSE CUR;
END;
/
CREATE OR REPLACE PROCEDURE USP_CREATE_SINHVIEN
AS
 CURSOR CUR IS (SELECT MASV
 FROM SINHVIEN
 WHERE MASV NOT IN (SELECT USERNAME
 FROM ALL_USERS));
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR;
 EXIT WHEN CUR%NOTFOUND;
 STRSQL := 'CREATE USER '||USR||' IDENTIFIED BY '||USR;
 EXECUTE IMMEDIATE(STRSQL);
 STRSQL := 'GRANT CREATE SESSION TO '||USR;
 EXECUTE IMMEDIATE(STRSQL);
 END LOOP;
 CLOSE CUR;
END;
/
CREATE OR REPLACE PROCEDURE USP_GRANTROLE_SINHVIEN
AS
 CURSOR CUR IS (SELECT MASV
 FROM SINHVIEN
 WHERE MASV IN (SELECT USERNAME
 FROM ALL_USERS));
 STRSQL VARCHAR(2000);
 USR VARCHAR2(5);
BEGIN
 OPEN CUR;
 LOOP
 FETCH CUR INTO USR;
 EXIT WHEN CUR%NOTFOUND;
 STRSQL := 'GRANT SINHVIEN TO '||USR;
 EXECUTE IMMEDIATE (STRSQL);
 END LOOP;
 CLOSE CUR;
END;

/
DROP ROLE TRUONGKHOA;
CREATE ROLE TRUONGKHOA;
DROP ROLE GIAOVU;
CREATE ROLE GIAOVU;
DROP ROLE TRUONGDV;
CREATE ROLE TRUONGDV;
DROP ROLE GIANGVIEN;
CREATE ROLE GIANGVIEN;
DROP ROLE NHANVIENCOBAN;
CREATE ROLE NHANVIENCOBAN;
DROP ROLE SINHVIEN;
CREATE ROLE SINHVIEN;
EXEC DROP_NHANSU;
EXEC DROP_SINHVIEN;
EXEC USP_CREATEUSER;
EXEC USP_GRANTROLE('TRUONGKHOA');
EXEC USP_GRANTROLE('GIAOVU');
EXEC USP_GRANTROLE('TRUONGDV');
EXEC USP_GRANTROLE('GIANGVIEN');
EXEC USP_GRANTROLE('NHANVIENCOBAN');
EXEC USP_CREATE_SINHVIEN;
EXEC USP_GRANTROLE_SINHVIEN;
REVOKE SINHVIEN FROM ADMINQL;
alter session set "_ORACLE_SCRIPT"=true;






