using MCU_Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace MCU_Api.Controllers
{
    [ApiController]
    [Route("MCUs")]
    public class MCUsCategoriesController : ControllerBase
    {
        private readonly ILogger<MCUsCategoriesController> _logger;

        public MCUsCategoriesController(ILogger<MCUsCategoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "MCUs")]
        [ProducesResponseType(typeof(MCUsCategories), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        public IActionResult GetMCUs()
        {
            Console.WriteLine($"{this.User.Identity!.Name} GET->MCUs");
            var filePath = $"{Directory.GetCurrentDirectory()}/Utils/MCUsCategories.json";
            return File(System.IO.File.ReadAllBytes(filePath),"application/json");
        }

        [HttpGet("{category}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        public IActionResult GetGenericModelByCategory(string category, [FromQuery] int limit = 100)
        {
            Console.WriteLine($"{this.User.Identity!.Name} GET->MCUs/{category} LIMIT: {limit}");
            var file = @$"{__RootApp.ApiDataDirectory}\_{category.ToLower().Trim()}_generic.json";
            var jArray = JArray.Parse(System.IO.File.ReadAllText(file));
            JArray _tmpArray = new JArray();
            
            for (int i = 0; i < limit; i++)
                _tmpArray.Add(jArray[Random.Shared.Next(jArray!.Count-1)]);

            return File(Encoding.UTF8.GetBytes(_tmpArray.ToString()),"application/json");
        }

        [HttpGet("{category}/{id}")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(403)]
        public IActionResult GetGenericModelByCategoryAndID(string category, int id)
        {
            Console.WriteLine($"{this.User.Identity!.Name} GET->MCUs/{category} ID: {id}");
            var file = @$"{__RootApp.ApiDataDirectory}\_{category.ToLower().Trim()}_generic.json";
            var jArray = JArray.Parse(System.IO.File.ReadAllText(file));

            var item = jArray.FirstOrDefault(e => (int?)e["ID"] == id);
            if (item == null)
                return BadRequest();
            return File(Encoding.UTF8.GetBytes(item!.ToString()), "application/json");
        }
    }
}
