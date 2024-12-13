using Authentication.Svc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace Authentication.Svc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IGrantValidatorService _grantValidatorService;

        public TokenController(IGrantValidatorService grantValidatorService)
        {
            _grantValidatorService = grantValidatorService;
        }

        [HttpPost]
        public ActionResult GenerateToken([FromBody] JsonObject tokenRequest)
        {
            //Validate Request contains required fields (just grant_type?)

            JsonObject tokenResponse = _grantValidatorService.ValidateGrant(tokenRequest);

            return Ok(tokenResponse);
        }
    }
}
