using SQLPractice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Practice
{
    internal class EmployeeManager
    {
        private readonly SqlRepository repo;

        public EmployeeManager(SqlRepository repo)
        {
            this.repo = repo;
        }
        public  void Create()
        {
            Employee employee= new Employee();
            Console.Write("Enter Name:");
            employee.EmployeeName = Console.ReadLine();
            Console.Write("Enter DeptId:");
            employee.DeptId = int.Parse(Console.ReadLine());
            Console.Write("Enter Employee Designation:");
            employee.Designation = Console.ReadLine();
            Console.Write("Enter Employee Salary:");
            employee.Salary = decimal.Parse(Console.ReadLine());

            var flag = repo.InsertEmployee(employee);
            if (flag)
            {
                Console.WriteLine("Employee Created Successfully..");
            }
            else
            {
                Console.WriteLine("Failed While Adding Employee");
            }
        }
        public void Delete()
        {
            Console.Write("Enter the Employee Id to delete:");
            int id = int.Parse(Console.ReadLine());
            var flag = repo.DeleteEmployeeById(id);
            if (flag)
            {
                Console.WriteLine("Employee deleted Successfully..");
            }
            else
            {
                Console.WriteLine("Failed While Adding Employee");
            }
        }
        public void GetEmployee()
        {
            Console.Write("Enter Employee Id:");
            int id = int.Parse(Console.ReadLine());

            var employee = repo.GetEmployeeId(id);
            if(employee== null)
            {
                Console.WriteLine($"Employee with ID: {id} does not exists");
            }
            else
            {
                Console.WriteLine(employee.ToString());
            }
        }
        public void GetEmployees()
        {
            var employees = repo.GetEmployees();
            if (employees.Count<=0)
            {
                Console.WriteLine($"list is empty");
            }
            else
            {
                foreach(var item in employees)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }
    }
}
