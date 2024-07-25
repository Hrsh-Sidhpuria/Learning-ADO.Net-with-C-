// See https://aka.ms/new-console-template for more information
using Dapper;
using System.Data.SqlClient;

employeeData emp = new employeeData();

//get All data
/*emp.getAllData();*/

//get by id
/*Employee e1 = emp.getById(3);
if(e1 != null)
{
    Console.WriteLine("Name : " + e1.Name);
    Console.WriteLine("Email : " + e1.Email);
    Console.WriteLine("Salary : " + e1.Salary);
}
else
{
    Console.WriteLine("Data Not Found !");
}*/



class Employee
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public string  Email { get; set; }
    public string Salary { get; set; }
}

class employeeData
{
    string connectionString = "Server=DESKTOP-VGKVPEH\\SQLEXPRESS;Database=employees;Trusted_Connection=True;";

    //Method to get all Employees data
    public void getAllData()
    {
        using (var connection = new SqlConnection(connectionString))
        {
            Console.WriteLine("Database Connected Successfully...");

            string queryCmd2 = "SELECT * FROM employeeTable";

            //Query - with this method we can execute a query and map a result .
            var emps = connection.Query<Employee>(queryCmd2);
            foreach (Employee emp in emps)
            {
                Console.Write("Employee : ");
                Console.WriteLine( emp.Id);
                Console.WriteLine("Name : "+ emp.Name);
                Console.WriteLine("Email : " + emp.Email);
                Console.WriteLine("Salary : " + emp.Salary);
                
            }
        }
    }

    //Method to get employee data by id 
    public Employee getById(int Id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            Console.WriteLine("Database Connected Successfully...");

            string queryGetById = "SELECT * FROM employeeTable where Id = @Id";

            //Query - with this method we can execute a query and map a result .
            var emps = connection.QueryFirstOrDefault<Employee>(queryGetById,new {Id});
            if(emps != null)
            {
                return emps;
            }
            else
            {
                return null;
            }
        }
    }
}

/*
                Execute - execute a command one or multiple times and return the number of affected rows.
                

                QueryFirst - it execute a query and map the first result 

                 */