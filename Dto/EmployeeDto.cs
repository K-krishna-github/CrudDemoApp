using CrudDemoApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudDemoApp.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FatherName { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
    }
    public class AddEmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FatherName { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
    }

    public class EditEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FatherName { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
    }
}
