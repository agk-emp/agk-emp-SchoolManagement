﻿using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Users.Queries.Models
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
    }
}
