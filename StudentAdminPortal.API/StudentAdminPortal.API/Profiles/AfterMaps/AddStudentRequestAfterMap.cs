using AutoMapper;
using StudentAdminPortal.API.DomainModels;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequest, DataModel.Student>
    {
        public void Process(AddStudentRequest source, DataModel.Student destination, ResolutionContext context)
        {
            destination.Id = new Guid();
            destination.Address = new DataModel.Address()
            {
                Id = source.Id,
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
