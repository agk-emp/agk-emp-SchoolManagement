using Microsoft.AspNetCore.Mvc;

namespace SchoolProject.Service.Requests
{
    public class UpdateUserClaims
    {
        [FromRoute]
        public int id { get; set; }
        [FromBody]
        public List<int> Claims { get; set; }
    }
}
