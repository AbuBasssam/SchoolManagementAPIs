using DomainLayer.Converters;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class EmploymentDetailCnofiguration : IEntityTypeConfiguration<EmploymentDetail>
    {
        public void Configure(EntityTypeBuilder<EmploymentDetail> builder)
        {
            builder.ToTable("EmploymentDetails");


            builder.HasKey(ed => ed.Id);


            builder.Property(ed => ed.Salary).HasColumnType("smallmoney").IsRequired();


            builder.Property(ed => ed.HiringDate).HasColumnType("date").IsRequired();


            builder.Property(ed => ed.ContractType).HasColumnType("bit").HasConversion(ed => enContractTypeConverter.Converter(ed), ed => enContractTypeConverter.Converter(ed));


            builder.HasOne(t => t.Teacher).WithOne(ed => ed.EmploymentDetails).HasForeignKey<EmploymentDetail>(t => t.TeacherID);

        }
    }
}
