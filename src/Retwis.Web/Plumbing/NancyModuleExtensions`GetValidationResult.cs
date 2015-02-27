using System.Linq;
using Nancy;
using Nancy.Validation;

namespace Retwis.Web.Plumbing
{
    public static partial class NancyModuleExtensions
    {
        public static Response GetValidationResult(this NancyModule module, ModelValidationResult result)
        {
            return module.Response.AsJson(new
            {
                Message = "The request is invalid",
                ModelState = result.Errors
                    .ToDictionary(x => x.Key, x => x.Value.Select(e => e.ErrorMessage))
                    .ToArray()
            }).WithStatusCode(HttpStatusCode.BadRequest);
        }
    }
}