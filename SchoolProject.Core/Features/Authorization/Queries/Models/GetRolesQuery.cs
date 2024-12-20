﻿using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Queries.Results;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRolesQuery : IRequest<Response<List<GetRolesResult>>>
    {
    }
}
