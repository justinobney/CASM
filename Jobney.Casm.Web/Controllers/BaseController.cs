using System.Web.Mvc;
using Jobney.Casm.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Jobney.Casm.Web.Controllers
{
    public class BaseController : Controller
    {
        protected internal JsonNetResult JsonResult(object data)
        {
            return new JsonNetResult
            {
                Data = data,
                Formatting = Formatting.Indented,
                SerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };
        }
    }
}