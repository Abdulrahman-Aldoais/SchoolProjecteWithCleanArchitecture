﻿using Microsoft.EntityFrameworkCore;
using School.Application.Features.Students.Dtos.GetList;
using School.Application.Repositories.StudentRepository;

namespace School.Application.Service.StudentServices
{
    public class StudentService : IStudentService
    {

        private readonly IStudentReadRepository _studentReadRepository;
        public StudentService(IStudentReadRepository studentReadRepository)
        {

            _studentReadRepository = studentReadRepository;
        }
        public async Task<List<GetStudentListOutput>> GetAllStudentAsync()
        {
            var query = _studentReadRepository.GetAll()
                .Include(s => s.Department);
            return await query.Select(x => new GetStudentListOutput
            {
                Id = x.Id,
                Name = x.Name,
                Age = x.Age,
                CreateTime = x.CreateTime,
                DepartmentName = x.Department.Name
            }).ToListAsync();
        }
    }
}
