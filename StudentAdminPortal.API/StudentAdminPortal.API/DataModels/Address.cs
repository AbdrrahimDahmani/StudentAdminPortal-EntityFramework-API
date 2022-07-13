namespace StudentAdminPortal.API.DataModel
{
    public class Address
    {
        public Guid Id { get; set; }
        public string? PhysicalAddress { get; set; }
        public string? PostalAddress { get; set; }

        // Navigation propertie

        public Guid StudentId { get; set; }
    }
}
