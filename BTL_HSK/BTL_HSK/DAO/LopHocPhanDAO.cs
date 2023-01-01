using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    class LopHocPhanDAO
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
        public string layTenGV(string constr, string MaGV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select * from GiangVien where MaGV= '" + MaGV + "'", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaGV"].Equals(MaGV))
                                return rd["TenGV"].ToString();
                        }
                        return "";
                    }
                }
            }
        }
        public bool Them_LopHocPhan(string constr, string MaLHP, string MaMon, string MaGV, DateTime ThoiGianBatDau, DateTime ThoiGianKetThuc)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "themLopHocPhan";
                    cmd.Parameters.AddWithValue("@MaLHP", MaLHP);
                    cmd.Parameters.AddWithValue("@MaMon", MaMon);
                    cmd.Parameters.AddWithValue("@MaGV", MaGV);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", ThoiGianBatDau);
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", ThoiGianKetThuc);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public bool Check_MaLopHocPhan(string constr, string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from LopHocPhan", cnn))
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
        public bool Check_Xoa_MaLopHocPhan(string constr, string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from Diem", cnn))
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
        public bool deleteLopHocPhan(string constr,string MaLHP)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Delete_LopHocPhan";
                    cmd.Parameters.AddWithValue("@MaLHP", MaLHP);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public DataTable Timkiem_LopHocPhan(string constr,string MaLHP, string MaMon, string MaGV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM showViewAllLopHocPhan WHERE [Mã Lớp Học Phần] LIKE '%" + MaLHP + "%' and [Môn Học] LIKE N'%" + MaMon + "%' and [Mã Giảng Viên] LIKE '%" + MaGV + "%'", cnn))
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
        public bool Sua_LopHP(string constr,string MaLHP, string MaMon, string MaGV, string TimeBD, string TimeKT)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Update_LopHocPhan";
                    cmd.Parameters.AddWithValue("@MaLHP", MaLHP);
                    cmd.Parameters.AddWithValue("@MaMon", MaMon);
                    cmd.Parameters.AddWithValue("@MaGV", MaGV);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", TimeBD);
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", TimeKT);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
    }
}
