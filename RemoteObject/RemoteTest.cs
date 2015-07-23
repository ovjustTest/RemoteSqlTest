using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace RemoteObject
{
    public class RemoteTest : System.MarshalByRefObject//这是不能少的
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter da;
        string conStr = "Data Source=.;Persist Security Info=True;Initial Catalog=YiGuoCrm_IO;User ID=ygtest;Password=ygtest;Connect Timeout=1800";
        string queryStr = "select   *   from   XPCustomer";
        public DataTable datable()
        {
            using (con = new SqlConnection(conStr))
            {
                using (da = new SqlDataAdapter(queryStr, con))
                {
                    ds = new DataSet();
                    da.Fill(ds, "Categories");

                    return ds.Tables[0];
                }
            }
        }

        public string Value1 { get { return ConfigurationManager.AppSettings["value1"]; } }
        public string value2;
    }
}
