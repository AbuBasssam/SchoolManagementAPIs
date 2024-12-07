using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class EnrollmentCnofiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.ToTable("Enrollments");


            builder.HasKey(e => e.Id);


            builder.Property(e => e.Id).ValueGeneratedOnAdd();


            builder.Property(e => e.EnrollmentDate).HasColumnType("date").ValueGeneratedOnAdd().IsRequired();


            builder.Property(e => e.IsStudentPass).HasColumnType("bit").IsRequired(false);

        }
    }
}
