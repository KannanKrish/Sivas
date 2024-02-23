namespace Sivas.Data;

public partial class ApplicationDbContext(DbContextOptions options) : BaseIdentityDbContext<Guid, ApplicationUser, ApplicationRole>(options);