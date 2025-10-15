using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConnStringTest.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connection String Test Demo");
            Console.WriteLine("==========================");

            try
            {
                // Example: Test database connection
                string connectionString = "Server=localhost;Database=TestDB;Integrated Security=true;" ;

                Console.WriteLine($"Using connection string: {connectionString}");

                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    Console.WriteLine("Connection opened successfully!");
                    Console.WriteLine($"Database: {cn.Database}");
                    Console.WriteLine($"Server Version: {cn.ServerVersion}");
                }

                Console.WriteLine("\nConnection test completed successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}