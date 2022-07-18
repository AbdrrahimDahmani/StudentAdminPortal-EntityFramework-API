using Microsoft.EntityFrameworkCore;

namespace testApi.DataModels
{
    public class ClientStdContext : DbContext
    {
        protected ClientStdContext(DbContextOptions<ClientStdContext>options)
        :base(options)
        {
        }
        public DbSet<Client> Client { get; set; }
    }
}
