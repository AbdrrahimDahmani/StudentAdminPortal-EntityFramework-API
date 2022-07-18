using Microsoft.EntityFrameworkCore;

namespace InspectionAPI.DataModels
{
    public class InspectionContext:DbContext
    {
        public InspectionContext(DbContextOptions<InspectionContext> options)
            : base(options) { }
          
            public DbSet<Inspection> Inspection { get; set; }
            public DbSet<InspectionType> InspectionTypes { get; set; }
            public DbSet<Status> Status { get; set; }
          
        
    }
}
