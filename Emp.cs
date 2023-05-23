using SQLPractice;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Practice
{
    internal class SqlRepository
    {


        public static void Main()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee
                {
                    DeptId= 1,
                    Designation = "HR",
                    EmployeeName = "akash",
                },
                new Employee
                {
                    DeptId= 2,
                    Designation = "Dev",
                    EmployeeName = "ramesh"
                },
            };
            // sort employees based on id
            var orderedemp = from employee in employees orderby employee.DeptId select employee;
            foreach(var item in orderedemp)
            {
                Console.WriteLine(item.DeptId+" "+item.EmployeeName);
            }
            // get employee whose deptid is 1
            Console.WriteLine("----------------");
            var emp = (from employee in employees where employee.DeptId == 1 || employee.DeptId == 3 select employee).FirstOrDefault();
            Console.WriteLine(emp.DeptId +" "+emp.EmployeeName);
            // get count of employees
            var count = (from employee in employees select employee).Count();
            Console.WriteLine("number of employees: "+count);
        }
        String ConnectionString = @"Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True;";
        public   List<Employee> GetEmployees()
        {   

            string SQL = "select * from Employee";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Employee> employees = new List<Employee>();
            while (reader.Read())
            {
                var employee = new Employee();
                employee.Id = reader.GetInt32(0);
                employee.EmployeeName = reader.GetString(1);
                employee.Salary = reader.GetDecimal(2);
                employee.Designation = reader.GetString(3);
                employee.DeptId = reader.GetInt32(4);
                employees.Add(employee);
            }
            connection.Close();
            return employees;
        }
        public   Employee GetEmployeeId(int employeeId)
        {
            string SQL = $"select * from Employee where Id = {employeeId}";
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlCommand command = new SqlCommand(SQL, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Employee employee = null;
            while (reader.Read())
            {
                employee = new Employee();
                employee.Id = reader.GetInt32(0);
                employee.EmployeeName = reader.GetString(1);
                employee.Salary = reader.GetDecimal(2);
                employee.Designation = reader.GetString(3);
                employee.DeptId = reader.GetInt32(4);
            }
            connection.Close();
            return employee;
        }
        public   bool DeleteEmployeeById(int employeeId)
        {
            var Sql = @$"DELETE FROM EMPLOYEE WHERE ID = {employeeId}";

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Sql, con);
            con.Open();
            int output = sqlCommand.ExecuteNonQuery();
            con.Close();
            return output > 0;
        }
        public   bool InsertEmployee(Employee employee)
        {
            var Sql = @$"insert into Employee values('{employee.EmployeeName}',{employee.Salary}, '{employee.Designation}',{employee.DeptId})";

            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand sqlCommand = new SqlCommand(Sql, con);
            con.Open();
            int output = sqlCommand.ExecuteNonQuery();
            con.Close();
            return output > 0;
        }
    }
}
