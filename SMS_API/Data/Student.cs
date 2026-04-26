using System.ComponentModel.DataAnnotations;

namespace SMS_API.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string FathersName { get; set; }
        public int Standard { get; set; }
        public DateOnly DOB { get; set; }
        public string Email { get; set; }
        public string MobNo { get; set; }
    }
}
