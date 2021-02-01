
using System.ComponentModel.DataAnnotations;

namespace TestForJob.Models
{
    //This class is a package of login values
    public class LoginValuesModel
    {
        [EmailAddress(ErrorMessage = "Invalid email's format")]
        [StringLength(100, ErrorMessage = "The email must have less than 100 characters")]
        [Display(Description = "Type the user's email")]
        [Required(ErrorMessage = "It is necessary the user's email")]
        public string email { set; get; }

        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The pass most have more than 6 characters and less than 20")]
        [Display(Description = "Type the user's password")]
        [Required(ErrorMessage = "It is necessary the user's password")]
        public string password { set; get; }
    }
}