using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstSample
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [Index]
        [Required]
        public DateTime HireDate { get; set; }

        [NotMapped]
        public TimeSpan HiredFor => DateTime.Today.Subtract(HireDate);
        
        //[ForeignKey("Department")]
        public string DepartmentName { get; set; }

        [ForeignKey("DepartmentName")]
        public Department Department { get; set; }

        public Employee()
        {
            HireDate = DateTime.Today;
        }


    }
}
