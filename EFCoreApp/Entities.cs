using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreApp
{
    public class Department
    {
        [Key]
        public int DeptUniqueId { get; set; }
        [Required]
        public int DeptNo { get; set; }
        [Required]
        [MaxLength(20)]
        public string DeptName { get; set; }
        [Required]
        [MaxLength(20)]
        public string Location { get; set; }
        [Required]
        public int Capacity { get; set; }
    }

    public class Employee
    {
        [Key]
        public int EmpUniqueId { get; set; }
        [Required]
        public int EmpNo { get; set; }
        [Required]
        [MaxLength(80)]
        public string EmpFirstName { get; set; }
        [MaxLength(80)]
        public string EmpLastName { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        [MaxLength(20)]
        public string Designation { get; set; }
        public int DeptUniqueId { get; set; }
        [ForeignKey("DeptUniqueId")]
        public Department Department { get; set; }
    }
}
