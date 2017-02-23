using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFCore_Scaffolding.Models;

namespace EFCore_Scaffolding
{
    class Program
    {
        static void Main(string[] args)
        {
            DBEfCoreContext ctx = new Models.DBEfCoreContext();
            Console.WriteLine("The Added Data is");

            foreach (var item in ctx.Departments.ToList())
            {
                Console.WriteLine(item.DeptUniqueId + "\t\t" + item.DeptNo + "\t\t" + item.DeptName + "\t\t" + item.Location + "\t\t" + item.Capacity);
            }


            Departments d = new Models.Departments();


            Departments dept = new Departments()
            {
                DeptNo = 50,
                DeptName = "Sales",
                Location = "Pune",
                Capacity = 500
            };

            
            ctx.Departments.Add(dept);
            ctx.SaveChanges();
            Console.WriteLine("Data Added Successfully");
            Console.WriteLine();
            Console.WriteLine("The Added Data is");

            foreach (var item in ctx.Departments.ToList())
            {
                Console.WriteLine(item.DeptUniqueId + "\t\t" + item.DeptNo + "\t\t" + item.DeptName + "\t\t" + item.Location + "\t\t" + item.Capacity);
            }


            Console.ReadLine();
        }
    }
}
