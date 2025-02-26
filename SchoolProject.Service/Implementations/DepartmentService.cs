﻿using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrastructure.Abstracts;
using SchoolProject.Infrastructure.Abstracts.Procedures;
using SchoolProject.Infrastructure.Abstracts.Views;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IStudentsCountPerDepartmentViewRepository
            _studentsCountPerDepartmentViewRepository;
        private readonly IStoredProceduresRepository _storedProceduresRepository;

        public DepartmentService(IDepartmentRepository departmentRepository,
            IStudentsCountPerDepartmentViewRepository studentsCountPerDepartmentViewRepository,
            IStoredProceduresRepository storedProceduresRepository)
        {
            _departmentRepository = departmentRepository;
            _studentsCountPerDepartmentViewRepository = studentsCountPerDepartmentViewRepository;
            _storedProceduresRepository = storedProceduresRepository;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            var department = await _departmentRepository.GetTableNoTracking()
                .Where(d => d.DID == id)
                .Include(d => d.DepartmentSubjects)
                .ThenInclude(ds => ds.Subjects)
                //.Include(d => d.Students)
                .Include(d => d.Instructor)
                .Include(d => d.Instructors)
                .FirstOrDefaultAsync();

            return department;
        }

        public async Task<bool> DoesExistWithId(int id)
        {
            return await _departmentRepository.GetTableAsTracking()
                .AnyAsync(dept => dept.DID == id);
        }

        public async Task<IEnumerable<StudentsCountPerDepartmentView>> GetStudentsForEachDepartments()
        {
            var result = await _studentsCountPerDepartmentViewRepository.GetTableNoTracking()
                .ToListAsync();
            return result ?? Enumerable.Empty<StudentsCountPerDepartmentView>();
        }

        public async Task<GETStudentsCountForDepartmentProcedure>
            GetStudentsCountForThisDepartment(int id)
        {
            var result = await _storedProceduresRepository.GetStudentsCountForThisDepartment(id);
            return result;
        }
    }
}
