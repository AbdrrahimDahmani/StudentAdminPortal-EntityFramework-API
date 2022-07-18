using StudentAdminPortal.API.DataModel;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentGender
    {
        Task<Gender> Get1GenderAsync(Guid Id);
    }
}
