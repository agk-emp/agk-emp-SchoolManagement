﻿using SchoolProject.Data.Entities;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Abstracts
{
    public interface IInstructorRepository : IGenericRepository<Instructor>
    {
        decimal GetInstructorsTotalSalaries();
    }
}
