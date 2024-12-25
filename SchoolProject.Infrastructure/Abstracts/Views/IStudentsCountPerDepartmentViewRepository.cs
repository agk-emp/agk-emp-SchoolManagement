using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts.Views
{
    public interface IStudentsCountPerDepartmentViewRepository :
        IGenericRepository<StudentsCountPerDepartmentView>
    {
    }
}
