using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Responses;
using Nancy.TinyIoc;
using Nancy.Validation;
using Retwis.Data.Features.Authentication;
using Retwis.Web.Plumbing;

namespace Retwis.Web.Features.Authentication
{
    public class LogInModule : NancyModule
    {
        private readonly IAuthenticationService _authenticationService;

        public LogInModule(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            Get["/login"] = _ => View["authentication/login"];
            Post["/dologin", true] = (o, token) => LogIn();
        }

        private async Task<dynamic> LogIn()
        {
            var dto = this.Bind<LogInRequestDto>();
            var validationResult = this.Validate(dto);

            if (!validationResult.IsValid)
            {
                return this.GetValidationResult(validationResult);
            }

            var user = await _authenticationService.GetUserAsync(dto.Username, dto.Password);
            if (user == null)
            {
                return Response
                    .AsRedirect("/login")
                    //.WithStatusCode(HttpStatusCode.Forbidden)
                    ;
            }
            return this.LoginAndRedirect(user.Identifier);
        }
    }
}
