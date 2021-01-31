using System.Data;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
namespace TestForJob.Models
{
    public abstract class BaseModel
    {

        public JObject toJSON()
        {
            string modelJson = new JavaScriptSerializer().Serialize(this);
            return JObject.Parse(modelJson);
        }

        public string getStringFromJson(JObject modelJson)
        {
            return modelJson.ToString();
        }

        public abstract void fillFromJson(JObject modelJson);

        //DataRow in abstract sense is like a register or row in SQL table (appends row to table)
        public abstract void convertToDataRow(DataTable table);
    }
}