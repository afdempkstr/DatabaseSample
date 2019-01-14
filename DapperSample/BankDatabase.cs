using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperSample
{
    public class BankDatabase
    {
        private string _connectionString;

        public BankDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetCustomers(string query)
        {
            List<Customer> customers = null;
            try
            {
                using (SqlConnection dbcon = new SqlConnection(_connectionString))
                {
                    dbcon.Open();

                    customers = new List<Customer>();

                    customers.AddRange(dbcon.Query<Customer>(query));
                }
            }
            catch (DbException)
            {
                Console.WriteLine("Could not get customers list");
                customers = null;
            }
            return customers;
        }
    }
}
