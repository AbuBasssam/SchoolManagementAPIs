using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class AttendanceCnofiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.ToTable("Attendances");


            builder.HasKey(a => a.Id);


            builder.Property(a => a.Id).ValueGeneratedOnAdd();


            builder.Property(c => c.Date).HasColumnType("date").IsRequired();


            builder.Property(c => c.IsPresent).HasColumnType("bit").IsRequired();


            builder.HasOne(a => a.Student).WithMany(c => c.Attendances).HasForeignKey(a => a.StudentID);


            builder.HasOne(a => a.Section).WithMany(c => c.Attendances).HasForeignKey(a => a.SectoinID);




        }
    }
}
