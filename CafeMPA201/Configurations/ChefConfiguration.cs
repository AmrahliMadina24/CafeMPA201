using CafeMPA201.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeMPA201.Configurations
{
    public class ChefConfiguration : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(1024);


            builder.HasOne(x => x.Position).WithMany(x => x.Chefs).HasForeignKey(x => x.PositionId).HasPrincipalKey(x => x.Id).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
