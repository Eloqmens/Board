using Board.Infrastucture.DataAccess;
    
namespace Board.Host.DbMigrator
{
    public class MigrationDbContext : BoardDbContext
    {
        public MigrationDbContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options)
        {
        }
    }
}
