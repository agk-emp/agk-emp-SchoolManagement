using Microsoft.AspNetCore.Mvc;

namespace SchoolProject.Service.Requests
{
    public class UpdateUserRoles
    {
        [FromRoute]
        public int id { get; set; }

        [FromBody]
        public List<RolesUpdated> RolesUpdatedBody { get; set; }
        public class RolesUpdated
        {
            public int Id { get; set; }
        }
    }
}
