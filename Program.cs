using SQL_Practice;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SQLPractice
{
    internal class Program
    {
        
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Enter 1 to get all Employees\nEnter 2 to get Employee by Id\nEnter 3 to Add new Employee\nEnter 4 to delete an employee by Id");
                int input = int.Parse(Console.ReadLine());
                EmployeeManager manager = new EmployeeManager(new SqlRepository());
                switch (input)
                {
                    case 1: manager.GetEmployees(); break;
                    case 2: manager.GetEmployee(); break;
                    case 3: manager.Create(); break;
                    case 4: manager.Delete(); break;
                    default: Console.WriteLine("Invalid Entry"); break;
                }
            }
        }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }
        public string Designation { get; set; }
        public int DeptId { get; set; }
        public override string ToString()
        {
            
            var st = $"ID: {Id}\nName: {EmployeeName}\nSalary: {Salary}\nDesignation: {Designation}\nDeptId: {DeptId}  \n-----------------\n";
            return st;
        }
    }
}
