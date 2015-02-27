using System.ComponentModel.DataAnnotations;

namespace Retwis.Web.Features.StatusUpdates
{
    public class PostRequestDto
    {
        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }
    }
}