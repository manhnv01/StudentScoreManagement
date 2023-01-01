using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    class SinhVienDAO
    {
        public DataTable layDSSinhVien(string constr, string sqlcmd, string datatb)
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
        public bool Them_SV(string constr, string MaSV, string TenSV, string GioiTinh, DateTime NgaySinh, string Email, string CCCD, string MaLop)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "themSinhVien";
                    cmd.Parameters.AddWithValue("@MaSV", MaSV);
                    cmd.Parameters.AddWithValue("@TenSV", TenSV);
                    cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@MaLop", MaLop);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public bool Check_MSV(string constr, string MaSV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from SinhVien", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaSV"].Equals(MaSV))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }

        public bool Check_CCCD(string constr, string CCCD)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from SinhVien", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["CCCD"].Equals(CCCD))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        public bool deleteSV(string constr,string MaSV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Delete_SV";
                    cmd.Parameters.AddWithValue("@MaSV", MaSV);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public DataTable Timkiem_SV(string constr,string TenSV, string MaSV, string CCCD, string Email, string LopHC, string GioiTinh)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                String sqlGT = "";
                if (GioiTinh != "")
                {
                    sqlGT = "and[Giới Tính] = N'" + GioiTinh + "'";
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM showViewAllSV WHERE [Tên Sinh Viên] LIKE N'%" + TenSV + "%' and [Mã Sinh Viên] LIKE '%" + MaSV + "%' and [CCCD] LIKE '%" + CCCD + "%' and [Email] LIKE '%" + Email + "%' and [Lớp Hành Chính] LIKE '%" + LopHC + "%' " + sqlGT, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("showViewAllSV"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public bool Sua_SinhVien(string constr, string MaSV, string TenSV, string GioiTinh, DateTime NgaySinh, string Email, string CCCD, string MaLop)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Update_SV";
                    cmd.Parameters.AddWithValue("@MaSV", MaSV);
                    cmd.Parameters.AddWithValue("@TenSV", TenSV);
                    cmd.Parameters.AddWithValue("@GioiTinh", GioiTinh);
                    cmd.Parameters.AddWithValue("@NgaySinh", NgaySinh);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cmd.Parameters.AddWithValue("@MaLop", MaLop);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
    }
}
