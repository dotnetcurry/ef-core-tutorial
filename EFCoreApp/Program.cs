using System;
using System.Linq;

namespace EFCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyEntities ctx = new CompanyEntities(); 
            try
            {
                Department dept = new Department()
                {
                     DeptNo=30,
                     DeptName= "Sales_For_The_IT_Goods_In_Pune_Area",
                     Location="Pune",
                     Capacity=500
                };
                Employee emp = new Employee()
                {
                     EmpNo = 102,
                     EmpFirstName = "Rohan",
                     EmpLastName = "Karnik",
                     Designation = "Manager",
                     Salary = 330000
                };

                ctx.Departments.Add(dept);
                emp.DeptUniqueId = dept.DeptUniqueId;
                ctx.Employees.Add(emp);
                ctx.SaveChanges();

                Console.WriteLine("Record Added");

                Console.WriteLine();

                Console.WriteLine("DeptUniqueId\tDeptNo\tDeptName\tLocation\tCatacity");

                foreach (var item in ctx.Departments.ToList())
                {
                    Console.WriteLine(item.DeptUniqueId + "\t\t" + item.DeptNo + "\t\t" + item.DeptName + "\t\t" + item.Location + "\t\t" + item.Capacity);
                }

                Console.WriteLine();

                Console.WriteLine("EmpUniqueId\tEmpNo\tEmpFirstName\tEmpLastName\tDesignation\tSalary\tDeptUniqueId");

                foreach (var item in ctx.Employees.ToList())
                {
                    Console.WriteLine(item.EmpUniqueId+ "\t\t" + item.EmpNo+ "\t\t" + item.EmpFirstName+ "\t\t" + item.EmpLastName+ "\t\t" + item.Designation+ "\t" + item.Salary+ "\t\t" + item.DeptUniqueId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message + ex.InnerException.Message);
            }
            Console.ReadLine();
        }
    }
}
