using Microsoft.EntityFrameworkCore;

namespace SchoolProject.Core.Wrappers
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResponse<T>>
            ToPaginatedResult<T>(this IQueryable<T> source, int pageNumber, int pageSize)
            where T : class
        {
            if (source is null)
                throw new Exception();

            var count = await source.AsNoTracking().CountAsync();
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 || pageSize > count ? 10 : pageSize;


            if (count == 0)
            {
                return PaginatedResponse<T>.Success(new List<T>(), count, pageNumber, pageSize);
            }

            var data = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResponse<T>.Success(data, count, pageNumber, pageSize);
        }
    }
}
