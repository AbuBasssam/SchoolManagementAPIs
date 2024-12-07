using DomainLayer.Converters;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class SemesterCnofiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> builder)
        {
            builder.HasKey(s => s.Id);


            builder.ToTable(t => t.HasCheckConstraint("CK_Semester_Type", "([SemesterType]>=(1) AND [SemesterType]<=(3))"));


            builder.Property(s => s.StartDate).HasColumnType("date").IsRequired();


            builder.Property(s => s.EndDate).HasColumnType("date").IsRequired();


            builder.Property(s => s.SemesterType).HasConversion(s => enSemesterTypeConverter.Converter(s), s => enSemesterTypeConverter.Converter(s));



        }
    }
}


