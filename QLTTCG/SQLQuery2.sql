CREATE DATABASE QLTTCG;
GO

USE QLTTCG;
GO

-- Bảng LOAI_CA
CREATE TABLE Ca(
    MaCa VARCHAR(7) PRIMARY KEY,
    tenCa NVARCHAR(100),
    giaBan FLOAT
);
go
-- Bảng AO_NUOI
CREATE TABLE HoCa (
    MaHoCa VARCHAR(7) PRIMARY KEY,
    DienTich FLOAT,
);
go
-- Bảng DOT_THA_CA
CREATE TABLE DotThaCa (
    MaDotThaCa VARCHAR(7) PRIMARY KEY,
    MaHoCa VARCHAR(7),
    MaCa VARCHAR(7),
    NgayTha DATE,
    SoLuong INT,
    FOREIGN KEY (MaHoCa) REFERENCES HoCa(MaHoCa),
    FOREIGN KEY (MaCa) REFERENCES Ca(Maca)

);
go
-- Bảng BENH
CREATE TABLE Benh (
    MaBenh VARCHAR(7) PRIMARY KEY,
    TenBenh NVARCHAR(100),
    TrieuChung NVARCHAR(MAX),
);
go
-- Bảng THEO_DOI_SUC_KHOE
CREATE TABLE TheoDoiSucKhoe (
    MaTheoDoiSucKhoe VARCHAR(7) PRIMARY KEY,
	MaHoCa VARCHAR(7),
    MaDotThaCa VARCHAR(7),
    MaBenh VARCHAR(7),
    NgayGhiNhan DATE,
    TinhTrangSucKhoe NVARCHAR(100),
    GhiChu NVARCHAR(MAX),
    FOREIGN KEY (MaDotThaCa) REFERENCES DotThaCa(MaDotThaCa),
    FOREIGN KEY (MaBenh) REFERENCES Benh(MaBenh),
	FOREIGN KEY (MaHoCa) REFERENCES HoCa(MaHoCa)
);
go
-- Bảng THUOC
CREATE TABLE Thuoc (
    MaThuoc VARCHAR(7) PRIMARY KEY,
    TenThuoc NVARCHAR(100),
    CongDung NVARCHAR(MAX),
    DonViThuoc NVARCHAR(50),
    GiaThuoc FLOAT
);
go
-- Bảng SU_DUNG_THUOC
CREATE TABLE SuDungThuoc (
    MaSuDungThuoc VARCHAR(7) PRIMARY KEY,
	MaHoCa VARCHAR(7),
    MaDotThaCa VARCHAR(7),
    MaThuoc VARCHAR(7),
    NgaySuDung DATE ,
    LieuLuong FLOAT,
    ChiPhiThuoc FLOAT,
    FOREIGN KEY (MaDotThaCa) REFERENCES DotThaCa(MaDotThaCa),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc),
	FOREIGN KEY (MaHoCa) REFERENCES HoCa(MaHoCa)
);
go
ALTER TABLE SuDungThuoc
DROP COLUMN ChiPhiThuoc;

-- Bảng THUC_AN
CREATE TABLE ThucAn (
    MaThucAn VARCHAR(7) PRIMARY KEY,
    TenThucAn NVARCHAR(100),
    LoaiThucAn NVARCHAR(100),
    GiaThucAn FLOAT,
    DonViThucAn NVARCHAR(50)
);
go
-- Bảng CHO_AN
CREATE TABLE ChoAn (
    MaChoAn VARCHAR(7) PRIMARY KEY,
	MaHoCa VARCHAR(7),
    MaDotThaCa VARCHAR(7),
    MaThucAn VARCHAR(7),
    NgayChoAn DATE,
    LuongThucAn FLOAT,
    FOREIGN KEY (MaDotThaCa) REFERENCES DotThaCa(MaDotThaCa),
    FOREIGN KEY (MaThucAn) REFERENCES ThucAn(MaThucAn),
	FOREIGN KEY (MaHoCa) REFERENCES HoCa(MaHoCa)
);
go
-- Bảng THEO_DOI_MOI_TRUONG
CREATE TABLE TheoDoiMoiTruong (
    MaTheoDoiMoiTruong VARCHAR(7) PRIMARY KEY,
    MaHoCa VARCHAR(7),
    NgayGhiNhan DATE,
    NhietDo FLOAT,
    DoPH FLOAT,
    NongDoOxy FLOAT,
    FOREIGN KEY (MaHoCa) REFERENCES HoCa(MaHoCa)
);
go
-- Bảng NHAN_VIEN
CREATE TABLE NhanVien (
    MaNhanVien VARCHAR(7) PRIMARY KEY,
    HoTenNV NVARCHAR(50),
    SoDienThoaiNV NVARCHAR(11)
);
go
-- Bảng KHACH_HANG
CREATE TABLE KhachHang (
    MaKhachHang VARCHAR(7) PRIMARY KEY,
    HoTenKH NVARCHAR(100),
    SoDienThoaiKH NVARCHAR(11),
    EmailKH NVARCHAR(50),
    DiaChiKH NVARCHAR(MAX)
);
go


-- Bảng HOA_DON
CREATE TABLE HoaDon (
    MaHoaDon VARCHAR(7) PRIMARY KEY,
    MaKhachHang VARCHAR(7),
    MaNhanVien VARCHAR(7),
    NgayBan DATE,
    TongTien FLOAT,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
go
ALTER TABLE HoaDon
DROP COLUMN TongTien;
-- Bảng CHI_TIET_HOA_DON
CREATE TABLE ChiTietHoaDon(
    MaChiTietHoaDon VARCHAR(7) PRIMARY KEY,
    MaHoaDon VARCHAR(7),
    MaCa VARCHAR(7),
    SoLuongCa VARCHAR,
    DonGia FLOAT,
    ThanhTien FLOAT,
    FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
    FOREIGN KEY (MaCa) REFERENCES Ca(MaCa)
);

CREATE TABLE NguoiDung(
	TaiKhoan VARCHAR(50),
	MatKhau VARCHAR(50)
);
-- Bảng BAO_CAO
CREATE TABLE BaoCao (
    MaBaoCao VARCHAR(7) PRIMARY KEY,    -- Mã báo cáo duy nhất
    NgayBaoCao DATE,                    -- Ngày lập báo cáo
    TongThu FLOAT,                      -- Tổng doanh thu
    TongChi FLOAT,                      -- Tổng chi phí
    LoiNhuan FLOAT                      -- Lợi nhuận (Tổng thu - Tổng chi)
);
GO


CREATE PROCEDURE TaoBaoCao
    @NgayBaoCao DATE
AS
BEGIN
    DECLARE @MaBaoCao VARCHAR(7);
    DECLARE @TongThu FLOAT, @TongChi FLOAT, @LoiNhuan FLOAT;
    DECLARE @ChiPhiThuoc FLOAT, @ChiPhiThucAn FLOAT;

    -- Tạo giá trị MaBaoCao tự động
    SELECT @MaBaoCao = 'BC' + RIGHT('000' + CAST(ISNULL(MAX(CAST(SUBSTRING(MaBaoCao, 3, 3) AS INT)), 0) + 1 AS VARCHAR(3)), 3)
    FROM BaoCao;

    -- Tính tổng thu từ ChiTietHoaDon (sử dụng ThanhTien trong bảng ChiTietHoaDon thay vì TongTien trong HoaDon)
    SELECT @TongThu = SUM(ThanhTien)
    FROM ChiTietHoaDon
    INNER JOIN HoaDon ON HoaDon.MaHoaDon = ChiTietHoaDon.MaHoaDon
    WHERE HoaDon.NgayBan <= @NgayBaoCao;

    -- Tính tổng chi phí thuốc
    SELECT @ChiPhiThuoc = SUM(SuDungThuoc.LieuLuong * Thuoc.GiaThuoc)
    FROM SuDungThuoc
    INNER JOIN Thuoc ON SuDungThuoc.MaThuoc = Thuoc.MaThuoc
    WHERE NgaySuDung <= @NgayBaoCao;

    -- Tính tổng chi phí thức ăn
    SELECT @ChiPhiThucAn = SUM(ChoAn.LuongThucAn * ThucAn.GiaThucAn)
    FROM ChoAn
    INNER JOIN ThucAn ON ChoAn.MaThucAn = ThucAn.MaThucAn
    WHERE NgayChoAn <= @NgayBaoCao;

    -- Tính tổng chi và lợi nhuận
    SET @TongChi = ISNULL(@ChiPhiThuoc, 0) + ISNULL(@ChiPhiThucAn, 0);
    SET @LoiNhuan = ISNULL(@TongThu, 0) - @TongChi;

    -- Thêm dữ liệu vào bảng BaoCao
    INSERT INTO BaoCao (MaBaoCao, NgayBaoCao, TongThu, TongChi, LoiNhuan)
    VALUES (@MaBaoCao, @NgayBaoCao, @TongThu, @TongChi, @LoiNhuan);
END;
GO


-- Thêm dữ liệu bảng Ca
INSERT INTO Ca (MaCa, tenCa, giaBan) VALUES
('CA001', N'Cá Rô Phi Giống', 1000),
('CA002', N'Cá Chép Giống', 1500),
('CA003', N'Cá Trắm Cỏ Giống', 2000);

-- Thêm dữ liệu bảng HoCa 
INSERT INTO HoCa (MaHoCa, DienTich) VALUES
('HC001', 100),
('HC002', 120),
('HC003', 150),
('HC004', 100),
('HC005', 200),
('HC006', 180),
('HC007', 150),
('HC008', 130),
('HC009', 140),
('HC010', 160);

-- Thêm dữ liệu bảng Benh
INSERT INTO Benh (MaBenh, TenBenh, TrieuChung) VALUES
('B001', N'Bệnh đốm trắng', N'Xuất hiện các đốm trắng trên thân cá'),
('B002', N'Bệnh nấm mang', N'Mang cá có màu nhợt nhạt, xuất hiện các đốm trắng'),
('B003', N'Bệnh xuất huyết', N'Da cá xuất hiện các vết đỏ, cá bơi lờ đờ');

-- Thêm dữ liệu bảng ThucAn
INSERT INTO ThucAn (MaThucAn, TenThucAn, LoaiThucAn, GiaThucAn, DonViThucAn) VALUES
('TA001', N'Thức ăn cá bột', N'Bột mịn', 50000, N'kg'),
('TA002', N'Thức ăn cá hương', N'Viên nhỏ', 45000, N'kg');

-- Thêm dữ liệu bảng Thuoc
INSERT INTO Thuoc (MaThuoc, TenThuoc, CongDung, DonViThuoc, GiaThuoc) VALUES
('TH001', N'Chloramine T', N'Khử trùng nước', N'kg', 180000),
('TH002', N'Blue Green', N'Trị nấm mang', N'chai', 90000),
('TH003', N'Vitamin C', N'Tăng sức đề kháng', N'kg', 250000);

-- Thêm dữ liệu bảng NhanVien
INSERT INTO NhanVien (MaNhanVien, HoTenNV, SoDienThoaiNV) VALUES
('NV001', N'Nguyễn Văn An', '0901234567'),
('NV002', N'Trần Thị Bình', '0912345678'),
('NV003', N'Lê Văn Cường', '0923456789');

-- Thêm dữ liệu bảng KhachHang
INSERT INTO KhachHang (MaKhachHang, HoTenKH, SoDienThoaiKH, EmailKH, DiaChiKH) VALUES
('KH001', N'Trang trại Phú Quý', '0989123456', 'phuquy@email.com', N'Đồng Nai'),
('KH002', N'Trang trại Tấn Phát', '0977234567', 'tanphat@email.com', N'Trà Vinh'),
('KH003', N'Trang trại Thịnh Vượng', '0966345678', 'thinhvuong@email.com', N'Tiền Giang'),
('KH004', N'Trang trại Phúc Duy', '0977234756', 'phucduy1501@email.com', N'Trà Vinh'),
('KH005', N'Trang trại Lữ Hải', '0918454567', 'luhai@email.com', N'Trà Vinh'),
('KH006', N'Trang trại Minh Châu', '0932123456', 'minhchau@email.com', N'Trà Vinh'),
('KH007', N'Trang trại Thiên Ân', '0945678910', 'thienan@email.com', N'Trà Vinh'),
('KH008', N'Trang trại An Khánh', '0955555555', 'ankhanh@email.com', N'Trà Vinh'),
('KH009', N'Trang trại Kim Long', '0966666666', 'kimlong@email.com', N'Trà Vinh'),
('KH010', N'Trang trại Phú Mỹ', '0977777777', 'phumy@email.com', N'Trà Vinh');

-- Thêm dữ liệu bảng DotThaCa
INSERT INTO DotThaCa (MaDotThaCa, MaHoCa, MaCa, NgayTha, SoLuong) VALUES
('DTC001', 'HC001', 'CA001', '2024-01-01', 10000),
('DTC002', 'HC002', 'CA002', '2024-01-15', 8000),
('DTC003', 'HC003', 'CA003', '2024-02-01', 7000),
('DTC004', 'HC004', 'CA001', '2024-02-15', 9000),
('DTC005', 'HC005', 'CA002', '2024-03-01', 8000),
('DTC006', 'HC006', 'CA003', '2024-03-15', 6000),
('DTC007', 'HC007', 'CA001', '2024-04-01', 11000),
('DTC008', 'HC008', 'CA002', '2024-04-15', 9500),
('DTC009', 'HC009', 'CA003', '2024-05-01', 7500),
('DTC010', 'HC010', 'CA001', '2024-05-15', 10500);

-- Thêm dữ liệu bảng TheoDoiSucKhoe
INSERT INTO TheoDoiSucKhoe (MaTheoDoiSucKhoe, MaHoCa, MaDotThaCa, MaBenh, NgayGhiNhan, TinhTrangSucKhoe, GhiChu) VALUES
('TDSK001','HC001', 'DTC001', 'B001', '2024-01-10', N'Phát hiện sớm', N'Đã xử lý kịp thời'),
('TDSK002','HC002', 'DTC002', 'B002', '2024-01-25', N'Đang điều trị', N'Cần theo dõi thêm'),
('TDSK003','HC003', 'DTC003', 'B003', '2024-02-10', N'Bình thường', N'Không có dấu hiệu bất thường'),
('TDSK004','HC004', 'DTC004', 'B001', '2024-02-25', N'Phát triển tốt', N'Tăng trưởng nhanh'),
('TDSK005','HC005', 'DTC005', 'B002', '2024-03-10', N'Bình thường', N'Không có vấn đề gì'),
('TDSK006','HC006', 'DTC006', 'B003', '2024-03-25', N'Bệnh nhẹ', N'Đã điều trị bằng thuốc'),
('TDSK007','HC007', 'DTC007', 'B001', '2024-04-10', N'Bình thường', N'Tăng trưởng ổn định'),
('TDSK008','HC008', 'DTC008', 'B002', '2024-04-25', N'Phát triển tốt', N'Màu sắc tươi tắn'),
('TDSK009','HC009', 'DTC009', 'B003', '2024-05-10', N'Bệnh nặng', N'Đang điều trị tích cực'),
('TDSK010','HC010', 'DTC010', 'B001', '2024-05-25', N'Bình thường', N'Không có dấu hiệu bất thường');

-- Thêm dữ liệu bảng SuDungThuoc
INSERT INTO SuDungThuoc (MaSuDungThuoc, MaHoCa, MaDotThaCa, MaThuoc, NgaySuDung, LieuLuong, ChiPhiThuoc) VALUES
('SDT001','HC001', 'DTC001', 'TH001', '2024-01-10', 2.5, 450000),
('SDT002','HC002', 'DTC002', 'TH002', '2024-01-25', 3.0, 270000),
('SDT003','HC003', 'DTC003', 'TH003', '2024-02-10', 1.5, 375000),
('SDT004','HC004', 'DTC004', 'TH001', '2024-02-25', 2, 360000), 
('SDT005','HC005', 'DTC005', 'TH002', '2024-03-10', 1, 90000),  
('SDT006','HC006', 'DTC006', 'TH003', '2024-03-25', 3, 450000),  
('SDT007','HC007', 'DTC007', 'TH001', '2024-04-10', 2.5, 450000), 
('SDT008','HC008', 'DTC008', 'TH002', '2024-04-25', 2, 180000),  
('SDT009','HC009', 'DTC009', 'TH003', '2024-05-10', 1.5, 225000),  
('SDT010','HC010', 'DTC010', 'TH001', '2024-05-25', 3, 540000); 
-- Thêm dữ liệu bảng ChoAn
INSERT INTO ChoAn (MaChoAn, MaHoCa, MaDotThaCa, MaThucAn, NgayChoAn, LuongThucAn) VALUES
('CA001','HC001', 'DTC001', 'TA001', '2024-01-02', 5.5),
('CA002','HC002', 'DTC002', 'TA002', '2024-01-16', 4.5),
('CA003','Hc003', 'DTC003', 'TA001', '2024-02-02', 6.0),
('CA004','HC004', 'DTC004', 'TA002', '2024-02-16', 5.0),
('CA005','HC005', 'DTC005', 'TA001', '2024-03-02', 4.8),
('CA006','HC006', 'DTC006', 'TA002', '2024-03-16', 5.2),
('CA007','HC007', 'DTC007', 'TA001', '2024-04-02', 5.5),
('CA008','HC008', 'DTC008', 'TA002', '2024-04-15', 6.0),
('CA009','HC009', 'DTC009', 'TA001', '2024-05-01', 4.9),
('CA010','HC010', 'DTC010', 'TA002', '2024-05-16', 5.3),
('CA011','HC001', 'DTC001', 'TA001', '2024-01-04', 5.7),
('CA012','HC002', 'DTC002', 'TA002', '2024-01-18', 4.4),
('CA013','HC003', 'DTC003', 'TA001', '2024-02-04', 6.1),
('CA014','HC004', 'DTC004', 'TA002', '2024-02-18', 5.3),
('CA015','HC005', 'DTC005', 'TA001', '2024-03-04', 4.7),
('CA016','HC006', 'DTC006', 'TA002', '2024-03-18', 5.6),
('CA017','HC007', 'DTC007', 'TA001', '2024-04-04', 5.4),
('CA018','HC008', 'DTC008', 'TA002', '2024-04-17', 5.9),
('CA019','HC009', 'DTC009', 'TA001', '2024-05-03', 4.8),
('CA020','HC010', 'DTC010', 'TA002', '2024-05-18', 5.2);


-- Thêm dữ liệu bảng TheoDoiMoiTruong
INSERT INTO TheoDoiMoiTruong (MaTheoDoiMoiTruong, MaHoCa, NgayGhiNhan, NhietDo, DoPH, NongDoOxy) VALUES
('TDMT001', 'HC001', '2024-01-01', 28.5, 7.2, 5.8),
('TDMT002', 'HC002', '2024-01-15', 29.0, 7.4, 5.6),
('TDMT003', 'HC003', '2024-02-01', 28.8, 7.3, 5.7),
('TDMT004', 'HC004', '2024-02-15', 28.6, 7.1, 5.9),
('TDMT005', 'HC005', '2024-03-01', 28.4, 7.2, 5.7),
('TDMT006', 'HC006', '2024-03-15', 28.9, 7.3, 5.8),
('TDMT007', 'HC007', '2024-04-01', 28.7, 7.2, 5.6),
('TDMT008', 'HC008', '2024-04-15', 28.5, 7.1, 5.9),
('TDMT009', 'HC009', '2024-05-01', 28.8, 7.4, 5.5),
('TDMT010', 'HC010', '2024-05-15', 28.6, 7.3, 5.8),
('TDMT011', 'HC001', '2024-01-02', 28.6, 7.2, 5.7),
('TDMT012', 'HC002', '2024-01-16', 29.1, 7.5, 5.5),
('TDMT013', 'HC003', '2024-02-02', 28.7, 7.4, 5.6),
('TDMT014', 'HC004', '2024-02-16', 28.5, 7.2, 5.8),
('TDMT015', 'HC005', '2024-03-02', 28.3, 7.1, 5.7),
('TDMT016', 'HC006', '2024-03-16', 28.8, 7.3, 5.6),
('TDMT017', 'HC007', '2024-04-02', 28.9, 7.2, 5.7),
('TDMT018', 'HC008', '2024-04-16', 28.4, 7.1, 5.9),
('TDMT019', 'HC009', '2024-05-02', 28.7, 7.4, 5.5),
('TDMT020', 'HC010', '2024-05-16', 28.5, 7.3, 5.8);

-- Thêm dữ liệu bảng HoaDon
INSERT INTO HoaDon (MaHoaDon, MaKhachHang, MaNhanVien, NgayBan, TongTien) VALUES
('HD001', 'KH001', 'NV001', '2024-01-20', 15000000),
('HD002', 'KH002', 'NV002', '2024-02-05', 12000000),
('HD003', 'KH003', 'NV003', '2024-02-20', 18000000);

-- Thêm dữ liệu bảng ChiTietHoaDon
INSERT INTO ChiTietHoaDon (MaChiTietHoaDon, MaHoaDon, MaCa, SoLuongCa, DonGia, ThanhTien) VALUES
('CTHD001', 'HD001', 'CA001', '5000', 1000, 5000000),
('CTHD002', 'HD002', 'CA002', '4000', 1500, 6000000),
('CTHD003', 'HD003', 'CA003', '3000', 2000, 6000000);

INSERT INTO NguoiDung (TaiKhoan, MatKhau) VALUES 
('admin','123'),
('nhanvien','234');

ALTER TABLE ChiTietHoaDon
ALTER COLUMN SoLuongCa VARCHAR(6);

SELECT * FROM Ca
SELECT * FROM HoCa
where DienTich = '120'; 

SELECT * FROM ChiTietHoaDon
SELECT * FROM ChoAn
SELECT * FROM DotThaCa
SELECT * FROM HoaDon
SELECT * FROM KhachHang
SELECT * FROM NhanVien
SELECT * FROM BaoCao
SELECT * FROM TheoDoiMoiTruong
SELECT * FROM TheoDoiSucKhoe
SELECT * FROM NguoiDung
SELECT * FROM Benh
SELECT * FROM ThucAn
SELECT * FROM Thuoc
SELECT * FROM SuDungThuoc
EXEC sp_help 'NhanVien';
