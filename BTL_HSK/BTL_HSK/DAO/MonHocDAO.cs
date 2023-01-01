using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_HSK.DAO
{
    class MonHocDAO
    {
        public DataTable layDSMonHoc(string constr, string sqlcmd, string datatb)
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
        public bool Them_MonHoc(string constr, string MaMon, string TenMon, int SoTinChi)
        {

            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "themMonHoc";
                    cmd.Parameters.AddWithValue("@MaMon", MaMon);
                    cmd.Parameters.AddWithValue("@TenMon", TenMon);
                    cmd.Parameters.AddWithValue("@SoTinChi", SoTinChi);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public bool Check_MaMonHoc(string constr, string MaMon)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from MonHoc", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["MaMon"].Equals(MaMon))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        public bool Check_TenMonHoc(string constr, string TenMon)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand("select * from MonHoc", cnn))
                {
                    cnn.Open();
                    using (SqlDataReader rd = command.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            if (rd["TenMon"].Equals(TenMon))
                                return false;
                        }
                        rd.Close();
                    }
                    cnn.Close();
                }
            }
            return true;
        }
        public bool deleteMonHoc(string constr,string MaMon)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Delete_MonHoc";
                    cmd.Parameters.AddWithValue("@MaMon", MaMon);
                    cnn.Open();
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
        public DataTable Timkiem_MonHoc(string constr,string MaMon, string TenMon, string SoTinChi)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM MonHoc WHERE MaMon LIKE '%" + MaMon + "%' and TenMon LIKE N'%" + TenMon + "%' and SoTinChi LIKE '%" + SoTinChi + "%'", cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable("MonHoc"))
                        {
                            ad.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }
        public bool Sua_MonHoc(string constr, string MaMon, string TenMon, int SoTinChi)
        {
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    cnn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Update_MonHoc";
                    cmd.Parameters.AddWithValue("@MaMon", MaMon);
                    cmd.Parameters.AddWithValue("@TenMon", TenMon);
                    cmd.Parameters.AddWithValue("@SoTinChi", SoTinChi);
                    int i = cmd.ExecuteNonQuery();
                    cnn.Close();
                    return i > 0;
                }
            }
        }
    }
}
