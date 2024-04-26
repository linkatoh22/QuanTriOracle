-- Dang nhap ADMINQL
-- 1. Kich hoat viec ghi nhat ky he thong 
alter system set audit_trail=db,extended scope=spfile;
shutdown immediate;
startup

-- 2. Thuc hien ghi nhat ky he thong dung Standard audit
-- Kiem soat cac user tren tat ca cac table
AUDIT ALL ON ADMINQL.NHANSU BY ACCESS;
AUDIT ALL ON ADMINQL.SINHVIEN BY ACCESS;
AUDIT ALL ON ADMINQL.DONVI BY ACCESS;
AUDIT ALL ON ADMINQL.HOCPHAN BY ACCESS;
AUDIT ALL ON ADMINQL.KHMO BY ACCESS;
AUDIT ALL ON ADMINQL.PHANCONG BY ACCESS;
AUDIT ALL ON ADMINQL.DANGKY BY ACCESS;

-- Kiem soat thuc thi procedure
AUDIT EXECUTE PROCEDURE BY ACCESS;

-- Kiem soat views
AUDIT SELECT ON ADMINQL.VIEW_GIANG_VIEN_PHANCONG BY ACCESS;
AUDIT SELECT ON ADMINQL.VIEW_TRUONG_DV_PHANCONGGIANGDAY BY ACCESS;

-- Theo doi cac hanh vi thanh cong
AUDIT ALL WHENEVER SUCCESSFUL;

-- Theo doi cac hanh vi khong thanh cong
AUDIT ALL WHENEVER NOT SUCCESSFUL;

-- Kiem tra audit
SELECT extended_timestamp, username, owner, obj_name, action_name, sql_text FROM dba_audit_trail;
