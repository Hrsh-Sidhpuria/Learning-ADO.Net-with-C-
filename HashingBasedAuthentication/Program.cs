// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Hello, World!");

string connectionString = "Server=DESKTOP-VGKVPEH\\SQLEXPRESS;Database=employees;Trusted_Connection=True;";
Console.WriteLine("1 for register and 0 for login");
int a =int.Parse(Console.ReadLine());
if(a == 0)
{
    Console.WriteLine("Login User");
    Console.WriteLine("Enter Username");
    string userName = Console.ReadLine();
    Console.WriteLine("Enter Password");
    string passWord = Console.ReadLine();

    Console.WriteLine("registering user ...");
    bool islogin = login(userName, passWord);
    if (islogin)
    {
        Console.WriteLine("Login Successful.\nYou are a employee of this company");
    }
    else
    {
        Console.WriteLine("Login failed !! invalid username or password");
    }
}
else
{
    Console.WriteLine("Register User");
    Console.WriteLine("Enter Username");
    string uName = Console.ReadLine();
    Console.WriteLine("Enter Password");
    string pWord = Console.ReadLine();

    Console.WriteLine("registering user ...");
    registerUser(uName, pWord);
}
Console.ReadLine();



void registerUser(string Username , string Password)
{
    string passwordHash = HashPassword(Password);

    SqlConnection conn = new SqlConnection(connectionString);
    
        try
        {
        conn.Open();
        if (conn.State == System.Data.ConnectionState.Open)
            {
            Console.WriteLine("connected");
            
            String insertQuery = "insert into userLogin values(@Username,@Password)";
                
                SqlCommand cmd = new SqlCommand(insertQuery, conn);
                cmd.Parameters.AddWithValue("Username", Username);
                cmd.Parameters.AddWithValue("Password", passwordHash);
                int resp = cmd.ExecuteNonQuery();
                if (resp > 0)
                {
                    Console.WriteLine("Register Sucessfully");
                }
                else
                {
                    Console.WriteLine("sorry ! cant able to register User");
                }
            }
        conn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

bool login(string Username, string Password)
{
    bool flag = false;
    string passwordHash = HashPassword(Password);
    SqlConnection conn = new SqlConnection(connectionString);
    try
    {
        conn.Open();
        if (conn.State == System.Data.ConnectionState.Open)
        {
            string LoginQuery = "select * from userLogin where username = @Username";
            SqlCommand cmd = new SqlCommand(LoginQuery, conn);
            cmd.Parameters.AddWithValue("Username", Username);
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd != null)
            {
                while (rd.Read())
                {
                    if (rd["Password"] == passwordHash)
                    {

                        flag = true;
                    }
                    else
                    {

                        flag = true;
                    }
                }

            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return flag;
}


static string HashPassword(string password)
{
    using (var sha256 = SHA256.Create())
    {
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}