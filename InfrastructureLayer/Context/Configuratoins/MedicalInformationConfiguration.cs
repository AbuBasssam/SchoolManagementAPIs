using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class MedicalInformationConfiguration : IEntityTypeConfiguration<MedicalInformation>
    {
        public void Configure(EntityTypeBuilder<MedicalInformation> builder)
        {
            builder.ToTable("MedicalInformations");


            builder.HasKey(mi => mi.Id);


            builder.Property(mi => mi.Id).ValueGeneratedOnAdd();


            builder.HasOne(s => s.Student).WithMany(mi => mi.MedicalInformationList).HasForeignKey(mi => mi.StudentID).OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(mi => mi.Condition).WithMany().HasForeignKey(mi => mi.ConditionID).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
