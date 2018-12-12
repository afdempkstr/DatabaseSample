using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstSample
{
    public class Department
    {
        [Key]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Location { get; set; }

        //[ForeignKey("DepartmentName")]
        public virtual ICollection<Employee> Employees { get; set; }

        public Department()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
