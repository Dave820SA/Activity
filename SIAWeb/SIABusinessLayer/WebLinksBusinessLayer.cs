using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SIABusinessLayer
{
    public class WebLinksBusinessLayer
    {
        public IEnumerable<SIAWebLinks> SIAWebLinks
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["SAPDActivityCS"].ConnectionString;

                List<SIAWebLinks> weblinks = new List<SIAWebLinks>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllSIAWebLinks", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        SIAWebLinks weblink = new SIAWebLinks();
                        weblink.ID = Convert.ToInt32(rdr["ID"]);
                        weblink.LinkName = rdr["Name"].ToString();
                        weblink.WebAddress = rdr["WebLink"].ToString();

                        weblinks.Add(weblink);
                    }
                }

                return weblinks;
            }
        }
        
    }
}
