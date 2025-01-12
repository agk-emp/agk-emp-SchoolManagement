using SchoolProject.Core.Wrappers;

namespace SchoolProject.test.ServicesTest.Wrappers
{
    public class QueryableWrapper<T> : IQueryableWrapper<T> where T : class
    {
        public async Task<PaginatedResponse<T>> GetPaginated(IQueryable<T> source,
            int pageNumber, int pageSize)
        {
            return await source.ToPaginatedResult<T>(pageNumber, pageSize);
        }
    }
}
