using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    class DiemDAO
    {
        public DataTable layDS(string constr, string sqlcmd, string datatb)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlcmd, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable(datatb);
                        ad.Fill(tb);
                        return tb;
                    }
                }
            }
        }
        public string layTenSV(string constr, string MaSV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from SinhVien where MaSV= '" + MaSV + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaSV"].Equals(MaSV))
                                return rd["TenSV"].ToString();
                        }
                        return "";
                    }
                }
            }
        }
        public string layTenMon(string constr, string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from LopHocPhan,MonHoc where LopHocPhan.MaMon=MonHoc.MaMon and MaLHP= '" + MaLHP + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaLHP"].Equals(MaLHP))
                                return rd["TenMon"].ToString();
                        }
                        return "";
                    }
                }
            }
        }
        public bool Them_Diem(string constr, string MaSV, string MaLHP, double DiemCC, double DiemGK, double DiemThi)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "themDiem";
                    cmd.Parameters.AddWithValue("@MaSV", MaSV);
                    cmd.Parameters.AddWithValue("@MaLHP", MaLHP);
                    cmd.Parameters.AddWithValue("@DiemCC", DiemCC);
                    cmd.Parameters.AddWithValue("@DiemGK", DiemGK);
                    cmd.Parameters.AddWithValue("@DiemThi", DiemThi);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public bool Sua_Diem(string constr, string MaSV, string MaLHP, double DiemCC, double DiemGK, double DiemThi)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Update_Diem";
                    cmd.Parameters.AddWithValue("@MaSV", MaSV);
                    cmd.Parameters.AddWithValue("@MaLHP", MaLHP);
                    cmd.Parameters.AddWithValue("@DiemCC", DiemCC);
                    cmd.Parameters.AddWithValue("@DiemGK", DiemGK);
                    cmd.Parameters.AddWithValue("@DiemThi", DiemThi);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public bool deleteDiem(string constr, string MaSV, string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Delete_Diem";
                    cmd.Parameters.AddWithValue("@MaSV", MaSV);
                    cmd.Parameters.AddWithValue("@MaLHP", MaLHP);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public DataTable Timkiem_Diem(string constr,string MaSV, string MaLHP, string DiemCC, string DiemGK, string DiemThi)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Diem WHERE MaSV LIKE '%" + MaSV + "%' and MaLHP LIKE N'%" + MaLHP + "%' and DiemCC LIKE '%" + DiemCC + "%'and DiemGK LIKE '%" + DiemGK + "%'and DiemThi LIKE '%" + DiemThi + "%'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("LopHocPhan"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public bool Check_Ma_ThemDiem(string constr, string MaSV, string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from Diem where MaSV= '" + MaSV + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaLHP"].Equals(MaLHP))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        // kiểm tra khoảng ngày sau
        public string layNgayBatDau(string constr,string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from LopHocPhan where LopHocPhan.MaLHP='" + MaLHP + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaLHP"].Equals(MaLHP))
                                return rd["ThoiGianBatDau"].ToString();
                        }
                        return "";
                    }
                }
            }
        }
        public bool Check_NgayKetThuc(string constr, string MaLHP, string MaSV, string TenMon)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from Diem, LopHocPhan,MonHoc where Diem.MaLHP=LopHocPhan.MaLHP and MonHoc.MaMon=LopHocPhan.MaMon and Diem.MaSV='" +MaSV+ "' and MonHoc.TenMon=N'" + TenMon + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (DateTime.Compare(DateTime.Parse(layNgayBatDau(constr,MaLHP)), DateTime.Parse(rd["ThoiGianKetThuc"].ToString())) < 0)
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        //
        //Kiểm tra khoảng ngày trc
        public string layNgayKetThuc(string constr, string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from LopHocPhan where LopHocPhan.MaLHP='" + MaLHP + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaLHP"].Equals(MaLHP))
                                return rd["ThoiGianKetThuc"].ToString();
                        }
                        return "";
                    }
                }
            }
        }
        public bool Check_NgayBatDau(string constr, string MaLHP, string MaSV, string TenMon)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from Diem, LopHocPhan,MonHoc where Diem.MaLHP=LopHocPhan.MaLHP and MonHoc.MaMon=LopHocPhan.MaMon and Diem.MaSV='" + MaSV + "' and MonHoc.TenMon=N'" + TenMon + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (DateTime.Compare(DateTime.Parse(layNgayKetThuc(constr,MaLHP)), DateTime.Parse(rd["ThoiGianBatDau"].ToString())) > 0)
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        public string layDiemMon(string constr, string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Diem,LopHocPhan where Diem.MaLHP=LopHocPhan.MaLHP and LopHocPhan.MaLHP='" + MaLHP + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaLHP"].Equals(MaLHP))
                                return rd["ThoiGianKetThuc"].ToString();
                        }
                        return "";
                    }
                }
            }
        }
        public bool Check_QuyenGiangVien(string constr, string MaLHP, string TaiKhoan)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from LopHocPhan where MaLHP='" + MaLHP + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaGV"].Equals(TaiKhoan))
                                return true;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return false;
        }
        public bool Check_HocLai(string constr, string MaLHP, string MaSV, string TenMon)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from a where MaSV='" + MaSV + "' and TenMon=N'" + TenMon + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (double.Parse(rd["TB Môn"].ToString())>4)
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        //1 sinh viên k đc học lại 1 môn quá 3 lần
        public bool Check_Solanhoc(string constr, string MaSV, string TenMon)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from abc where MaSV='" + MaSV + "' and TenMon=N'" + TenMon + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (int.Parse(rd["solanhoc"].ToString()) >=3)
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
    }
}
