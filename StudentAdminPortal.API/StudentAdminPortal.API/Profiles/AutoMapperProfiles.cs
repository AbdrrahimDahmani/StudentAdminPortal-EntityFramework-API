using AutoMapper;

using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Profiles.AfterMaps;

namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModel.Student, Student>()
                .ReverseMap();
            CreateMap<DataModel.Gender, Gender>()
                .ReverseMap();
            CreateMap<DataModel.Address, Address>()
                .ReverseMap();
            CreateMap<UpdateStudentRequest, DataModel.Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();
            CreateMap<AddStudentRequest, DataModel.Student>()
                .AfterMap<AddStudentRequestAfterMap>();
            CreateMap<AddGenderRequest, DataModel.Gender>()
                .AfterMap<AddGenderRequestAfterMap>();
        }
    }
}
