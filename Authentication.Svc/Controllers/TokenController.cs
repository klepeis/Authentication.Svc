using Authentication.Svc.Framework.Models;
using Authentication.Svc.Framework.Validators;
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

#pragma warning disable IDE0290 // Use primary constructor
        public TokenController(IGrantValidatorService grantValidatorService)
#pragma warning restore IDE0290 // Use primary constructor
        {
            _grantValidatorService = grantValidatorService;
        }

        /// <summary>
        /// Api that injests a dynamic token request and generates a token response object based on the rules for the grant type.
        /// </summary>
        /// <param name="tokenRequest" cref="TokenResponse" >Varies depending on the requirements of the grant type.</param>
        /// <returns>A Token</returns>
        [HttpPost]
        [Consumes("application/json")]
        public ActionResult<TokenResponse> GenerateToken([FromBody] JsonObject tokenRequest)
        {
            TokenRequestValidator.Validate(tokenRequest);
            TokenResponse tokenResponse = _grantValidatorService.ValidateGrant(tokenRequest);

            // Can potentially leverage new .Net 8 Global Exception handler to catch and return exception messages.
            return Ok(tokenResponse);
        }
    }
}
