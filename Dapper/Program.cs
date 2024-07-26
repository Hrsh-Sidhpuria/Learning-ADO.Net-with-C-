/* using Dapper is a Micro-ORM (Object Relational Mapping) framework .
 implementing CRUD operation using dapper framework.
*/

using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

employeeData emp = new employeeData();

// 1 - Create
//to insert data into database
/*Employee em = new Employee()
{
    Name = "Harsh",
    Email = "harsh960s@xyz.com",
    Salary = "100000"

};
emp.insertData(em);*/

// 2 - Read
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

// 3 - Update
//to update data into database
/*Employee updateEmp = new Employee()
{
    Name = "HarshSidh",
    Email = "harsh919@xyz.com",
    Salary = "100000"

};
emp.updateDataById(updateEmp,1);
*/

// 4 - Delete
//to update data into database
/*emp.DeleteById(6);*/


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

  

    //insert data into the table.
    public bool insertData(Employee emp)
    {
        string insertQuery = "insert into employeeTable (Name,Email,Salary) Values (@Name,@Email,@Salary)";
        var parameter = new DynamicParameters();
        parameter.Add("Name",emp.Name);
        parameter.Add("Email", emp.Email);
        parameter.Add("Salary", emp.Salary);
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //Execute - execute a command one or multiple times and return the number of affected rows.
                //QueryFirst - it execute a query and map the first result
                int rows = connection.Execute(insertQuery, parameter);
                if (rows > 0)
                {
                    Console.WriteLine("Data Insert Sucessfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("No Such data Found in the database");
                    return false;
                }

            }
        }
        catch(SqlException ex)
        {
            Console.WriteLine("Failed to connect to database" + ex);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to connect to database" +ex);
            return false;
        }
        

    }


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
                Console.WriteLine(emp.Id);
                Console.WriteLine("Name : " + emp.Name);
                Console.WriteLine("Email : " + emp.Email);
                Console.WriteLine("Salary : " + emp.Salary);

            }
        }
    }

    //Method to get employee data by id .
    public Employee getById(int Id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            Console.WriteLine("Database Connected Successfully...");

            string queryGetById = "SELECT * FROM employeeTable where Id = @Id";

            //Query - with this method we can execute a query and map a result .
            var emps = connection.QueryFirstOrDefault<Employee>(queryGetById, new { Id });
            if (emps != null)
            {
                return emps;
            }
            else
            {
                return null;
            }
        }
    }

    //method to update a data
    public bool updateDataById(Employee emp,int id)
    {
        string updateQuery = "update employeeTable set Name = @Name,Email = @Email,Salary=@Salary where Id = @Id ";
        var parameter = new DynamicParameters();
        parameter.Add("Name", emp.Name);
        parameter.Add("Email", emp.Email);
        parameter.Add("Salary", emp.Salary);
        parameter.Add("Id", id);
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //Execute - execute a command one or multiple times and return the number of affected rows.
                int rows = connection.Execute(updateQuery, parameter);
                if (rows > 0)
                {
                    Console.WriteLine("Data Updated Sucessfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Something Went Wrong!");
                    return false;
                }

            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Failed to connect to database" + ex);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to connect to database" + ex);
            return false;
        }


    }


    //Delete data from database by Id
    public bool DeleteById(int id)
    {
        string DeleteQuery = "Delete from employeeTable where Id = @Id";
        var parameter = new DynamicParameters();
        parameter.Add("Id", id);
        try
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //Execute - execute a command one or multiple times and return the number of affected rows.
                int rows = connection.Execute(DeleteQuery, parameter);
                if (rows > 0)
                {
                    Console.WriteLine("Data Deleted Sucessfully");
                    return true;
                }
                else
                {
                    Console.WriteLine("Data is not found in current database !");
                    return false;
                }

            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Failed to connect to database" + ex);
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to connect to database" + ex);
            return false;
        }


    }

}
