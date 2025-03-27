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
    public class BSAirport
    {
        ConnectorFactory connector = null;
        public BSAirport() 
        {
            connector = new ConnectorFactory();
        }
        public List<Airport> GetAllAirports()
        {
            return connector.GetAllAirports();
        }
        public Airport GetAirportByCode(string code)
        {
            return connector.GetAirportByCode(code);
        }
    }
}
