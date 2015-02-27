using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Validation;
using Retwis.Data.Features.Authentication;
using Retwis.Web.Plumbing;

namespace Retwis.Web.Features.Authentication
{
    public class RegisterModule : NancyModule
    {
        public RegisterModule(IAuthenticationService authenticationService)
        {
            Post["/register", true] = async (o, token) =>
            {
                var dto = this.Bind<LogInRequestDto>();
                var validationResult = this.Validate(dto);

                if (!validationResult.IsValid)
                {
                    return this.GetValidationResult(validationResult);
                }

                var user = await authenticationService.RegisterAsync(dto.Username, dto.Password);

                return this.LoginAndRedirect(user.Identifier);
            };
        }
    }
}