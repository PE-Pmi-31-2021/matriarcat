using System;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using Npgsql;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           string waste = "Waste";
            //XMLWriter(nea);
            ShowTable(waste);
            //InsertRecord();
            // TestConnection();
            Console.ReadKey();
        }

        private static void TestConnection()
        {
            using(NpgsqlConnection con = GetConnection())
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    Console.WriteLine("connected");
                }
            }
        }
        private static void TrySet(string table)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string command = @"select * from " + $"{table}";
                con.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                foreach (DataTable dt in ds.Tables)
                {
                    Console.WriteLine(dt.TableName); 
                    foreach (DataColumn column in dt.Columns)
                        Console.Write("\t{0}", column.ColumnName);
                    Console.WriteLine();
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        foreach (object cell in cells)
                            Console.Write("\t{0}", cell);
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void XMLWriter(string table)
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string command = @"select * from " + $"{table}";
                con.Open();
                NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, con);
                DataSet ds = new DataSet($"{table}");
                DataTable dt = new DataTable("waste");
                ds.Tables.Add(dt);
                adapter.Fill(ds.Tables["waste"]);

                ds.WriteXml("try.xml");
                Console.WriteLine("done");
            }
        }
       
        private static void ShowTable(string table)
        {
            using(NpgsqlConnection con = GetConnection())
            {
                string command = @"select * from "+$"{table}";
                NpgsqlCommand npc = new NpgsqlCommand(command, con);
                con.Open();

                NpgsqlDataReader reader = npc.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}\t{reader[3]}");
                }
            }
        }
        private static void InsertRecord()
        {
            using (NpgsqlConnection con = GetConnection())
            {
                string query = @"insert into public.Students(Name,Fees)values('Angelina',250.0)";
                NpgsqlCommand npc = new NpgsqlCommand(query, con);
                con.Open();
                int n = npc.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("done!!");
                }
            }
        }
        private static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=____;Port=____;User Id=____;Password=____;DataBase=rss");
        }
    }
}
