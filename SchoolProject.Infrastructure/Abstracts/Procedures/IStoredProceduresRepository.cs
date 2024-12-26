using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts.Procedures
{
    public interface IStoredProceduresRepository : IGenericRepository<GETStudentsCountForDepartmentProcedure>
    {
        Task<GETStudentsCountForDepartmentProcedure>
            GetStudentsCountForThisDepartment(int id);
    }
}