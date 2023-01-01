create database DB_HSK
use DB_HSK

create table SinhVien (
MaSV varchar (20) primary key NOT NULL ,
TenSV nvarchar (40) NOT NULL , 
GioiTinh nvarchar (3) NOT NULL,
NgaySinh date NOT NULL,
Email varchar (40) NOT NULL,
CCCD varchar(12) unique NOT NULL,
MaLop varchar(20) NOT NULL,
) ; 

create proc themSinhVien (@MaSV varchar(20), @TenSV nvarchar(40), @GioiTinh nvarchar(3), @NgaySinh date, @Email varchar(40),@CCCD varchar(12),@MaLop varchar(20))
as
begin
insert into SinhVien
	values (@MaSV, @TenSV, @GioiTinh, @NgaySinh, @Email,@CCCD,@MaLop)
end

create table Diem (
MaSV varchar (20) NOT NULL ,
MaLHP varchar (20) NOT NULL , 
DiemCC float NOT NULL,
DiemGK float NOT NULL,
DiemThi float NOT NULL,
) ; 
ALTER TABLE Diem
ADD CONSTRAINT CK_DiemCC CHECK (0 <= DiemCC and DiemCC <= 10) ,
    CONSTRAINT CK_DiemGK CHECK (0 <= DiemGK and DiemGK <= 10) ,
	CONSTRAINT CK_DiemThi CHECK (0 <= DiemThi and DiemThi <= 10);

ALTER TABLE Diem
ADD CONSTRAINT PK_Diem PRIMARY KEY(MaSV,MaLHP),
    CONSTRAINT FK_Diem_SinhVien FOREIGN KEY(MaSV) REFERENCES SinhVien(MaSV),
	CONSTRAINT FK_Diem_LopHP FOREIGN KEY(MaLHP) REFERENCES LopHocPhan(MaLHP);




create table MonHoc (
MaMon varchar (20) primary key NOT NULL ,
TenMon nvarchar (40) NOT NULL , 
SoTinChi int NOT NULL
) ;

create table GiangVien (
MaGV varchar (20) primary key NOT NULL ,
TenGV nvarchar (40) NOT NULL ,
SDT varchar(10) NOT NULL,
Email varchar (40) NOT NULL,
CCCD varchar(12) unique NOT NULL,
) ;

create table LopHanhChinh (
MaLop varchar (20) primary key NOT NULL ,
TenLop varchar (20) NOT NULL , 
) ;

create table LopHocPhan (
MaLHP varchar (20) primary key NOT NULL ,
MaMon varchar (20) NOT NULL ,
MaGV varchar(20) NOT NULL,
ThoiGianBatDau date NOT NULL,
ThoiGianKetThuc date NOT NULL,
) ;
ALTER TABLE LopHocPhan
ADD CONSTRAINT CK_Time CHECK (ThoiGianBatDau <= ThoiGianKetThuc) ;

select * from GiangVien
select * from LopHanhChinh
select * from LopHocPhan where ThoiGianBatDau between '1/1/2022' and '1/1/2022'
select * from Diem
select * from MonHoc
select * from SinhVien


Alter PROCEDURE Delete_SV
@MaSV VARCHAR(20)
AS 
	BEGIN
	DELETE Diem WHERE MaSV = @MaSV
	DELETE SinhVien WHERE MaSV = @MaSV
	DELETE DangNhap WHERE TaiKhoan = @MaSV
	END

create PROCEDURE Update_SV
@MaSV VARCHAR(20),@TenSV NVARCHAR(40),@GioiTinh NVARCHAR(3),
@NgaySinh DATE,@Email NVARCHAR(40),@CCCD VARCHAR (12),@Malop VARCHAR(20)
as
BEGIN
	 UPDATE SinhVien
	 SET 
	 MaSV = @MaSV,TenSV=@TenSV,GioiTinh=@GioiTinh,NgaySinh=@NgaySinh,Email=@Email,CCCD=@CCCD,MaLop=@MaLop
	 Where MaSV = @MaSV
end

Alter view showViewAllSV
as
Select a.MaSV as[Mã Sinh Viên],a.TenSV as[Tên Sinh Viên],a.GioiTinh as[Giới Tính], a.NgaySinh as[Ngày Sinh], a.CCCD as[CCCD],
a.Email as[Email], b.TenLop as[Lớp Hành Chính]
from SinhVien a Join LopHanhChinh b on b.MaLop =a.MaLop

-- Bảng Lớp Hành Chính
create proc themLopHC (@MaLop varchar (20),@TenLop varchar (20))
as
begin
insert into LopHanhChinh
	values (@MaLop,@TenLop)
end

create PROCEDURE Update_LopHC
@Malop VARCHAR(20),
@TenLop varchar (20)
as
BEGIN
	 UPDATE LopHanhChinh
	 SET 
	 MaLop=@MaLop, TenLop=@TenLop
	 Where MaLop=@MaLop
end

CREATE PROCEDURE Delete_LopHC
@MaLop VARCHAR(20)
AS 
	BEGIN
	DELETE SinhVien WHERE MaLop = @MaLop
	DELETE LopHanhChinh WHERE MaLop = @MaLop
	END

-- Bảng Môn Học
create proc themMonHoc (@MaMon varchar (20),@TenMon nvarchar (40), @SoTinChi int)
as
begin
insert into MonHoc
	values (@MaMon,@TenMon, @SoTinChi)
end

create PROCEDURE Update_MonHoc
@MaMon VARCHAR(20),
@TenMon nvarchar (40),
@SoTinChi int
as
BEGIN
	 UPDATE MonHoc
	 SET 
	 MaMon=@MaMon, TenMon=@TenMon, SoTinChi=@SoTinChi
	 Where MaMon=@MaMon
end

CREATE PROCEDURE Delete_MonHoc
@MaMon VARCHAR(20)
AS 
	BEGIN
	DELETE LopHocPhan WHERE MaMon = @MaMon
	DELETE MonHoc WHERE MaMon = @MaMon
	END

-- Bảng Giảng Viên
create proc themGiangVien (@MaGV varchar(20), @TenGV nvarchar(40), @SDT varchar(10), @Email varchar(40),@CCCD varchar(12))
as
begin
insert into GiangVien
	values (@MaGV, @TenGV, @SDT, @Email,@CCCD)
end

alter PROCEDURE Delete_GV
@MaGV VARCHAR(20)
AS 
	BEGIN
	DELETE LopHocPhan WHERE MaGV = @MaGV
	DELETE GiangVien WHERE MaGV = @MaGV
	DELETE DangNhap WHERE TaiKhoan = @MaGV
	END

create PROCEDURE Update_GV
@MaGV VARCHAR(20),@TenGV NVARCHAR(40),@SDT VARCHAR(10),
@Email NVARCHAR(40),@CCCD VARCHAR (12)
as
BEGIN
	 UPDATE GiangVien
	 SET 
	 MaGV = @MaGV,TenGV=@TenGV,SDT=@SDT,Email=@Email,CCCD=@CCCD
	 Where MaGV = @MaGV
end

-- Bảng Lớp Học Phần
create proc themLopHocPhan (@MaLHP varchar (20), @MaMon varchar (20), @MaGV varchar(20), @ThoiGianBatDau date,@ThoiGianKetThuc date)
as
begin
insert into LopHocPhan
	values (@MaLHP, @MaMon, @MaGV, @ThoiGianBatDau, @ThoiGianKetThuc)
end

ALTER PROCEDURE Delete_LopHocPhan
@MaLHP VARCHAR(20)
AS 
	BEGIN
	DELETE Diem WHERE MaLHP = @MaLHP
	DELETE LopHocPhan WHERE MaLHP = @MaLHP
	END

create PROCEDURE Update_LopHocPhan(@MaLHP varchar (20), @MaMon varchar (20), @MaGV varchar(20), @ThoiGianBatDau date,@ThoiGianKetThuc date)
as
BEGIN
	 UPDATE LopHocPhan
	 SET 
	 MaLHP = @MaLHP,MaMon=@MaMon,MaGV=@MaGV,ThoiGianBatDau=@ThoiGianBatDau,ThoiGianKetThuc=@ThoiGianKetThuc
	 Where MaLHP = @MaLHP
end

create view showViewAllLopHocPhan
as
Select a.MaLHP as[Mã Lớp Học Phần], b.TenMon as[Môn Học],a.MaGV as[Mã Giảng Viên],a.ThoiGianBatDau as[Thời Gian Bắt Đầu], a.ThoiGianKetThuc as[Thời Gian Kết Thúc]
from LopHocPhan a Join MonHoc b on b.MaMon =a.MaMon

--Bảng điểm
CREATE PROCEDURE Delete_Diem
@MaLHP VARCHAR(20),
@MaSV VARCHAR(20)
AS 
	BEGIN
	DELETE Diem WHERE MaLHP = @MaLHP and MaSV=@MaSV
	END

create proc themDiem (@MaSV varchar (20), @MaLHP varchar (20),@DiemCC  float ,@DiemGK  float ,@DiemThi  float )
as
begin
insert into Diem
	values (@MaSV ,@MaLHP,@DiemCC,@DiemGK,@DiemThi)
end
exec themDiem 'SV05','AB02',1.2,1.5,1.6
alter PROCEDURE Update_Diem(@MaSV varchar (20), @MaLHP varchar (20),@DiemCC  float ,@DiemGK  float ,@DiemThi  float)
as
BEGIN
	 UPDATE Diem
	 SET DiemCC=@DiemCC ,DiemGK=@DiemGK,DiemThi=@DiemThi
	 Where MaSV = @MaSV and MaLHP = @MaLHP
end

--test check

select * from LopHocPhan where MaLHP='AB01'
select * from Diem, LopHocPhan,MonHoc where MonHoc.MaMon=LopHocPhan.MaMon and Diem.MaLHP=LopHocPhan.MaLHP and Diem.MaSV='SV01' and MonHoc.TenMon=N'Thể chất học phần 1'

select * from LopHocPhan


create table DangNhap (
TaiKhoan varchar (20) primary key NOT NULL ,
MatKhau varchar (20) NOT NULL , 
Quyen varchar (20)
) ;
alter table DangNhap
add TrangThai int;

--------------------------------------------------------
alter table DangNhap
drop column LastLogin datetime

alter PROCEDURE updatelastlogin
@TaiKhoan VARCHAR(20),
@lastlogin datetime
AS 
BEGIN
	 UPDATE DangNhap
	 SET LastLogin=@lastlogin
	 Where TaiKhoan=@TaiKhoan
END
-----------------------------
--BẢng đăng nhập
CREATE PROCEDURE Delete_DangNhap
@TaiKhoan VARCHAR(20)
AS 
	BEGIN
	DELETE DangNhap WHERE TaiKhoan = @TaiKhoan
	END

alter proc themDangNhap (@TaiKhoan varchar (20), @MatKhau varchar (20),@Quyen  varchar(20), @TrangThai int)
as
begin
insert into DangNhap
	values (@TaiKhoan ,@MatKhau,@Quyen,@TrangThai)
end

alter PROCEDURE Update_DangNhap(@TaiKhoan varchar (20), @MatKhau varchar (20),@Quyen  varchar(20), @TrangThai int)
as
BEGIN
	 UPDATE DangNhap
	 SET Quyen=@Quyen, MatKhau=@MatKhau, TrangThai=@TrangThai
	 Where TaiKhoan=@TaiKhoan
end

create PROCEDURE Update_MK(@TaiKhoan varchar (20),@MatKhauNew varchar (20))
as
BEGIN
	 UPDATE DangNhap
	 SET MatKhau=@MatKhauNew
	 Where TaiKhoan=@TaiKhoan
end

create PROCEDURE Khoa_DangNhap(@TaiKhoan varchar (20), @TrangThai int)
as
BEGIN
	 UPDATE DangNhap
	 SET TrangThai=@TrangThai
	 Where TaiKhoan=@TaiKhoan
end

alter view diemcaNhan
as
select distinct Diem.MaSV,SinhVien.TenSV,MonHoc.TenMon,MonHoc.SoTinChi,LopHocPhan.MaLHP,LopHocPhan.MaGV,GiangVien.TenGV,Diem.DiemCC,Diem.DiemGK,Diem.DiemThi 
from Diem inner join SinhVien on Diem.MaSV=SinhVien.MaSV 
inner join LopHocPhan on Diem.MaLHP=LopHocPhan.MaLHP 
inner join MonHoc on MonHoc.MaMon=LopHocPhan.MaMon 
inner join LopHanhChinh on SinhVien.MaLop=LopHanhChinh.MaLop 
inner join GiangVien on GiangVien.MaGV=LopHocPhan.MaGV

create view GiangDay
as
select distinct LopHocPhan.MaGV,GiangVien.TenGV,MonHoc.TenMon,LopHocPhan.MaLHP,LopHocPhan.ThoiGianBatDau,LopHocPhan.ThoiGianKetThuc
from Diem inner join SinhVien on Diem.MaSV=SinhVien.MaSV 
inner join LopHocPhan on Diem.MaLHP=LopHocPhan.MaLHP 
inner join MonHoc on MonHoc.MaMon=LopHocPhan.MaMon 
inner join LopHanhChinh on SinhVien.MaLop=LopHanhChinh.MaLop 
inner join GiangVien on GiangVien.MaGV=LopHocPhan.MaGV

alter view a
as
select Diem.MaSV,  LopHocPhan.MaMon, MonHoc.TenMon,MonHoc.SoTinChi, LopHocPhan.MaLHP,LopHocPhan.MaGV,GiangVien.TenGV,Diem.DiemCC,Diem.DiemGK,Diem.DiemThi,
Max(Diem.DiemCC*0.1+Diem.DiemGK*0.2+Diem.DiemThi*0.7) AS [TB Môn],
sum(((Diem.DiemCC*0.1+Diem.DiemGK*0.2+Diem.DiemThi*0.7)/10)*4) as[Hệ số 4],
sum(MonHoc.SoTinChi*((Diem.DiemCC*0.1+Diem.DiemGK*0.2+Diem.DiemThi*0.7)/10)*4) as[Nhân]
from Diem inner join SinhVien on Diem.MaSV=SinhVien.MaSV 
inner join LopHocPhan on Diem.MaLHP=LopHocPhan.MaLHP 
inner join MonHoc on MonHoc.MaMon=LopHocPhan.MaMon 
inner join LopHanhChinh on SinhVien.MaLop=LopHanhChinh.MaLop 
inner join GiangVien on GiangVien.MaGV=LopHocPhan.MaGV
group by Diem.MaSV,  LopHocPhan.MaMon, MonHoc.TenMon,MonHoc.SoTinChi, LopHocPhan.MaLHP,LopHocPhan.MaGV,GiangVien.TenGV,Diem.DiemCC,Diem.DiemGK,Diem.DiemThi
Having Max(Diem.DiemCC*0.1+Diem.DiemGK*0.2+Diem.DiemThi*0.7)>4

create view ab
as
select Diem.MaSV,  LopHocPhan.MaMon, MonHoc.TenMon,MonHoc.SoTinChi, LopHocPhan.MaLHP,LopHocPhan.MaGV,GiangVien.TenGV,Diem.DiemCC,Diem.DiemGK,Diem.DiemThi,
Min(Diem.DiemCC*0.1+Diem.DiemGK*0.2+Diem.DiemThi*0.7) AS [TB Môn],
sum(((Diem.DiemCC*0.1+Diem.DiemGK*0.2+Diem.DiemThi*0.7)/10)*4) as[Hệ số 4],
sum(MonHoc.SoTinChi*((Diem.DiemCC*0.1+Diem.DiemGK*0.2+Diem.DiemThi*0.7)/10)*4) as[Nhân], LopHocPhan.ThoiGianKetThuc
from Diem inner join SinhVien on Diem.MaSV=SinhVien.MaSV 
inner join LopHocPhan on Diem.MaLHP=LopHocPhan.MaLHP 
inner join MonHoc on MonHoc.MaMon=LopHocPhan.MaMon 
inner join LopHanhChinh on SinhVien.MaLop=LopHanhChinh.MaLop 
inner join GiangVien on GiangVien.MaGV=LopHocPhan.MaGV
group by LopHocPhan.ThoiGianKetThuc,Diem.MaSV,  LopHocPhan.MaMon, MonHoc.TenMon,MonHoc.SoTinChi, LopHocPhan.MaLHP,LopHocPhan.MaGV,GiangVien.TenGV,Diem.DiemCC,Diem.DiemGK,Diem.DiemThi
Having MIn(Diem.DiemCC*0.1+Diem.DiemGK*0.2+Diem.DiemThi*0.7)<4

alter view b
as
select a.MaSV, sum(a.SoTinChi) as[Tổng Tín Chỉ Tích Lũy], sum(a.[Nhân]) as[Tổng Điểm]
from a
group by a.MaSV


insert into GiangVien
values ('GV09', N'Nguyễn Thanh Tùng', '0359124588', 'tung@gmail.com', '001201123123'),
('GV10', N'Trần Tử Vân Anh', '0924568795', 'v1nnh11@gmail.com', '001201789789'),
('GV11', N'Nguyễn Xuân Nghĩa', '0889564257', '141abc@gmail.com', '001201963852'),
('GV12', N'Lê Minh Tiến', '0993654789', 'tien456@gmail.com', '001201147258'),
('GV13', N'Bùi Nhựt Phong', '0368954321', 'phongbvb@gmail.com', '159357301401'),
('GV14', N'Đỗ Hồng Quân', '0369874512', 'quanp123@gmail.com', '123789301401'),
('GV15', N'Nguyễn Đức Tuấn', '0359567845', 'tuannt@gmail.com', '669966301401'),
('GV16', N'Huỳnh Lê Anh Huy', '0321304588', 'huydz01@gmail.com', '123000301401'),
('GV17', N'Huỳnh Minh Hiền', '0300123588', 'hien@gmail.com', '001654789401'),
('GV18', N'Trần Thị Thanh Trà', '0359874658', 'trathanh1@gmail.com', '002345671401'),
('GV19', N'Phan Thị Mai Quyên', '0999875886', 'quyenami@gmail.com', '001234501401'),
('GV20', N'Tào Văn Ân', '0368216810', 'an1n12345@gmail.com', '001478301401'),
('GV21', N'Vũ Đức Thưởng', '0989564257', 'thuong@gmail.com', '001201963899'),
('GV22', N'Nguyễn Tuấn Anh', '0793654789', 'tuananh@gmail.com', '001201147888'),
('GV23', N'Huỳnh Thanh Nhàn', '0168954321', 'thanhnhan@gmail.com', '159357301444'),
('GV24', N'Nguyễn Thị Hoài My', '0969874512', 'hoaimy@gmail.com', '123789301333'),
('GV25', N'Tiêu Tuyết Nhung', '0959567845', 'tuyetnhung@gmail.com', '669966307891'),
('GV26', N'Mai Thị Mỹ Nhung', '0921304588', 'mynhung01@gmail.com', '123000304567'),
('GV27', N'Hà Ngọc Thanh', '0800123588', 'ngocthanh@gmail.com', '001654781234'),
('GV28', N'Nguyễn Trung Tính ', '0159874658', 'trungtinh1@gmail.com', '002345671331'),
('GV29', N'Nguyễn Thanh Thảo', '0399875886', 'thanhthao@gmail.com', '001284501401'),
('GV30', N'Thái Hoàng Như Ý ', '0868216810', 'nhuy45@gmail.com', '001478901401'),
('GV31', N'8 Tôn Thất Minh Khang', '0389564257', 'minhkhangabc@gmail.com', '001311963852'),
('GV32', N'Nguyễn Vũ Gia Yên ', '0393654789', 'giayen6@gmail.com', '001201147968'),
('GV33', N'Đinh Duy Khoa ', '0968954321', 'pkhoabvb@gmail.com', '150357301401'),
('GV34', N'Nguyễn Thuỳ Trang', '0869874512', 'trangp123@gmail.com', '003789301401'),
('GV35', N'Trần Minh Hoàng ', '0159567845', 'minhoang@gmail.com', '019966301401');

insert into LopHanhChinh
values 
('L12', '20A02'),
('L13', '20A03'),
('L14', '20A04'),
('L15', '20A05'),
('L21', '21A01'),
('L22', '21A02'),
('L23', '21A03'),
('L24', '21A04'),
('L25', '21A05'),
('L31', '18A01'),
('L32', '18A02'),
('L33', '18A03'),
('L34', '18A04'),
('L35', '18A05');

insert into SinhVien values('SV10', N'	Lê Thị Ngọc Ánh', N'Nữ','01/09/2001','ngocanh11@gmail.com', '001201789789', 'L01');
insert into SinhVien values('SV11', N'Nguyễn Ngọc Chiến', N'Nam','08/19/2001', 'ngocchien222@gmail.com', '001201963852', 'L01');
insert into SinhVien values('SV12', N'Phạm Đỗ Duy', N'Nam','07/29/2001', 'doduy@gmail.com', '001201147258', 'L02');
insert into SinhVien values('SV13', N'Nguyễn Văn Úc', N'Nam','06/30/2001','vanuc@gmail.com', '159357301401', 'L02');
insert into SinhVien values('SV14', N'Trần Tiến Đạt', N'Nam','05/31/2001', 'tiendat@gmail.com', '123789301401', 'L02');
insert into SinhVien values('SV15', N'Hà Thị Hạnh', N'Nữ','11/04/2002', 'hahanh@gmail.com', '669966301401', 'L01');
insert into SinhVien values('SV16', N'Trần Thu Phương', N'Nữ','06/03/2002', 'thuphuong@gmail.com', '123000301401', 'L01');
insert into SinhVien values('SV17', N'Phjam Thu Hà', N'Nữ','11/02/2002', 'hanguyen@gmail.com', '001654789401', 'L01');
insert into SinhVien values('SV18', N'Nguyễn Thị Ánh Tuyết', N'Nữ','10/06/2001', 'anhtuyet@gmail.com', '002345671401', 'L04');
insert into SinhVien values('SV19', N'Phạm Bích Ngọc', N'Nữ','02/24/2002','bichngoc@gmail.com', '001234501401', 'L02');
insert into SinhVien values('SV20', N'Nguyễn Như Quỳnh', N'Nữ','01/26/2002', 'nhuquynhf@gmail.com', '001128301401', 'L02');
insert into SinhVien values('SV21', N'Lương Thu Hoài', N'Nữ','01/14/2002', 'thuhoai@gmail.com', '001445301401', 'L02');
insert into SinhVien values('SV22', N'Nguyễn Minh Hiền', N'Nữ','03/30/1999', 'minhhien@gmail.com', '000478301401', 'L03');
insert into SinhVien values('SV23', N'Nguyễn Văn Lập', N'Nam','05/27/1999', 'vanlaap@gmail.com', '001238301401', 'L05');
insert into SinhVien values('SV24', N'Trần Bá Nghiệp', N'Nam','11/17/1999', 'banghiejp@gmail.com', '001448301401', 'L05');
insert into SinhVien values('SV25', N'Lê Ngọc Phan', N'Nam','01/12/1999', 'ngoocpah@gmail.com', '001478341401', 'L04');
insert into SinhVien values('SV27', N'Nguyễn Thi Ngọc',N'Nữ', '09/21/1999', 'thingooc@gmail.com', '001474401401', 'L03');
insert into SinhVien values('SV28', N'Lê Văn Lợi', N'Nam','06/23/1999', 'levanloi@gmail.com', '001478301421', 'L04');
insert into SinhVien values('SV29', N'Nguyễn Văn Hưng', N'Nam','11/07/1999', 'nguyenvanhung@gmail.com', '001278301401', 'L04');
insert into SinhVien values('SV30', N'	Nguyễn Thị Yến Vy', N'Nữ','08/06/1999', 'vyvyvy@gmail.com', '001478801401', 'L03');
insert into SinhVien values('SV31', N'Đỗ Kim Luân', N'Nam','08/09/2001', 'kimluan222@gmail.com', '001247963852', 'L05');
insert into SinhVien values('SV32', N'Nguyễn Huỳnh Minh Nhật ', N'Nam','07/26/2001', 'minhnhat@gmail.com', '001207847258', 'L05');
insert into SinhVien values('SV33', N'Lê Quang Vinh ', N'Nam','06/10/2001','quangvinh@gmail.com', '159357301781', 'L03');
insert into SinhVien values('SV34', N'Bùi Ngọc Tú ', N'Nam','05/30/2001', 'ngoctu@gmail.com', '223789301401', 'L03');
insert into SinhVien values('SV35', N'Nguyễn Thị Kiều Nương', N'Nữ','12/04/2002', 'kieunuong@gmail.com', '689966301401', 'L03');
insert into SinhVien values('SV36', N'Nguyễn Cao Mỹ Anh', N'Nữ','09/03/2002', 'myanh111@gmail.com', '123010301401', 'L05');
insert into SinhVien values('SV37', N'Võ Bạch Ngọc', N'Nữ','11/22/2002', 'bachngoc123@gmail.com', '001654779401', 'L05');
insert into SinhVien values('SV38', N'Lê Nguyễn Tường Vy', N'Nữ','10/16/2001', 'tuongvyxinhgai@gmail.com', '001345671401', 'L05');
insert into SinhVien values('SV39', N'Lê Thị Vân ', N'Nữ','02/24/2002','thivan999@gmail.com', '001234501801', 'L04');
insert into SinhVien values('SV40', N'Nguyễn Thị Thu Thủy', N'Nữ','11/26/2002', 'thuthuy@gmail.com', '001178301401', 'L04');
insert into SinhVien values('SV41', N'Nguyễn An Giang', N'Nữ','01/19/2002', 'angiang@gmail.com', '001445300401', 'L04');
insert into SinhVien values('SV42', N'Nguyễn Thị Thanh Tú ', N'Nữ','03/31/1999', 'thanhtu222@gmail.com', '000178301401', 'L03');
insert into SinhVien values('SV43', N'Nguyễn Trọng Trí', N'Nam','08/27/1999', 'trongtri@gmail.com', '008278301401', 'L01');
insert into SinhVien values('SV44', N'Trương Minh Sĩ', N'Nam','01/17/1999', 'sidz@gmail.com', '001448301801', 'L01');
insert into SinhVien values('SV45', N'Nguyễn Thanh Thiện', N'Nam','01/01/1999', 'thanhthien@gmail.com', '008478341401', 'L04');
insert into SinhVien values('SV47', N'Trần Huỳnh Trúc',N'Nữ', '09/11/1999', 'huynhtruc@gmail.com', '001474481401', 'L02');
insert into SinhVien values('SV48', N'Tiền Đào Khánh Duy', N'Nam','06/23/1999', 'khanhduy@gmail.com', '001474301421', 'L02');
insert into SinhVien values('SV49', N'Mai Đức Tiến ', N'Nam','04/07/1999', 'ductien@gmail.com', '001278301001', 'L03');
insert into SinhVien values('SV50', N'Thân Thị Mỹ Dung', N'Nữ','03/06/1999', 'mydung69@gmail.com', '001478*01401', 'L01');

insert into DangNhap values('SV11', 'SV11','SinhVien',1);
insert into DangNhap values('SV12', 'SV12','SinhVien',1);
insert into DangNhap values('SV13', 'SV13','SinhVien',1);
insert into DangNhap values('SV14', 'SV14','SinhVien',1);
insert into DangNhap values('SV15', 'SV15','SinhVien',1);
insert into DangNhap values('SV16', 'SV16','SinhVien',1);
insert into DangNhap values('SV17', 'SV17','SinhVien',1);
insert into DangNhap values('SV18', 'SV18','SinhVien',1);
insert into DangNhap values('SV19', 'SV19','SinhVien',1);
insert into DangNhap values('SV20', 'SV20','SinhVien',1);
insert into DangNhap values('SV21', 'SV21','SinhVien',1);
insert into DangNhap values('SV22', 'SV22','SinhVien',1);
insert into DangNhap values('SV23', 'SV23','SinhVien',1);
insert into DangNhap values('SV24', 'SV24','SinhVien',1);
insert into DangNhap values('SV25', 'SV25','SinhVien',1);
insert into DangNhap values('SV26', 'SV26','SinhVien',1);
insert into DangNhap values('SV27', 'SV27','SinhVien',1);
insert into DangNhap values('SV28', 'SV28','SinhVien',1);
insert into DangNhap values('SV29', 'SV29','SinhVien',1);
insert into DangNhap values('SV30', 'SV30','SinhVien',1);
insert into DangNhap values('SV31', 'SV31','SinhVien',1);
insert into DangNhap values('SV32', 'SV32','SinhVien',1);
insert into DangNhap values('SV33', 'SV33','SinhVien',1);
insert into DangNhap values('SV34', 'SV34','SinhVien',1);
insert into DangNhap values('SV35', 'SV35','SinhVien',1);
insert into DangNhap values('SV36', 'SV36','SinhVien',1);
insert into DangNhap values('SV37', 'SV37','SinhVien',1);
insert into DangNhap values('SV38', 'SV38','SinhVien',1);
insert into DangNhap values('SV39', 'SV39','SinhVien',1);
insert into DangNhap values('SV40', 'SV40','SinhVien',1);
insert into DangNhap values('SV41', 'SV41','SinhVien',1);
insert into DangNhap values('SV42', 'SV42','SinhVien',1);
insert into DangNhap values('SV43', 'SV43','SinhVien',1);
insert into DangNhap values('SV44', 'SV44','SinhVien',1);
insert into DangNhap values('SV45', 'SV45','SinhVien',1);
insert into DangNhap values('SV46', 'SV46','SinhVien',1);
insert into DangNhap values('SV47', 'SV47','SinhVien',1);
insert into DangNhap values('SV48', 'SV48','SinhVien',1);
insert into DangNhap values('SV49', 'SV49','SinhVien',1);
insert into DangNhap values('SV50', 'SV50','SinhVien',1);

insert into DangNhap values('GV11', 'GV11','SinhVien',1);
insert into DangNhap values('GV12', 'GV12','SinhVien',1);
insert into DangNhap values('GV13', 'GV13','SinhVien',1);
insert into DangNhap values('GV14', 'GV14','SinhVien',1);
insert into DangNhap values('GV15', 'GV15','SinhVien',1);
insert into DangNhap values('GV16', 'GV16','SinhVien',1);
insert into DangNhap values('GV17', 'GV17','SinhVien',1);
insert into DangNhap values('GV18', 'GV18','SinhVien',1);
insert into DangNhap values('GV19', 'GV19','SinhVien',1);
insert into DangNhap values('GV20', 'GV20','SinhVien',1);
insert into DangNhap values('GV21', 'GV21','SinhVien',1);
insert into DangNhap values('GV22', 'GV22','SinhVien',1);
insert into DangNhap values('GV23', 'GV23','SinhVien',1);
insert into DangNhap values('GV24', 'GV24','SinhVien',1);
insert into DangNhap values('GV25', 'GV25','SinhVien',1);
insert into DangNhap values('GV26', 'GV26','SinhVien',1);
insert into DangNhap values('GV27', 'GV27','SinhVien',1);
insert into DangNhap values('GV28', 'GV28','SinhVien',1);
insert into DangNhap values('GV29', 'GV29','SinhVien',1);
insert into DangNhap values('GV30', 'GV30','SinhVien',1);
insert into DangNhap values('GV31', 'GV31','SinhVien',1);
insert into DangNhap values('GV32', 'GV32','SinhVien',1);
insert into DangNhap values('GV33', 'GV33','SinhVien',1);
insert into DangNhap values('GV34', 'GV34','SinhVien',1);
insert into DangNhap values('GV35', 'GV35','SinhVien',1);

--
create table quatrinhdangnhap
(
 TaiKhoan nvarchar(10),
 timelogin datetime
);

alter proc them_qtdangnhap
@TaiKhoan nvarchar(10),
@timelogin datetime
as
begin
insert into quatrinhdangnhap
values(@TaiKhoan,@timelogin)
end

create view dem_qtdangnhap
as
select TaiKhoan, count(TaiKhoan) as[dem] from quatrinhdangnhap
group by TaiKhoan

alter table DangNhap
add solandangnhap int 

create proc solandn(@matt nvarchar(10))
as
begin
update tblThuthu
SET solandangnhap = solandangnhap + 1
where sMaTT = @matt
end
--đếm số phiếu mà 1 thủ thư nào đó nhập-------
--alter view abc
--as
--select tblThuthu.sMaTT, count (sMaPhieu)as [abc]from tblThuthu left join tblPhieumuon on tblThuthu.sMaTT=tblPhieumuon.sMaTT group by tblThuthu.sMaTT

select* from b


alter view abc
as
select Diem.MaSV,LophocPhan.MaMon,MonHoc.TenMon,count(LopHocPhan.MaMon) as[solanhoc]
from Diem,LopHocPhan,MonHoc
where Diem.MaLHP=LopHocPhan.MaLHP and LopHocPhan.MaMon=MonHoc.MaMon
group by Diem.MaSV,LopHocPhan.MaMon,MonHoc.TenMon