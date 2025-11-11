using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Company_WebApp.Models
{
    public class Department
    {   

        [Required, Key]
        public int Id { get; set; }

        [Required, StringLength(maximumLength: 50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
        
        [Required ,StringLength(maximumLength: 100 , MinimumLength = 1)]
         public string Description { get; set; } = string.Empty;
        
       public List<Employee> Employees { get; set; } = new List<Employee>();

    }
}
