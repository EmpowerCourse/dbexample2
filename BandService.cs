using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace dbexample2
{
    public class BandService
    {
        public List<Band> GetBands(string nameFilter)
        {
            List<Band> result = new List<Band>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                cn.Open();
                // string sql = "select * from band where bandName LIKE '%' + @nameFilter + '%'";
                string sql = "dbo.myStoredProcedure";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@nameFilter", nameFilter));
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        result.Add(new Band()
                        {
                            BandId = (int)dr["BandId"],
                            BandName = (string)dr["BandName"]
                        });
                    }
                }
                cn.Close();
            }
            return result;
        }

        public List<Band> GetBandsWithDataTable(string nameFilter)
        {
            List<Band> result = new List<Band>();
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
            {
                // cn.Open();
                string sql = "select * from band where bandName LIKE '%' + @nameFilter + '%'";
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    cmd.Parameters.Add(new SqlParameter("@nameFilter", nameFilter));
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach(DataRow drw in dt.Rows)
                    {
                        result.Add(new Band()
                        {
                            BandId = (int)drw["BandId"],
                            BandName = (string)drw["BandName"]
                        });
                    }
                }
                // cn.Close();
            }
            return result;
        }
    }
}
