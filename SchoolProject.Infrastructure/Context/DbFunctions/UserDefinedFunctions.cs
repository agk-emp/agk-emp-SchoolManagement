using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Infrastructure.Context.DbFunctions
{
    public static class UserDefinedFunctions
    {
        [DbFunction("GetInstructorsTotalSalaries", Schema = "dbo")]
        public static decimal GetInstructorsTotalSalaries()
        {
            throw new NotImplementedException();
        }
    }
}