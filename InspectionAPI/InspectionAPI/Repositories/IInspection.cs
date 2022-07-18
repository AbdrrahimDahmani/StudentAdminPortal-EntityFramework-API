using InspectionAPI.DataModels;

namespace InspectionAPI.Repositories
{
    public interface IInspection
    {
        Task<Inspection> GetInspections();
    }
}
