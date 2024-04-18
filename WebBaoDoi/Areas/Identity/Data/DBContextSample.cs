using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebBaoDoi.Areas.Identity.Data;
using WebBaoDoi.Models;

namespace WebBaoDoi.Areas.Identity.Data;

public class DBContextSample : IdentityDbContext<SampleUser>
{
    internal readonly IEnumerable<object> AspnetUsers;

    public DBContextSample(DbContextOptions<DBContextSample> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }


    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<SampleUser>
    {
        public void Configure(EntityTypeBuilder<SampleUser> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(255);
            builder.Property(x => x.LastName).HasMaxLength(255);
        }
    }

public DbSet<WebBaoDoi.Models.Submission> Submission { get; set; } 
public DbSet<WebBaoDoi.Models.Faculty> Faculty { get; set; }
public DbSet<WebBaoDoi.Models.Idea> Idea { get; set; }


}
