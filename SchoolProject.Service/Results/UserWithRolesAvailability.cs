namespace SchoolProject.Service.Results
{
    public class UserWithRolesAvailability
    {
        public int UserId { get; set; }
        public List<RolesForUserChecker> RolesChecker { get; set; }
        public class RolesForUserChecker
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool HasRole { get; set; }
        }
    }
}
