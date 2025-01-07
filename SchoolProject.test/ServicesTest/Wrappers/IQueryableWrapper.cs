using SchoolProject.Core.Wrappers;

namespace SchoolProject.test.ServicesTest.Wrappers
{
    public interface IQueryableWrapper<T>
    {
        public Task<PaginatedResponse<T>> GetPaginated(IQueryable<T> source,
            int pageNumber, int pageSize);
    }
}
