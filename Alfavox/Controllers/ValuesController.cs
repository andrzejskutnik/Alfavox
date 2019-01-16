using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Alfavox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyValuesController : Controller
    {
        IRepository _repo;
        public KeyValuesController(IRepository repository)
        {
            _repo = repository;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var result = _repo.GetValuesForKey(id);
            if (result != null && result.Count() > 0)
                return Json(result, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
            return NoContent();
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (value != null)
            {
                var dataKey = value.ParseModel();
                var result = _repo.GetValuesForKeys(dataKey);
                if (result != null && result.Count() > 0)
                    return Json(result, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
            }
            return NoContent();
        }
    }
    
    internal static class Ex
    {
        public static IEnumerable<int> ParseModel(this string model)
        {

            var toParse = model.Split(',');
            var tempList = new List<int>();
            foreach (var m in toParse)
            {
                if (int.TryParse(m, out int i)) tempList.Add(i);
            }

            if (tempList.Count() == 1)
            {
                return new List<int> { tempList.First() };
            }
            return tempList;
        }
    }
}
