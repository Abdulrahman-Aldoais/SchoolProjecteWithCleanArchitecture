using AutoMapper;
using Microsoft.EntityFrameworkCore;
using School.Application.Features.Students.Dtos.GetList;
using School.Domain.Entities;
using School.Persistence.Repositories.StudentRepository;
using Serilog;
namespace School.Application.Service.StudentServices
{
    public class StudentService : IStudentService
    {
        #region Filde
        private readonly IStudentReadRepository _studentReadRepository;
        private readonly IStudentWriteRepository _studentWriteRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public StudentService(IStudentReadRepository studentReadRepository,
            IStudentWriteRepository studentWriteRepository,
            IMapper mapper)
        {

            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _mapper = mapper;
        }

        #endregion

        #region Action
        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentWriteRepository.BeginTransaction();
            try
            {
                await _studentWriteRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message);
                return "Falied";
            }

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
                DateCreated = x.DateCreated ?? DateTime.MinValue, // Use a default value if x.Date
                DepartmentName = x.Department.Name
            }).ToListAsync();
        }

        public async Task<Student> GetStudentByIDWithIncludeAsync(Guid id)
        {
            var student = await _studentReadRepository.GetTableNoTracking()
                                               .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return student;
        }


        public async Task<string> UpdateStudentInfo(Student student)
        {
            await _studentWriteRepository.UpdateAsync(student);
            return "Success";
        }
        #endregion
    }
}
