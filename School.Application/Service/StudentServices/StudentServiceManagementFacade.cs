//using Microsoft.EntityFrameworkCore;
//using School.Application.Features.Students.Dtos.Get;
//using School.Application.Features.Students.Dtos.GetList;
//using School.Persistence.Repositories.StudentRepository;

//namespace School.Application.Service.StudentServices
//{
//    // Facade for Student Management
//    public class StudentServiceManagementFacade : IStudentServiceManagementFacade
//    {


//        private readonly IStudentReadRepository _studentReadRepository;

//        public StudentServiceManagementFacade(IStudentWriteRepository studentWriteRepository, IStudentReadRepository studentReadRepository, EnrollmentService enrollmentService)
//        {
//            _studentWriteRepository = studentWriteRepository;
//            _enrollmentService = enrollmentService;
//            _studentReadRepository = studentReadRepository;
//        }

//        public Task AddNewStudent(GetStudentOutput student)
//        {
//            throw new NotImplementedException();
//        }

//        public void DeleteStudent(int studentId)
//        {
//            throw new NotImplementedException();
//        }

//        public void EnrollStudentInCourse(int studentId, int courseId)
//        {
//            throw new NotImplementedException();
//        }

//        public async Task<List<GetStudentListOutput>> GetAllStudentAsync()
//        {
//            var query = _studentReadRepository.GetAll()
//                .Include(s => s.Department);
//            return await query.Select(x => new GetStudentListOutput
//            {
//                Id = x.Id,
//                Name = x.Name,
//                Age = x.Age,
//                DateCreated = x.DateCreated ?? DateTime.MinValue, // Use a default value if x.Date
//                DepartmentName = x.Department.Name
//            }).ToListAsync();
//        }

//        public List<GetStudentOutput> GetAllStudents()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<GetStudentOutput> GetStudentByIdAsync(int studentId)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<GetStudentOutput>> GetStudentsByCriteriaAsync(string criteria)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<int> GetStudentsCountAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<GetStudentOutput>> SearchStudentsAsync(string searchTerm)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UpdateStudentInfo(GetStudentOutput student)
//        {
//            throw new NotImplementedException();
//        }
//    }

//}
