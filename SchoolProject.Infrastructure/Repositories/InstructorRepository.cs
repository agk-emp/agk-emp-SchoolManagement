﻿using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.TabledFunctions;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Context;
using SchoolProject.Infrastructure.Context.DbFunctions;
using SchoolProject.Infrastructure.InfrastructureBases;

namespace SchoolProject.Infrastructure.Repositories
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public decimal GetInstructorsTotalSalaries()
        {
            return _dbContext.Instructors.
                Select(ins => UserDefinedFunctions.GetInstructorsTotalSalaries())
                .FirstOrDefault();
        }

        public IQueryable<GetInstructorsDetailsFunction> GetInstructorsDetails()
        {
            var result = _dbContext.GetInstructorsDetails();
            return result;
        }
    }
}