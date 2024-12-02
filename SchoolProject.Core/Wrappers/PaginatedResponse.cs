using SchoolProject.Core.Bases;
using System.Net;

namespace SchoolProject.Core.Wrappers
{
    public class PaginatedResponse<T> : Response<List<T>>
    {
        internal PaginatedResponse(bool succeeded, List<T> data = default, int count = 0, int page = 1, int pageSize = 10)
        {
            Succeeded = succeeded;
            Data = data;
            count = count;
            CurrentPage = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            StatusCode = HttpStatusCode.OK;
        }

        public static PaginatedResponse<T> Success(List<T> data, int count, int page, int pageSize)
        {
            return new PaginatedResponse<T>(true, data, count, page, pageSize);
        }
        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
