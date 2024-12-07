using DomainLayer.Converters;
using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class ScheduleHistoryCnofiguration : IEntityTypeConfiguration<ScheduleHistory>
    {
        public void Configure(EntityTypeBuilder<ScheduleHistory> builder)
        {
            builder.ToTable("SchedulesHistory");


            builder.HasKey(sch => sch.Id);


            builder.Property(sch => sch.Id).ValueGeneratedOnAdd();


            builder.Property(sch => sch.ChangeAt).HasColumnType("datetime").IsRequired();


            builder.Property(sch => sch.ChangeType).HasConversion(sch => enChangeTypeConverter.Converter(sch), sch => enChangeTypeConverter.Converter(sch));


            builder.HasOne(sch => sch.User).WithMany().HasForeignKey(sch => sch.ChanageByUserID);


            builder.ToTable(t => t.HasCheckConstraint("CK_Change_Type", "([ChangeType]>=(1) AND [ChangeType]<=(4))"));



        }
    }
}




