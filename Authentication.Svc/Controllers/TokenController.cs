using Authentication.Svc.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Authentication.Svc.Framework.Models;
using Authentication.Svc.Validators;

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
        [Consumes("application/json")]
        public ActionResult GenerateToken([FromBody] JsonObject tokenRequest)
        {
            TokenRequestValidator.Validate(tokenRequest);

            TokenResponse tokenResponse = _grantValidatorService.ValidateGrant(tokenRequest);

            //Maybe HttpResponse is set directly in GrantValidatorService and this method is void.

            // Can potentially leverage new .Net 8 Global Exception handler to catch and return exception messages.
            return Ok(tokenResponse);
        }
    }
}
