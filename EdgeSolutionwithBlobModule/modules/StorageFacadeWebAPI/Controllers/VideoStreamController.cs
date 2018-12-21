using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StorageFacadeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoStreamController : Controller
    {
        // POST api/values
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post(string FileName, int PartN, [FromForm]IFormFile file)
        {
            return NoContent();
        }
    }
}
