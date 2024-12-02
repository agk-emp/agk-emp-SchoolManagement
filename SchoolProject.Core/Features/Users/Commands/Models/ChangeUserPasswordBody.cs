namespace SchoolProject.Core.Features.Users.Commands.Models
{
    public class ChangeUserPasswordBody
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
