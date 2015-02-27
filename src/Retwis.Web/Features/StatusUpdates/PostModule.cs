using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;
using Retwis.Data.Features.StatusUpdates;
using Retwis.Web.Plumbing;

namespace Retwis.Web.Features.StatusUpdates
{
    public class PostModule : NancyModule
    {
        public PostModule(IStatusUpdater statusUpdater)
        {
            Post["/post", true] = async (o, context) =>
            {
                var dto = this.Bind<PostRequestDto>();
                var validationResult = this.Validate(dto);

                if (!validationResult.IsValid)
                {
                    return this.GetValidationResult(validationResult);
                }
                
                await statusUpdater.UpdateStatusAsync(
                    this.GetCurrentUserIdentifier(),
                    dto.Status);

                return Response.AsRedirect("/");
            };
        }
    }
}
