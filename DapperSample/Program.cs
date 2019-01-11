using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace DapperSample
{
    class Program
    {
        static string connectionString = "Server=.;Database=bank;User Id=testuser;Password=testpass";

        static void Main(string[] args)
        {
            //Method1();
            //Method3();
            //Method4();
            Method5();
        }

        static void Method1()
        {
            var customers = new List<Customer>();
            using (SqlConnection dbcon = new SqlConnection(connectionString))
            {
                dbcon.Open();

                customers.AddRange(dbcon.Query<Customer>("select * from customer"));
            }

            foreach (var c in customers)
            {
                Console.WriteLine($"CID: {c.cid}, FirstName: {c.firstname}, LastName: {c.lastname}, City: {c.city}");
            }
        }

        static void Method3()
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var affectedRows = dbcon.Execute("insert into branch values(@bid, @bname, @city, @assets)",
                    new
                    {
                        bid = 690,
                        bname = "Παγκράτι",
                        city = "Αθήνα",
                        assets = 500000
                    });

                Console.WriteLine($"{affectedRows} Affected Rows");
                
            }
        }

        static void Method4()
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@customer_id", 6);
                parameters.Add("@customer_name", null, size: 100, direction: ParameterDirection.Output);

                var affectedRows = dbcon.Execute("Get_Customer_Name", parameters, commandType: CommandType.StoredProcedure);
                Console.WriteLine(parameters.Get<string>("@customer_name"));
            }
        }

        static void Method5()
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var loans = dbcon.Query("select * from loan where bcode=@bcode", new { bcode = 100 });
                //each loan is a dynamic - an object from which we can get properties by name
                PrintLoans(loans);
            }
        }

        private static void PrintLoans(IEnumerable<dynamic> loans)
        {
            foreach (var loan in loans)
            {
                Console.WriteLine($"LNUM: {loan.lnum}, BCode: {loan.bcode}, Amount: {loan.amount}, Rate: {loan.interestrate}");
            }
        }
    }
}
