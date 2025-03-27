using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using Model;
using System.Security.Policy;

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void closeConnection()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CheckLogin(string phone, string password)
        {
            try
            {
                openConnection();

                string query = "SELECT COUNT(*) FROM Users WHERE phone = @Phone AND password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Return true if the account exists
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error checking login: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        public UserAccount Login(string phone)
        {
            try
            {
                openConnection();
                string query = "SELECT * FROM Users WHERE phone = @Phone";
                
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserAccount useraccount = new UserAccount();
                            useraccount.user_id = reader["user_id"].ToString();
                            useraccount.full_name = reader["full_name"].ToString();
                            useraccount.email = reader["email"].ToString();
                            useraccount.phone = reader["phone"].ToString();
                            useraccount.password = reader["password"].ToString();
                            useraccount.member_rank = reader["member_rank"].ToString();
                            useraccount.birthday = reader["birthday"].ToString();
                            return useraccount;
                        }
                        else
                        {
                            return null;
                        }
                    }    
                        
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
        public List<Airport> GetAllAirports()
        {
            List<Airport> airports = new List<Airport>();

            try
            {
                openConnection();

                // Chọn cột tương ứng với Model: name, code, city, country
                // Nếu muốn lấy cả airport_id thì SELECT airport_id, name, ...
                string query = "SELECT name, code, city, country FROM Airports";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Airport airport = new Airport()
                            {
                                // Nếu cột trong DB là "name" thì reader["name"].ToString()
                                // Nếu cột khác tên (vd. airport_name) thì sửa lại key cho phù hợp
                                name = reader["name"].ToString(),
                                code = reader["code"].ToString(),
                                city = reader["city"].ToString(),
                                country = reader["country"].ToString()
                            };
                            airports.Add(airport);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ghi log, ném Exception,...)
                throw new Exception("Lỗi khi lấy danh sách Airports: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }

            return airports;
        }
        public Airport GetAirportByCode(string code)
        {
            try
            {
                openConnection();

                string query = "SELECT * From Airports WHERE code = @Code";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Code", code);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Airport airport = new Airport();
                            airport.name = reader["name"].ToString();
                            airport.code = reader["code"].ToString();
                            airport.city = reader["city"].ToString();
                            airport.country = reader["country"].ToString();
                            return airport;
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            finally
            {
                closeConnection();
            }
        }
    }
}
