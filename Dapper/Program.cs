// See https://aka.ms/new-console-template for more information

using Dapper;
using System.Data.SqlClient;

string connectionString = "Server=DESKTOP-VGKVPEH\\SQLEXPRESS;Database=employees;Trusted_Connection=True;";

using (var connection = new SqlConnection(connectionString))
{
    Console.WriteLine("Database Connected Successfully...");
}

