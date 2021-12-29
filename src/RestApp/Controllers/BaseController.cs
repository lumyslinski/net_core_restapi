using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RestApp.Controllers
{
    /// <summary>
    /// Base controller
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// JsonSettings property
        /// </summary>
        public JsonSerializerSettings JsonSettings { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseController()
        {
            JsonSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };
        }
    }
}
