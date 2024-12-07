using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class ScheduleViewConfiguration : IEntityTypeConfiguration<ScheduleView>
    {
        public void Configure(EntityTypeBuilder<ScheduleView> builder)
        {
            builder.HasNoKey(); // Since views typically don't have a primary key


            builder.ToView("Schedule_View"); // Map to the database view


            builder.Property(s => s.SectionNumber).HasColumnName("SectionNumber").IsRequired();


            builder.Property(s => s.CourseCode).HasColumnName("CourseCode").IsRequired();


            builder.Property(s => s.ClassName).HasColumnName("ClassName").IsRequired();


            builder.Property(s => s.TeacherName).HasColumnName("TeacherName").IsRequired(false);


            // Map WeekSchedule properties
            builder.Property(s => s.SUN).HasColumnName("SUN").HasColumnType("bit");


            builder.Property(s => s.MON).HasColumnName("MON").HasColumnType("bit");


            builder.Property(s => s.TUE).HasColumnName("TUE").HasColumnType("bit");


            builder.Property(s => s.WED).HasColumnName("WED").HasColumnType("bit");


            builder.Property(s => s.THU).HasColumnName("THU").HasColumnType("bit");


            // Map TimeSlot properties
            builder.Property(s => s.StartTime).HasColumnName("StartTime").HasColumnType("time(0)").IsRequired();


            builder.Property(s => s.EndTime).HasColumnName("EndTime").HasColumnType("time(0)").IsRequired();

            /* //WeekSchedule
             builder.OwnsOne
            (
                    sch => sch.WeekSchedule, ws =>
                    {
                        ws
                          .Property(ws => ws.SUN)
                          .HasColumnName("SUN")
                          .HasColumnType("bit");

                        ws
                          .Property(ws => ws.MON)
                          .HasColumnName("MON")
                          .HasColumnType("bit");

                        ws
                          .Property(ws => ws.TUE)
                          .HasColumnName("TUE")
                          .HasColumnType("bit");

                        ws
                          .Property(ws => ws.WED)
                          .HasColumnName("WED")
                          .HasColumnType("bit");

                        ws.Property(ws => ws.THU)
                          .HasColumnName("THU")
                          .HasColumnType("bit");
                    }
            );*/

            /*//TimeSlot
            builder.OwnsOne
            (
                sch => sch.TimeSlot, ts =>
                {
                    ts
                      .Property(ts => ts.StartTime)
                      .HasColumnName("StartTime")
                      .HasColumnType("time(0)")
                      .IsRequired();

                    ts
                      .Property(ts => ts.EndTime)
                      .HasColumnName("EndTime")
                      .HasColumnType("time(0)")
                      .IsRequired();
                }
            );*/


        }
    }
}
