using System;
using System.Collections.Generic;

namespace EFCore_Scaffolding.Models
{
    public partial class Employees
    {
        public int EmpUniqueId { get; set; }
        public int DeptUniqueId { get; set; }
        public string Designation { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpLastName { get; set; }
        public int EmpNo { get; set; }
        public int Salary { get; set; }

        public virtual Departments DeptUnique { get; set; }
    }
}
