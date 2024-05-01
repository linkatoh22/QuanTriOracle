--tao csdl qlbanhang
--SINHVIEN (MASV, HOTEN, PHAI, NGSINH, ?CHI, ?T, MACT, MANGANH, SOTCTL, ?TBTL)
-- XAI SYS CHAY DONG SAU
--ALTER SESSION SET CONTAINER=qlnb;*/

alter session set container = CDB$ROOT;
-- DANG NHAP VAO ADMINQL  CHAY
DROP TABLE DANGKY;
DROP TABLE PHANCONG;
DROP TABLE KHMO;
DROP TABLE HOCPHAN;
DROP TABLE SINHVIEN;
DROP TABLE THONGBAO;
SHOW CON_NAME;

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
    PRIMARY KEY(MAGV, MAHP, HK, NAM, MACT,MASV)
);
--PHANCONG (MAGV, MAHP, HK, NAM, MACT)

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

CREATE TABLE KHMO
(
    MAHP VARCHAR(4),
    HK int,
    NAM NUMBER(4),
    MACT VARCHAR(4),
    PRIMARY KEY(MAHP, HK, NAM, MACT)
);

--HOCPHAN (MAHP, TENHP, SOTC, STLT, STTH, SOSVT?, MA?V)

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
    COSO VARCHAR(20),
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
    COSO VARCHAR(20),
    PRIMARY KEY(MANV)
);

--?ONVI (MA?V, TEN?V, TRG?V)
DROP TABLE DONVI;
CREATE TABLE DONVI
(
    MADV VARCHAR(10),
    TENDV NVARCHAR2(50),
    TRGDV VARCHAR(4),
    COSO VARCHAR(20),
    PRIMARY KEY(MADV,COSO)
);
DROP TABLE THONGBAO;
CREATE TABLE THONGBAO
(
    MATHONGBAO VARCHAR(10),
    THONGBAO VARCHAR(1000),
    PRIMARY KEY(MATHONGBAO)
);
INSERT INTO THONGBAO(MATHONGBAO,THONGBAO) VALUES('T1','THONG BAO T1');
INSERT INTO THONGBAO(MATHONGBAO,THONGBAO) VALUES('T2','Thong Bao T2');
INSERT INTO THONGBAO(MATHONGBAO,THONGBAO) VALUES('T3','THONG BAO T3');
INSERT INTO THONGBAO(MATHONGBAO,THONGBAO) VALUES('T4','THONG BAO T4');
INSERT INTO THONGBAO(MATHONGBAO,THONGBAO) VALUES('T5','THONG BAO T5');
INSERT INTO THONGBAO(MATHONGBAO,THONGBAO) VALUES('T6','THONG BAO T6');
INSERT INTO THONGBAO(MATHONGBAO,THONGBAO) VALUES('T7','THONG BAO T7');
INSERT INTO THONGBAO(MATHONGBAO,THONGBAO) VALUES('T8','THONG BAO T8');
/
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
/*
ALTER TABLE DANGKY
DROP CONSTRAINT fk_DK_PC;

ALTER TABLE DANGKY
ADD CONSTRAINT fk_DK_PC FOREIGN KEY (MAHP, HK, NAM, MACT)
REFERENCES PHANCONG(MAHP, HK, NAM, MACT);
*/
--Noi qua SINHVIEN


--MOCK DATA
-- D? li?u cho b?ng DONVI
DELETE FROM DONVI;
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('VPK','CO SO 1',N'Van Phong Khoa', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('HTTT','CO SO 1',N'Bo Mon HTTT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('CNPM','CO SO 1',N'Bo Mon CNPM', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('KHMT','CO SO 1',N'Bo Mon KHMT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('CNTT','CO SO 1',N'Bo Mon CNTT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('TGMT','CO SO 1',N'Bo Mon TGMT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('MMT','CO SO 1',N'Bo Mon MMT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('VT','CO SO 1',N'Vien Thong', NULL);

INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('VPK','CO SO 2',N'Van Phong Khoa', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('HTTT','CO SO 2',N'Bo Mon HTTT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('CNPM','CO SO 2',N'Bo Mon CNPM', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('KHMT','CO SO 2',N'Bo Mon KHMT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('CNTT','CO SO 2',N'Bo Mon CNTT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('TGMT','CO SO 2',N'Bo Mon TGMT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('MMT','CO SO 2',N'Bo Mon MMT', NULL);
INSERT INTO DONVI (MADV,COSO, TENDV, TRGDV) VALUES ('VT','CO SO 2',N'Vien Thong', NULL);

DELETE FROM NHANSU;

--TRUONG KHOA
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV) VALUES ('N000', N'Nguyen Van A', N'Nam', TO_DATE('1990-01-01', 'YYYY-MM-DD'), 500000, '0987654321', N'TRUONGKHOA', 'VPK');
-- TRUONGDONVI
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N001', N'Nguyen Van A', N'Nam', TO_DATE('1990-01-01', 'YYYY-MM-DD'), 500000, '0987654321', N'TRUONGDV', 'HTTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N002', N'Tran Thi B', N'N?', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456489', N'TRUONGDV', 'HTTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N003', N'Nguyen Van C', N'Nam', TO_DATE('1990-01-01', 'YYYY-MM-DD'), 500000, '0987654321', N'TRUONGDV', 'KHMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N004', N'Tran Thi D', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456589', N'TRUONGDV', 'CNTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N005', N'Tran Thi D', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456689', N'TRUONGDV', 'TGMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N006', N'Tran Thi E', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'TRUONGDV', 'MMT','CO SO 1');
--VPK GIAOVU
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV, COSO) VALUES ('N009', N'Tran Van E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIAOVU', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV, COSO) VALUES ('N010', N'Tran Van F', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIAOVU', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV, COSO) VALUES ('N011', N'Tran Van G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV, COSO) VALUES ('N012', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIAOVU', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV, COSO) VALUES ('N013', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIAOVU', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV, COSO) VALUES ('N014', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N015', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N016', N'Tran Lan E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIAOVU', 'VPK','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N017', N'Tran Lan F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIAOVU', 'VPK','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N018', N'Tran Lan G', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N019', N'Tran Lan K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIAOVU', 'VPK','CO SO 2');

--Cac giangvien
--HTTT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N020', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'HTTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N021', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'HTTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N022', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N023', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N024', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'HTTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N025', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'HTTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N026', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N027', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N028', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N029', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT','CO SO 2');
--DVCNPM
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N030', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'CNPM','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N031', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'CNPM','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N032', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N033', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N034', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'CNPM','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N035', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'CNPM','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N036', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N037', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N038', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N039', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNPM','CO SO 2');
--DVKHMT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N040', N'Tran Quang E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'KHMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N041', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'KHMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N042', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N043', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N044', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'KHMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N045', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'KHMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N046', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N047', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N048', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N049', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'KHMT','CO SO 2');
--DVCNTT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N050', N'Tran Quang O', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'CNTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N051', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'CNTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N052', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N053', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N054', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'CNTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N055', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'CNTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N056', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N057', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N058', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N059', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT','CO SO 2');
--DVTGMT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N060', N'Tran Quang O', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'TGMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N061', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'TGMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N062', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N063', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N064', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'GIANGVIEN', 'TGMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N065', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'TGMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N066', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N067', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N068', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N069', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT','CO SO 2');
--DVMMT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N070', N'Tran Quang Q', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457789', N'GIANGVIEN', 'MMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N071', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'MMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N072', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N073', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N074', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457789', N'GIANGVIEN', 'MMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N075', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'MMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N076', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N077', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N078', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N079', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'MMT','CO SO 2');
--DVVT
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N080', N'Tran Quang T', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456889', N'GIANGVIEN', 'VT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N081', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458889', N'GIANGVIEN', 'VT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N082', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N083', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N084', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458889', N'GIANGVIEN', 'VT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N085', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458889', N'GIANGVIEN', 'VT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N086', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N087', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N088', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N089', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'VT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N090', N'Tran Quang ANDREE', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456889', N'GIANGVIEN', 'VT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N091', N'Tran Anh WON', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458889', N'GIANGVIEN', 'VT','CO SO 1');
--NHANVIENCOBAN
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N092', N'Tran Quang Q', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123459989', N'NHANVIENCOBAN', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N093', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123459889', N'NHANVIENCOBAN', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N094', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N095', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N096', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123459989', N'NHANVIENCOBAN', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N097', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123459889', N'NHANVIENCOBAN', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N098', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N099', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N100', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N102', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'NHANVIENCOBAN', 'VPK','CO SO 2');
--GIANGVIEN
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N103', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'HTTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N104', N'Tran Anh E', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457789', N'GIANGVIEN', 'CNPM','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N105', N'Tran Anh F', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123457889', N'GIANGVIEN', 'KHMT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N106', N'Tran Anh G', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'CNTT','CO SO 1');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N107', N'Tran Anh K', N'Nam', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123458989', N'GIANGVIEN', 'TGMT','CO SO 1');

INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N108', N'Nguyen Van F', N'Nam', TO_DATE('1990-01-01', 'YYYY-MM-DD'), 500000, '0987654321', N'TRUONGDV', 'HTTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N109', N'Tran Thi H', N'N?', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456489', N'TRUONGDV', 'CNPM','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N110', N'Nguyen Van J', N'Nam', TO_DATE('1990-01-01', 'YYYY-MM-DD'), 500000, '0987654321', N'TRUONGDV', 'KHMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N111', N'Tran Thi K', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456589', N'TRUONGDV', 'CNTT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N112', N'Tran Thi R', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456689', N'TRUONGDV', 'TGMT','CO SO 2');
INSERT INTO NHANSU (MANV, HOTEN, PHAI, NGSINH, PHUCAP, DIENTHOAI, VAITRO, MADV,COSO) VALUES ('N113', N'Tran Thi V', N'Nu', TO_DATE('1995-02-02', 'YYYY-MM-DD'), 400000, '0123456789', N'TRUONGDV', 'MMT','CO SO 2');

SELECT * FROM NHANSU;
--Truong Don Vi
UPDATE DONVI SET donvi.trgdv = 'N001' WHERE donvi.madv = 'VPK' AND DONVI.COSO='CO SO 1';
UPDATE DONVI SET donvi.trgdv = 'N002' WHERE donvi.madv = 'HTTT' AND DONVI.COSO='CO SO 1';
UPDATE DONVI SET donvi.trgdv = 'N003' WHERE donvi.madv = 'CNPM' AND DONVI.COSO='CO SO 1';
UPDATE DONVI SET donvi.trgdv = 'N004' WHERE donvi.madv = 'KHMT' AND DONVI.COSO='CO SO 1';
UPDATE DONVI SET donvi.trgdv = 'N005' WHERE donvi.madv = 'CNTT' AND DONVI.COSO='CO SO 1';
UPDATE DONVI SET donvi.trgdv = 'N006' WHERE donvi.madv = 'TGMT' AND DONVI.COSO='CO SO 1';

UPDATE DONVI SET donvi.trgdv = 'N108' WHERE donvi.madv = 'VPK' AND DONVI.COSO='CO SO 2';
UPDATE DONVI SET donvi.trgdv = 'N109' WHERE donvi.madv = 'HTTT' AND DONVI.COSO='CO SO 2';
UPDATE DONVI SET donvi.trgdv = 'N110' WHERE donvi.madv = 'CNPM' AND DONVI.COSO='CO SO 2';
UPDATE DONVI SET donvi.trgdv = 'N111' WHERE donvi.madv = 'KHMT' AND DONVI.COSO='CO SO 2';
UPDATE DONVI SET donvi.trgdv = 'N112' WHERE donvi.madv = 'CNTT' AND DONVI.COSO='CO SO 2';
UPDATE DONVI SET donvi.trgdv = 'N113' WHERE donvi.madv = 'TGMT' AND DONVI.COSO='CO SO 2';
SELECT * FROM DONVI;

-- D? li?u cho b?ng SINHVIEN
DELETE FROM SINHVIEN;
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S001', N'Pham Van C', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CLC', 'KHMT', 80, 7.5,'CO SO 2');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S002', N'Ly Thi D', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'CQ', 'HTTT', 75, 8.0,'CO SO 1');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S003', N'Pham Van E', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CTTT', 'CNTT', 80, 7.5,'CO SO 2');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S004', N'Ly Thi E', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'VP', 'TGMT', 75, 8.0,'CO SO 1');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S005', N'Pham Van F', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CQ', 'MMT', 80, 7.5,'CO SO 2');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S006', N'Ly Thi F', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'CLC', 'KHMT', 75, 8.0,'CO SO 1');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S007', N'Pham Van G', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CTTT', 'HTTT', 80, 7.5,'CO SO 2');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S008', N'Ly Thi G', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'CQ', 'CNTT', 75, 8.0,'CO SO 1');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S009', N'Pham Van H', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CLC', 'TGMT', 80, 7.5,'CO SO 2');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S010', N'Ly Thi H', N'Nu', TO_DATE('1998-04-04', 'YYYY-MM-DD'), N'Ho Chi Minh', '0976543210', 'CLC', 'MMT', 75, 8.0,'CO SO 1');
INSERT INTO SINHVIEN (MASV, HOTEN, PHAI, NGSINH, DIACHI, DIENTHOAI, MACT, MANGANH, SOTCTL, DTBTL,COSO) VALUES ('S011', N'Pham Van E', N'Nam', TO_DATE('1999-03-03', 'YYYY-MM-DD'), N'Ha Noi', '0981234567', 'CTTT', 'HTTT', 80, 7.5,'CO SO 2');
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
alter session set "_ORACLE_SCRIPT"=true;
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







