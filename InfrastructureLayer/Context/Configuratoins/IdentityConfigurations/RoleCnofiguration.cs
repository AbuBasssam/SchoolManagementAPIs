using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins.IdentityConfigurations
{
    public class RoleCnofiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");


            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.Property(r => r.Name).HasMaxLength(50);


            builder.Property(r => r.NormalizedName).HasMaxLength(50);


            builder.Property(r => r.ConcurrencyStamp).HasMaxLength(64);


        }




    }
}
