﻿using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Service.Results;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
