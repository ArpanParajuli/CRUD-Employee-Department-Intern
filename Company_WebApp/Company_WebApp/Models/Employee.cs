using System.ComponentModel.DataAnnotations;

namespace Company_WebApp.Models
{
    public class Employee
    {

        [Required , Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(maximumLength: 50, MinimumLength = 1)]
        public string Email { get; set; } = string.Empty;

        [Required, StringLength(maximumLength: 20, MinimumLength = 1)]
        public string Phone { get; set; } = string.Empty;
        
         [Required, StringLength(maximumLength: 100, MinimumLength = 1)]
        public string Address { get; set; } = string.Empty;

       
         public int DepartmentId { get; set; }

        public Department Department { get; set; } = null!;

    }
}
