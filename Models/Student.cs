using System.ComponentModel.DataAnnotations;

namespace StudentTracker.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Faculty { get; set; }
    }
}
