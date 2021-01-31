using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace TestForJob.Models
{
    public class SystemUserModel : BaseUserModel
    {
        protected const int ADMIN_ROL = 1;
        protected const int COMMERCIAL_ROL = 2;

        [EmailAddress(ErrorMessage = "Invalid email's format")]
        [StringLength(100, ErrorMessage = "The email must have less than 100 characters")]
        [Display(Description = "Type the user's email")]
        [Required(ErrorMessage = "It is necessary the user's email")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The pass most have more than 6 characters and less than 20")]
        [Display(Description = "Type the user's password")]
        [Required(ErrorMessage = "It is necessary the user's password")]
        public string password { get; set; }

        [Display(Description = "Select the user's role")]
        [Required(ErrorMessage = "It is necessary the user's rol")]
        public int role { get; set; }

        public override void fillFromJson(JObject modelJson)
        {
            firstName = (string)modelJson["firstName"];
            lastName = (string)modelJson["lastName"];
            email = (string)modelJson["email"];
            password = (string)modelJson["password"];
            role = Convert.ToInt32(modelJson["role"]);
            cellPhoneNumber = (string)modelJson["cellPhoneNumber"];
            entryDate = Convert.ToDateTime((string)modelJson["entryDate"]);
        }

        public override void convertToDataRow(DataTable table)
        {
            table.Rows.Add(
                firstName,
                lastName,
                email,
                password,
                role,
                cellPhoneNumber,
                entryDate.ToString()
            );
        }

        public bool canModifyPromoUsers()
        {
            return this.role == ADMIN_ROL;
        }

        public bool canVisualizePromoUsers()
        {
            return this.role == ADMIN_ROL || this.role == COMMERCIAL_ROL;
        }
    }
}