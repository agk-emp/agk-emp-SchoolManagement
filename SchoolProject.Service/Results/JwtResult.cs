namespace SchoolProject.Service.Results
{
    public class JwtResult
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
