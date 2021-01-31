using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace TestForJob.Models
{
    public class PromoUserModel : BaseModel
    {
        //This field fills automatically, it is not necessary a GUI
        public int id { get; set; }

        [Display(Description ="Type the user's first name")]
        [Required(ErrorMessage ="It is necessary the user's first name")]
        public string firstName { get; set; }

        [Display(Description = "Type the user's last name")]
        [Required(ErrorMessage = "It is necessary the user's last name")]
        public string lastName { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "The phone number must have 8 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The phone number's format is: 88223344")]
        [Required(ErrorMessage = "It is necessary the user's phone number")]
        [Display(Name = "Type the user's phone number")]
        public string cellPhoneNumber { get; set; }

        [Display(Description = "Type the user's promo type")]
        [Required(ErrorMessage = "It is necessary the user's promo type")]
        public string typeOfPromo { get; set; }

        [Display(Description = "Select the user's date entry")]
        [Required(ErrorMessage = "It is necessary the user's date entry")]
        public DateTime entryDate { get; set; }

        public override void fillFromJson(JObject modelJson)
        {
            id = Convert.ToInt32((string)modelJson["id"]);
            firstName = (string) modelJson["firstName"];
            lastName = (string) modelJson["lastName"];
            cellPhoneNumber = (string) modelJson["cellPhoneNumber"];
            typeOfPromo = (string) modelJson["typeOfPromo"];
            entryDate = Convert.ToDateTime((string)modelJson["entryDate"]);

        }

        public override void convertToDataRow(DataTable table)
        {
            table.Rows.Add(
                id.ToString(),
                firstName,
                lastName,
                cellPhoneNumber,
                typeOfPromo,
                entryDate.ToString()
            );
        }
    }
}