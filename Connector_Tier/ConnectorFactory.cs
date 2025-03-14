using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Connector_Tier
{
    public class ConnectorFactory
    {
        private string strConn = @"Server=LAPTOP-31PCHAIP\SQLEXPRESS;Database=AirlinesViet;Integrated Security=True;";
        private SqlCommand cmd = null;
        private SqlConnection conn = null;
        private SqlDataReader dr = null;
        public ConnectorFactory() 
        {
            conn = new SqlConnection(strConn);
        }
        public void openConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

            }
            }
        }

    }
}
