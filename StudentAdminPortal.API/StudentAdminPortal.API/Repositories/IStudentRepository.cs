﻿using StudentAdminPortal.API.DataModel;

namespace StudentAdminPortal.API.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<List<Gender>> GetGenderAsync();
        Task<bool> Exists(Guid studentId);
        Task <Student> UpdateStudentAsync(Guid studentId,Student request);
        Task<Student>DeleteStudent(Guid studentId);
        Task<Student> AddStudentRequest(Student request);
        Task<bool> UpdateProfileImage(Guid studentId,string profileImageUrl);
        Task <Gender> AddGenderRequest(Gender gender);
        
    }
}
