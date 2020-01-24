using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DatabaseSample
{
    class Program
    {
        static string connectionString = "Server=.;Database=bank;User Id=testuser;Password=testpass";


        static void Main(string[] args)
        {
            Method1();
            Method2();
            //Method3();
            //Method4();
            //Method5();
            //Method6();
            
            Console.Read();
        }

        static void Method1()
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            //var connectionString = Properties.Settings.Default.ConnectionString;

            SqlConnection dbcon = new SqlConnection(connectionString);
            dbcon.Open();
            var cmd = new SqlCommand("select * from customer", dbcon);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var cid = reader["cid"];
                var firstname = reader["firstname"];
                var lastname = reader[2];
                var city = reader[reader.FieldCount - 1];

                Console.WriteLine($"CID: {cid}, FirstName: {firstname}, LastName: {lastname}, City: {city}");
            }

            reader.Close();
            dbcon.Close();
        }

        static void Method2()
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("select * from loan", dbcon);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var lnum = reader[0];
                        var bcode = reader[1];
                        var amount = reader[2];
                        var interestrate = reader[3] == DBNull.Value ? "NULL" : reader[3];

                        Console.WriteLine($"LNUM: {lnum}, BCode: {bcode}, Amount: {amount}, Rate: {interestrate}");
                    }
                }
            }
        }

        static void Method3()
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("insert into branch values(@bid, @bname, @city, @assets)", dbcon);
                cmd.Parameters.AddWithValue("@bid", 630);
                cmd.Parameters.AddWithValue("@bname", "Αμπελόκηποι");
                cmd.Parameters.AddWithValue("@city", "Αθήνα");
                cmd.Parameters.AddWithValue("@assets", DBNull.Value);

                var affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine($"{affectedRows} Affected Rows");

                //cmd.Parameters["@bid"].Value = "650";
                //cmd.Parameters["@bname"].Value = "Περιστέρι";
                //cmd.Parameters["@city"].Value = "Αθήνα";
                //cmd.Parameters["@assets"].Value = 4444444;
                //affectedRows = cmd.ExecuteNonQuery();
                //Console.WriteLine($"{affectedRows} Affected Rows");

            }
        }

        static void Method4()
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("Get_Customer_Name", dbcon);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customer_id", 6);
                cmd.Parameters.Add(new 
                    SqlParameter("@customer_name", System.Data.SqlDbType.NVarChar)
                    {
                        Direction = System.Data.ParameterDirection.Output,
                        Size = 100
                    });

                var affectedRows = cmd.ExecuteNonQuery();
                Console.WriteLine(cmd.Parameters["@customer_name"].Value);
            }
        }

        static void Method5()
        {
            DataSet ds = null;
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("select * from loan", dbcon);
                var adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds);
                adapter.Dispose();
            }

            var table = ds.Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                var lnum = row[0];
                var bcode = row[1];
                var amount = row[2];
                var interestrate = row[3] == DBNull.Value ? "NULL" : row[3];

                Console.WriteLine($"LNUM: {lnum}, BCode: {bcode}, Amount: {amount}, Rate: {interestrate}");
            }
        }

        static void Method6()
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();
                var cmd = new SqlCommand("select max(amount) from loan", dbcon);
                var result = cmd.ExecuteScalar();
                Console.WriteLine($"Max Loan: {result}");
            }
        }
    }
}
