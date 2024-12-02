using Microsoft.Extensions.Localization;
using SchoolProject.Infrastructure.Resources;
using System.Net;

namespace SchoolProject.Core.Bases
{
    public class ResponseHandler
    {
        protected readonly IStringLocalizer<SharedResources> _localizer;
        public ResponseHandler(IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
        }

        public Response<T> Success<T>(T entity, object Meta = null)
        {
            return new Response<T>
            {
                Data = entity,
                Meta = Meta,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[SharedResourcesKeys.Updated],
            };
        }

        public Response<T> Unauthorized<T>()
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = _localizer[SharedResourcesKeys.Unauthorized]
            };
        }

        public Response<T> NotFound<T>()
        {
            return new Response<T>()
            {
                Message = _localizer[SharedResourcesKeys.NotFound],
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Meta = Meta,
                Data = entity,
                Message = _localizer[SharedResourcesKeys.Added],
            };
        }

        public Response<T> Created<T>()
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = _localizer[SharedResourcesKeys.Added],
            };
        }

        public Response<T> UnprocessableEntity<T>(string message = null)
        {
            return new Response<T>()
            {
                Message = _localizer[message] ?? _localizer[SharedResourcesKeys.Unprocessable],
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
            };
        }

        public Response<T> Failure<T>(string message)
        {
            return new Response<T>()
            {
                Message = message,
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
            };
        }

        public Response<T> Deleted<T>()
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = _localizer[SharedResourcesKeys.Deleted],
            };
        }
    }
}