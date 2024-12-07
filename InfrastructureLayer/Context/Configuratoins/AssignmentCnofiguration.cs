using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{

    public class AssignmentCnofiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments");

            builder.ToTable(t => t.HasCheckConstraint("CK_Due_Date", "DueDate >CAST(GETDATE() AS DATE)"));


            builder.HasKey(a => a.Id);


            builder.Property(a => a.Id).ValueGeneratedOnAdd();


            builder.Property(c => c.Title).HasColumnType("NVARCHAR").HasMaxLength(75).IsRequired();


            builder.Property(c => c.Description).HasColumnType("NVARCHAR").HasMaxLength(150).IsRequired();


            builder.Property(c => c.DueDate).HasColumnType("date").IsRequired();


            builder.HasOne(a => a.Course).WithMany(c => c.CourseAssignments).HasForeignKey(a => a.CourseID);





        }
    }
}
