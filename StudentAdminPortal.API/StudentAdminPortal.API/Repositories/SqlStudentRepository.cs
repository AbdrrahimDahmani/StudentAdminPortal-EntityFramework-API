using StudentAdminPortal.API.DataModel;
using Microsoft.EntityFrameworkCore;

namespace StudentAdminPortal.API.Repositories
{
    public class SqlStudentRepository : IStudentRepository , IStudentGender
    {
        private readonly StudentAdminContext context;

        public SqlStudentRepository(StudentAdminContext context)
        {
            this.context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await context.Student
                .Include(nameof(Gender)).Include(nameof(Address))
                .ToListAsync();
        } 

       
        public async Task<List<Gender>> GetGenderAsync()
        {
           return await context.Gender.ToListAsync();
        }

        public async Task<bool> Exists(Guid studentId)
        {
            return await context.Student.AnyAsync(x => x.Id == studentId);
        }

        public async Task<Student> UpdateStudentAsync(Guid studentId, Student request)
        {
            var existingStudent = await GetStudentAsync(studentId);
            if(existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName=  request.LastName;
                existingStudent.DateOfBirth= request.DateOfBirth;
                existingStudent.Email = request.Email;
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Address.PhysicalAddress = request.Address.PhysicalAddress;
                existingStudent.Address.PostalAddress = request.Address.PostalAddress;
                await context.SaveChangesAsync();
                return existingStudent;
            }
            return null;
        }

        public async Task<Student?> DeleteStudent(Guid studentId)
        {
            var student= await GetStudentAsync(studentId);
            if(student != null)
            {
                context.Student.Remove(student);
                await context.SaveChangesAsync();
                return student;
            }
            return null;
        }

        public async Task<Student> AddStudentRequest(Student request)
        {
           var student= await context.Student.AddAsync(request);
            await context.SaveChangesAsync();
            return student.Entity;
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            var student = await GetStudentAsync(studentId);
            if(student != null)
            {
                student.ProfileImageUrl = profileImageUrl;
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }

         public async Task<Student> GetStudentAsync(Guid studentId)
                {
                    return await context.Student
                        .Include(nameof(Gender)).Include(nameof(Address))
                        .FirstOrDefaultAsync(x=>x.Id == studentId);
                }

        public async Task<Gender> AddGenderRequest( Gender request)
        {

            var gender = await context.Gender.AddAsync(request);

            await context.SaveChangesAsync();
            return gender.Entity;
        }

        public  async Task<Gender> Get1GenderAsync(Guid genderId)
        {
            return await context.Gender.FirstOrDefaultAsync( x => x.Id ==genderId);
        }
    }
}
