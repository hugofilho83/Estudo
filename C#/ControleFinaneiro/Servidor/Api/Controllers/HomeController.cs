using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers {
    [ApiVersion ("1.0")]
    [Route ("api/v{version:apiVersion}")]
    [ApiController]
    [Produces ("application/json")]
    public class HomeController {

        [HttpGet ("ApiStatus")]
        public string Get () {
            return DateTime.UtcNow.ToString ();
        }
    }
}
