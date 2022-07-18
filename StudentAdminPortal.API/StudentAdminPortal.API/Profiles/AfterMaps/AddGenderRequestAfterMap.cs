using AutoMapper;
using StudentAdminPortal.API.DomainModels;

namespace StudentAdminPortal.API.Profiles.AfterMaps
{
    public class AddGenderRequestAfterMap : IMappingAction<AddGenderRequest, DataModel.Gender>
    {
        public void Process(AddGenderRequest source,DataModel.Gender destination, ResolutionContext context)
        {
            destination.Id = new Guid();
            destination.Description = source.Description;
        }
    }
}
