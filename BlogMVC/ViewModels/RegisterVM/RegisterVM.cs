using System.ComponentModel.DataAnnotations;

namespace BlogMVC.ViewModels.RegisterVM
{
    public class RegisterVM
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
