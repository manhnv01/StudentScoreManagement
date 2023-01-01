# QLDiemSinhVien
 
I. TỔNG QUAN ĐỀ TÀI
1. Khảo sát hiện trạng
- Hiện nay, công nghệ thông tin được xem là một ngành mũi nhọn của các quốc gia, đặc biệt là các quốc gia đang phát triển, tiến hành công nghiệp hóa và hiện đại hóa như nước ta. Sự bùng nổ thông tin và sự phát triển mạnh mẽ của công nghệ kỹ thuật số, yêu cầu muốn phát triển thì phải tin học hóa vào tất cả các ngành, các lĩnh vực.
- Cùng với sự phát triển nhanh chóng về phần cứng máy tính, các phần mềm ngày càng trở nên đa dạng, phong phú, hoàn thiện hơn và hỗ trợ hiệu quả cho con người. Các phần mềm hiện nay ngày càng mô phỏng được rất nhiều nghiệp vụ khó, hỗ trợ cho người dùng thuận tiện sử dụng, thời gian xử lý nhanh chóng, và một số nghiệp vụ được tự động hóa cao.
- Do vậy, trong việc phát triển phần mềm, sự đòi hỏi không chỉ là sự chính xác, xử lý được nhiều nghiệp vụ thực tế mà còn phải đáp ứng các yêu cầu khác về tốc độ, giao diện thân thiện, mô hình hóa được thực tế vào máy tính để người sử dụng tiện lợi, quen thuộc, tính tương thích và bảo mật cao,… Các phần mềm giúp tiết kiệm một lượng lớn thời gian, công sức của con người, tăng độ chính xác và hiệu quả trong công việc.
- Hiện nay, các trường đại học phải trực tiếp tiếp nhận, quản lý một khối lượng lớn và thường xuyên nhiều điểm học tập khác nhau của sinh viên. Do đó, công việc quản lý điểm sinh viên ngày càng phức tạp hơn.
- Hơn nữa, công tác quản lý không chỉ đơn thuần là quản lý về điểm của các sinh viên … mà công việc quản lý còn phải đáp ứng nhu cầu về việc báo cáo về tình hình học tập của sinh viên … để từ đó có thể đưa ra định hướng cho sinh viên. Nhưng với việc lưu trữ và xử lý bằng thủ công như hiện nay thì sẽ tốn rất nhiều thời gian và nhân lực mà không đem lại hiệu quả cao. Do đó cần phải tin học hóa hình thức quản lý, cụ thể là xây dựng một phần mềm để đáp ứng nhu cầu quản lý toàn diện, thống nhất và đạt hiệu quả cao nhất cho hoạt động quản lý điểm của sinh viên.

 
2. Mô tả bài toán
- Sinh viên phải cung cấp thông tin cho Phòng quản lý sinh viên như: Họ tên, giới tính, ngày sinh, email, CCCD và phòng quản lý sinh viên sẽ nhập, lưu trữ các thông tin trên.
- Bộ phận quản lý sẽ cho sinh viên thông tin về lớp hành chính ,lớp học phần và điểm của các môn học phần.
- Đối với Quản lý thì có thể quản lý thông tin của các sinh viên và giảng viên đang công tác và học tập tại trường, quản lý,tra cứu thông tin các lớp hành chính và các lớp học phần.
- Đối với Giảng viên giảng dạy sẽ quản lý và nhập điểm cho sinh viên của lớp học phần mà mình đang dạy.
- Thống kê báo các điểm của lớp học phần, bảng điểm cá nhân của từng sinh viên, xếp loại học lực, tính trung bình chung tích lũy, tổng tín chỉ tích lũy.

3. Yêu cầu chức năng
Chương trình Quản lý Điểm Sinh Viên cần có các chức năng chính sau:
-	Đối với Quản lý
+ Có thể xem, thêm, cập nhật các các Môn học,Lớp hành chính, Lớp học phần, Sinh viên, Giảng viên và Tài khoản đăng nhập hệ thống.
+ Báo cáo thống kê.
-	Đối với Giảng viên
+ Có thể xem, thêm, cập nhật thông tin sinh viên, nhập điểm sinh viên theo lớp giảng dạy, xem lịch giảng dạy sắp tới.
+ Báo cáo thống kê
-	Đối với Sinh viên
+ Xem thông tin cá nhân, Kết quả học tập cá nhân, bảng điểm cá nhân.
+ In Kết quả học tập , Bảng điểm cá nhân.
-	Các chức năng khác 
+ Đổi mật khẩu
 
II. THIẾT KẾ CSDL MỨC LOGIC
1.	Thiết kế cơ sở dữ liệu mức khái niệm – mô hình ER
1.1.	Xác định thực thể - thuộc tính và phân loại thuộc tính
(1)	SinhVien (MaSV, TenSV, GioiTinh, NgaySinh, Email,CCCD)
	+ MaSV là thuộc tính khoá.
(2)	GiangVien (MaGV, TenGV, SDT, Email, CCCD)
	+ MaGV là thuộc tính khoá.
(3)	MonHoc (MaMon, TenMon, SotinChi)
	+ MaMon là thuộc tính khóa
(4)	LopHanhChinh (MaLop, TenLop)
	+ MaLop là thuộc tính khoá.
(5)	LopHocPhan (MaLHP,ThoiGianBatDau, ThoiGianKetThuc)
	+ MaLHP là thuộc tính khóa
1.2.	Xác định liên kết và các kiểu liên kết
- Giữa thực thể LopHanhChinh và thực thể SinhVien có kiểu liên kết là 1 - N, vì:
	+ Một LopHanhChinh có nhiều SinhVien.
	+ Nhưng một SinhVien chỉ thuộc một LopHanhChinh.
 ![image](https://user-images.githubusercontent.com/88828150/210164544-52111a74-a285-40dd-b4b2-cb49169b9adc.png)

- Giữa thực thể MonHoc và thực thể LopHocPhan có kiểu liên kết là 1-N, vì:
	+ Một MonHoc có thể thuộc nhiều LopHocPhan.
	+ Nhưng một LopHocPhan chỉ giảng dạy một MonHoc.

![image](https://user-images.githubusercontent.com/88828150/210164550-36e3b644-ddf6-4ee2-8f5c-74b5a82ceafc.png)

 
−	Giữa thực thể GiangVien và thực thể LopHocPhan có kiểu liên kết là 1 - N, vì:
	+ Một GiangVien có thể giảng dạy ở nhiều LopHocPhan
	+ Nhưng một LopHocPhan chỉ có một GiangVien dạy
 ![image](https://user-images.githubusercontent.com/88828150/210164554-d844318a-f8de-4d99-a46a-05fd40567f2d.png)

−	Giữa thực thể SinhVien và thực thể LopHocPhan có kiểu liên kết là M – N, vì:
	+ Một SinhVien có thể học ở nhiều LopHocPhan
	+ Và một LopHocPhan có thể có nhiều SinhVien học

 ![image](https://user-images.githubusercontent.com/88828150/210164556-5d4def09-e4e0-4768-bc6c-433b2f9dc204.png)


1.3.	Mô hình ER

 ![image](https://user-images.githubusercontent.com/88828150/210164558-aa1eec5f-9ee0-4872-8a7f-bc7fe4a80a0d.png)

2.	Thiết kế cơ sở dữ liệu mức logic – mô hình quan hệ
2.1.	Chuẩn hóa quan hệ
	Áp dụng quy tắc 1: Chuyển kiểu thực thể mạnh
-	(1) SinhVien (MaSV, TenSV, GioiTinh, NgaySinh, Email,CCCD) 
-	(2) GiangVien (MaGV, TenGV, SDT, Email, CCCD)
-	(3) MonHoc (MaMon, TenMon, SotinChi)
-	(4) LopHanhChinh (MaLop, TenLop)
-	(5) LopHocPhan (MaLHP,ThoiGianBatDau, ThoiGianKetThuc)

	Áp dụng quy tắc: Chuyển các liên kết 1-N
-	(1’) SinhVien (MaSV, TenSV, GioiTinh, NgaySinh, Email,CCCD,MaLop)
-	(5’) LopHocPhan (MaLHP, MaMon,ThoiGianBatDau, ThoiGianKetThuc)
-	(5’’) LopHocPhan (MaLHP, MaMon, MaGV,ThoiGianBatDau, ThoiGianKetThuc)
	Áp dụng quy tắc 6: Chuyển các liên kết M-N
-	(6) Diem (MaSV, MaLHP, DiemCC, DiemGK, DiemThi)

2.2.	Cơ sở dữ liệu cuối cùng
⇨ Kết quả của việc chuyển đổi:
-	(1’) SinhVien (MaSV, TenSV, GioiTinh, NgaySinh, Email,CCCD,MaLop)
-	(2) GiangVien (MaGV, TenGV, SDT, Email, CCCD)
-	(3) MonHoc (MaMon, TenMon, SotinChi)
-	(4) LopHanhChinh (MaLop, TenLop)
-	(5’’) LopHocPhan (MaLHP, MaMon, MaGV,ThoiGianBatDau, ThoiGianKetThuc)
- (6) Diem (MaSV, MaLHP, DiemCC, DiemGK, DiemThi)
 
III. TẠO KẾT NỐI GIỮA CÁC BẢNG
 
![image](https://user-images.githubusercontent.com/88828150/210164560-2ff2a5a3-1d83-4da2-8a2c-3a4d480cf081.png)

IV. XÂY DỰNG CHƯƠNG TRÌNH
1.	Giao diện trang chủ

 ![image](https://user-images.githubusercontent.com/88828150/210164574-f52b618d-5b0e-41c1-9604-4c6fb40ccbfe.png)

1.1.	Giao diện form Đăng nhập
 
![image](https://user-images.githubusercontent.com/88828150/210164577-60444be0-0a7b-4bbd-89a6-d438ff4fa129.png)

1.2.	Giao diện form quản lý Sinh Viên
 
 ![image](https://user-images.githubusercontent.com/88828150/210164581-6aa1d818-f334-48d4-a90c-6462f2fea029.png)

1.3.	Giao diện form quản lý Giảng Viên
 
![image](https://user-images.githubusercontent.com/88828150/210164586-7ea88a4a-09ac-498f-a706-20133eecbd7d.png)

1.4.	Giao diện form quản lý Lớp Hành Chính

![image](https://user-images.githubusercontent.com/88828150/210164589-bb5733b2-7e83-4f83-b43c-6e111604e11d.png)

1.5.	Giao diện form quản lý Môn Học
 
![image](https://user-images.githubusercontent.com/88828150/210164591-4c7d439c-2359-45c8-9c70-2a9eb2447283.png)

1.6.	Giao diện form quản lý Lớp Học Phần

![image](https://user-images.githubusercontent.com/88828150/210164593-49fff1c0-7973-490a-90de-be8b7a971a3f.png)

1.7.	Giao diện form quản lý Điểm
 
![image](https://user-images.githubusercontent.com/88828150/210164595-9eaa4f9f-dc50-485e-affe-1579f3fae989.png)

1.8.	Giao Diện form quản lý Tài khoản đăng nhập

![image](https://user-images.githubusercontent.com/88828150/210164597-439f12b2-43e4-4496-a7d1-4cd55f692c32.png)

1.9.	Giao diện form Cá nhân của Sinh Viên
 
![image](https://user-images.githubusercontent.com/88828150/210164598-8a0dffd2-1289-409b-adf2-edc648159416.png)

1.10.	Giao diện form Cá nhân của Giảng Viên
 
![image](https://user-images.githubusercontent.com/88828150/210164601-82c54cab-87f4-4b12-8043-3addc46d15e7.png)

