using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudDemoApp.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        [InverseProperty("Role")]
        public IList<Employee> employees { get; set; }
    }
}
