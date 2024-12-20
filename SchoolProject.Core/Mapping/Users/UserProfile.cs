﻿using AutoMapper;

namespace SchoolProject.Core.Mapping.Users
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            RegisterUserMapping();
            UpdateUserMapping();

            GetUserByIdMapping();
            GetUsersPaginatedMapping();
        }
    }
}
