using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
namespace TestForJob.Models
{
    public abstract class BaseUserModel
    {

        [Display(Description = "Type the user's first name")]
        [Required(ErrorMessage = "It is necessary the user's first name")]
        public string firstName { get; set; }

        [Display(Description = "Type the user's last name")]
        [Required(ErrorMessage = "It is necessary the user's last name")]
        public string lastName { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "The phone number must have 8 digits")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "The phone number's format is: 88223344")]
        [Required(ErrorMessage = "It is necessary the user's phone number")]
        [Display(Name = "Type the user's phone number")]
        public string cellPhoneNumber { get; set; }

        [Display(Description = "Select the user's date entry")]
        [Required(ErrorMessage = "It is necessary the user's date entry")]
        public DateTime entryDate { get; set; }

        //Parse Model to json object
        public JObject toJSON()
        {
            string modelJson = new JavaScriptSerializer().Serialize(this);
            return JObject.Parse(modelJson);
        }

        //Parse Json object into string
        public string getStringFromJson(JObject modelJson)
        {
            return modelJson.ToString();
        }

        //This fills the fields of derived model
        public abstract void fillFromJson(JObject modelJson);

        //DataRow in abstract sense is like a register or row in SQL table (appends row to table)
        public abstract void convertToDataRow(DataTable table);
    }
}