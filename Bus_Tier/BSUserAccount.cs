using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Connector_Tier;
using Model;

namespace Bus_Tier
{
    public class BSUserAccount
    {
        ConnectorFactory connector = null;
        public BSUserAccount()
        {
            connector = new ConnectorFactory();
        }
        public bool ValidateUser(string phone, string password)
        {
            return connector.CheckLogin(phone, password);
        }
        public UserAccount Login(string phone)
        {
            return connector.Login(phone);
        }
    }
}
