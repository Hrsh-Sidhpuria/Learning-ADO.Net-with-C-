// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

//accessing database connection without using entity framework 

//accessing database with the help of ADO.Net

//Getting data from User
/*Console.WriteLine("Insert Into Database\n");
Console.WriteLine("Enter Name");
string name = Console.ReadLine();
Console.WriteLine("Enter email");
string email = Console.ReadLine();
Console.WriteLine("Enter salary");
string salary = Console.ReadLine();
connection_sql(name,email,salary);*/

connection_sql();

void connection_sql(/*string name, string email, string salary*/)
{
    //connection string
    string connectionString = "Server=DESKTOP-VGKVPEH\\SQLEXPRESS;Database=employees;Trusted_Connection=True;";



    /*try
    {*/
    //Connecting to database 
    /*SqlConnection con = new SqlConnection(connectionString);*/


    /*con.Open();
    if (con.State == System.Data.ConnectionState.Open)
    {*/

    /*            Console.WriteLine("connection establish");
    */



    //inserting data into Database
    /*string query = "insert into employeeTable values(@Name,@Email,@Salary)";
      SqlCommand cmd = new SqlCommand(query, con);


    cmd.Parameters.AddWithValue("Name", name);
    cmd.Parameters.AddWithValue("Email", email);
    cmd.Parameters.AddWithValue("Salary", salary);
    int result = cmd.ExecuteNonQuery();
    if (result > 0)
    {
        Console.WriteLine("Data Inserted Successfully");
    }
    else
    {
        Console.WriteLine("FAILED to insert data");
    }*/



    // retriving data from database and displaying it 

    /*string query1 = "select * from employeeTable";
    SqlCommand cmd1 = new SqlCommand(query1, con);
    Console.WriteLine("Data in the Database is : ");
    SqlDataReader rd = cmd1.ExecuteReader();
    while (rd.Read())
    {
        Console.WriteLine("id = " + rd["Id"] + "\n  name = " + rd["Name"] +
            "\n  email = " + rd["Email"] + "\n  Salary =" + rd["salary"]);
    }*/

    //retriving total number of rows in table
    /* SqlCommand cmd = new SqlCommand("select * from employeeTable",con);
     SqlDataReader rd =  cmd.ExecuteReader();
     Console.WriteLine("fieldCount is : "+rd.FieldCount);*/

    //hasrows or not
    /*Console.WriteLine(rd.HasRows);*/

    //to check whether a particular element exist or not
    /* SqlCommand cmd = new SqlCommand("select Name from employeeTable where Salary = 30000", con);
     SqlDataReader rd = cmd.ExecuteReader();
     if (rd == null)
     {
         Console.WriteLine("no such data found");
     }
     else
     {
         while (rd.Read())
         {
             Console.WriteLine(rd["Name"] + " has salary 30000");
         }
     }

 }
 con.Close();
}*/
    /*catch (Exception e)
    {
        Console.WriteLine("Cant able to connect to database");
    }
    finally
    {
        Console.WriteLine("\nthank you");
    }*/

    /*in sqlcommand we have to open and close the connection 
            but in sqldataadapter there is not Need to open and close the class 
            it happens automatically inside it.*/
    /*sqldatadapter has two class in it dataset and datatable*/

    //dataset
    /*if we are working with multiple table and they have relations between them then dataset is used*/
    //datatable
    /*if we are working with single table and has no relations then we us datatable*/

    //using dataset
    /*SqlConnection con = new SqlConnection(connectionString);
    SqlDataAdapter adapter = new SqlDataAdapter("select * from employeeTable",con);
    DataSet ds = new DataSet();
    adapter.Fill(ds);
    foreach(DataRow row in ds.Tables[0].Rows)
    {
        Console.WriteLine(row["Name"]);

    }*/


    //using datatable
    SqlConnection con = new SqlConnection(connectionString);
    SqlDataAdapter adapter = new SqlDataAdapter("select * from employeeTable", con);
    DataTable dt = new DataTable();
    adapter.Fill(dt);
    foreach (DataRow row in dt.Rows)
    {
        Console.WriteLine(row["Name"]);

    }
    Console.ReadLine();
}



