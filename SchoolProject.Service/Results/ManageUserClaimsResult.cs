namespace SchoolProject.Service.Results
{
    public class ManageUserClaimsResult
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<UserClaimsChecker> UserClaimsCheckers { get; set; }

        public class UserClaimsChecker
        {
            public int Id { get; set; }
            public string ClaimType { get; set; }
            public string ClaimValue { get; set; }
            public bool HasClaim { get; set; }
        }
    }
}
