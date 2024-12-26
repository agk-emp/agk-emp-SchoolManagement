using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.InfrastructureBases;
using System.Data;

namespace SchoolProject.Infrastructure.Repositories.Procedures
{
    public class StoredProceduresRepository : GenericRepository<GETStudentsCountForDepartmentProcedure>,
         IStoredProceduresRepository
    {
        public StoredProceduresRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<GETStudentsCountForDepartmentProcedure> GetStudentsCountForThisDepartment(int id)
        {
            var idParameter = new SqlParameter("@DID", SqlDbType.Int)
            {
                Value = id,
            };

            //To do getting why should we turn it into list???

            var result = await _dbContext.GETStudentsCountForDepartmentProcedure
                .FromSql($"Exec dbo.GETStudentsCountForDepartment {idParameter}").ToListAsync();

            return result.SingleOrDefault();
        }
    }
}
