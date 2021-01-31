using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace TestForJob.Models
{
    public class PromoUserModel : BaseUserModel
    {
        //This field fills automatically, it is not necessary a GUI
        public int id { get; set; }

        [Display(Description = "Type the user's promo type")]
        [Required(ErrorMessage = "It is necessary the user's promo type")]
        public string typeOfPromo { get; set; }

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