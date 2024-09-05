using System.ComponentModel.DataAnnotations;

namespace backendForStudentRegisterApp.Models
{
    public class StudentEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime dateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
       

    }
}
