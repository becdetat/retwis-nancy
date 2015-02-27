using System.ComponentModel.DataAnnotations;

namespace Retwis.Web.Features.Authentication
{
    public class LogInRequestDto
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name="Password")]
        public string Password { get; set; }
    }
}