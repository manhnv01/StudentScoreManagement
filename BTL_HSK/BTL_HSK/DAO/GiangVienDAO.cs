using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    class GiangVienDAO
    {
        public DataTable layDSGiangVien(string constr, string sqlcmd, string datatb)
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
        public bool Them_GV(string constr, string MaGV, string TenGV, string SDT, string Email, string CCCD)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "themGiangVien";
                    cmd.Parameters.AddWithValue("@MaGV", MaGV);
                    cmd.Parameters.AddWithValue("@TenGV", TenGV);
                    cmd.Parameters.AddWithValue("@SDT", SDT);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }

        public bool Check_MGV(string constr, string MaGV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from GiangVien", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaGV"].Equals(MaGV))
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
                using (SqlCommand command = new SqlCommand("select * from GiangVien", cnn))
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
        public bool deleteGV(string constr,string MaGV)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Delete_GV";
                    cmd.Parameters.AddWithValue("@MaGV", MaGV);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public DataTable Timkiem_GV(string constr,string TenGV, string MaGV, string CCCD, string Email, string SDT)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM GiangVien WHERE TenGV LIKE N'%" + TenGV + "%' and MaGV LIKE '%" + MaGV + "%' and [CCCD] LIKE '%" + CCCD + "%' and [Email] LIKE '%" + Email + "%' and SDT LIKE '%" + SDT + "%'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("GiangVien"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public bool Sua_GiangVien(string constr, string MaGV, string TenGV, string SDT, string Email, string CCCD)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Update_GV";
                    cmd.Parameters.AddWithValue("@MaGV", MaGV);
                    cmd.Parameters.AddWithValue("@TenGV", TenGV);
                    cmd.Parameters.AddWithValue("@SDT", SDT);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@CCCD", CCCD);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public bool IsValidVietNamPhoneNumber(string phoneNum)
        {
            if (string.IsNullOrEmpty(phoneNum))
                return false;
            string sMailPattern = @"^((01(\d){8})|(03(\d){8})|(07(\d){8})|(08(\d){8})|(09(\d){8}))$";
            return Regex.IsMatch(phoneNum.Trim(), sMailPattern);
        }
    }
}
