using System.ComponentModel.DataAnnotations;
using WebApplication3.DTO;
using WebApplication3.Models;

namespace CapitalPlacementProject.DTO
{
    public class EmployeeAdd
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        
        public string Phone { get; set; }

        public string Nationality { get; set; }

        public string CurrentResidence { get; set; }

        public string Idnumber { get; set; }

        public DateTime? DateOfbirth { get; set; }

        public string Gender { get; set; }
        public List<Additional> QueList { get; set; }

        
    }
}
