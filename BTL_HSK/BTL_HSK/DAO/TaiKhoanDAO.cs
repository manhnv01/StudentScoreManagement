using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_HSK.DAO
{
    class TaiKhoanDAO
    {
        public DataTable layDSTaiKhoan(string constr, string sqlcmd, string datatb)
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
        public bool Them_DangNhap(string constr, string TaiKhoan, string MatKhau, string Quyen, int TrangThai)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "themDangNhap";
                    cmd.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", MatKhau);
                    cmd.Parameters.AddWithValue("@Quyen", Quyen);
                    cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public bool Check_TaiKhoan(string constr, string TaiKhoan)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from DangNhap", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["TaiKhoan"].Equals(TaiKhoan))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        public bool deleteTaiKhoan(string constr,string TaiKhoan)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Delete_DangNhap";
                    cmd.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public DataTable Timkiem_TaiKhoan(string constr,string TaiKhoan, string MatKhau, string Quyen, string TrangThai)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM DangNhap WHERE TaiKhoan LIKE '%" + TaiKhoan + "%' and MatKhau LIKE '%" + MatKhau + "%' and Quyen LIKE '%" + Quyen + "%' and TrangThai LIKE '%" + TrangThai + "%'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("DangNhap"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public bool Sua_TaiKhoan(string constr,string TaiKhoan, string MatKhau,string Quyen, int TrangThai)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Update_DangNhap";
                    cmd.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                    cmd.Parameters.AddWithValue("@MatKhau", MatKhau);
                    cmd.Parameters.AddWithValue("@Quyen", Quyen);
                    cmd.Parameters.AddWithValue("@TrangThai", TrangThai);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;

                }    
            }
        }
        public bool Check_No(string password)
        {
            //return Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript);
            //return Regex.IsMatch(password, @"^(?=.*[a-z]).+$", RegexOptions.ECMAScript); //lower
            //return Regex.IsMatch(password, @"^(?=.*[A-Z]).+$", RegexOptions.ECMAScript); //upper case
            return Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript); //^[A-Z]+$
        }
        public bool IsValidPass(string pass)
        {
            if (string.IsNullOrEmpty(pass))
                return false;
            string Pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(pass.Trim(), Pattern);
        }
        public bool DoiMK(string constr,string TaiKhoan, string MatKhauNew)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Update_MK";
                    cmd.Parameters.AddWithValue("@TaiKhoan", TaiKhoan);
                    cmd.Parameters.AddWithValue("@MatKhauNew", MatKhauNew);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i> 0;
                }
            }
        }
    }
}
