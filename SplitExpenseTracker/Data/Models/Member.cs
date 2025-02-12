using System.ComponentModel.DataAnnotations;

namespace SplitExpenseTracker.Data.Models
{
    public class Member
    {
        [Key]
        public int Member_Id { get; set; }
        [Required(ErrorMessage ="Name is Required!")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Name must contain only letters!")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Email is Required!")]
        [EmailAddress(ErrorMessage = "Invalid email format!")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "Mobile is Required!")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile number must be 10 digits!")]
        public string Mobile { get; set; } = string.Empty;

    }
}
