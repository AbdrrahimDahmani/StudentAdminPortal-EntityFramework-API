using AutoMapper;
using StudentAdminPortal.API.DataModels;
using DomainModels =StudentAdminPortal.API.DomainModels;
namespace StudentAdminPortal.API.Profiles
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DomainModels.Student, Student>()
                .ReverseMap();
            CreateMap<DomainModels.Gender, Gender>()
                .ReverseMap();
            CreateMap<DomainModels.Address, Address>()
                .ReverseMap();
        }
    }
}
