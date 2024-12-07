using DomainLayer.Converters;
using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class SectionCnofiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.ToTable("Sections");


            builder.HasKey(se => se.Id);


            builder.ToTable(t => t.HasCheckConstraint("CK_Section_Number", "SectionNumber LIKE '%[0-9]%'"));


            builder.Property(se => se.Id).ValueGeneratedOnAdd();


            builder.HasAlternateKey(se => se.SectionNumber).HasName("UQ_Section_Number");


            builder.Property(se => se.SectionType).HasConversion(se => enTypeConverter.Converter(se), se => enTypeConverter.Converter(se));


            builder.Property(se => se.SectionNumber).HasColumnType("NVARCHAR").HasMaxLength(4).IsRequired();


            builder.HasOne(se => se.Course).WithMany(se => se.CourseSections).HasForeignKey(se => se.CourseID);


            builder.HasOne(se => se.Teacher).WithMany(se => se.Sections).HasForeignKey(se => se.TeacherID).OnDelete(DeleteBehavior.SetNull).IsRequired(false);


            builder.HasOne(se => se.Schedule).WithOne().HasForeignKey<Section>(se => se.ScheduleID).IsRequired();


            builder.Property(se => se.IsOpen).HasColumnName("IsOpen").HasColumnType("bit").IsRequired();


            builder.HasMany(se => se.Students).WithMany(se => se.Sections).UsingEntity<Enrollment>();


            builder.HasData(LoadSections());
        }

        private static List<Section> LoadSections()
        {
            return new List<Section>
            {
                new Section{ Id=1,  SectionNumber="1734",   SectionType=enType.Theory   ,   CourseID=1 ,   TeacherID=null,     ScheduleID=1  ,     IsOpen=true},
                new Section{ Id=2,  SectionNumber="5821",   SectionType=enType.Theory   ,   CourseID=1 ,   TeacherID=null,     ScheduleID=2  ,     IsOpen=true},
                new Section{ Id=3,  SectionNumber="9063",   SectionType=enType.Theory   ,   CourseID=2 ,   TeacherID=null,     ScheduleID=3  ,     IsOpen=true},
                new Section{ Id=4,  SectionNumber="3492",   SectionType=enType.Theory   ,   CourseID=2 ,   TeacherID=null,     ScheduleID=4  ,     IsOpen=true},
                new Section{ Id=5,  SectionNumber="9823",   SectionType=enType.Theory   ,   CourseID=3 ,   TeacherID=null,     ScheduleID=13 ,     IsOpen=true},
                new Section{ Id=6,  SectionNumber="5913",   SectionType=enType.Theory   ,   CourseID=3 ,   TeacherID=null,     ScheduleID=14 ,     IsOpen=true},
                new Section{ Id=7,  SectionNumber="8360",   SectionType=enType.Practical,   CourseID=3 ,   TeacherID=null,     ScheduleID=15 ,     IsOpen=true},
                new Section{ Id=8,  SectionNumber="4519",   SectionType=enType.Theory   ,   CourseID=4 ,   TeacherID=null,     ScheduleID=37 ,     IsOpen=true},
                new Section{ Id=9,  SectionNumber="9036",   SectionType=enType.Theory   ,   CourseID=4 ,   TeacherID=null,     ScheduleID=38 ,     IsOpen=true},
                new Section{ Id=10, SectionNumber="3209",   SectionType=enType.Theory   ,   CourseID=5 ,   TeacherID=null,     ScheduleID=25 ,     IsOpen=true},
                new Section{ Id=11, SectionNumber="2147",   SectionType=enType.Theory   ,   CourseID=5 ,   TeacherID=null,     ScheduleID=26 ,     IsOpen=true},
                new Section{ Id=12, SectionNumber="5582",   SectionType=enType.Practical,   CourseID=5 ,   TeacherID=null,     ScheduleID=27 ,     IsOpen=true},
                new Section{ Id=13, SectionNumber="0873",   SectionType=enType.Theory   ,   CourseID=6 ,   TeacherID=null,     ScheduleID=45 ,     IsOpen=true},
                new Section{ Id=14, SectionNumber="3614",   SectionType=enType.Theory   ,   CourseID=6 ,   TeacherID=null,     ScheduleID=46 ,     IsOpen=true},
                new Section{ Id=15, SectionNumber="5781",   SectionType=enType.Theory   ,   CourseID=7 ,   TeacherID=null,     ScheduleID=64 ,     IsOpen=true},
                new Section{ Id=16, SectionNumber="7928",   SectionType=enType.Theory   ,   CourseID=7 ,   TeacherID=null,     ScheduleID=65 ,     IsOpen=true},
                new Section{ Id=17, SectionNumber="4231",   SectionType=enType.Practical,   CourseID=7 ,   TeacherID=null,     ScheduleID=66 ,     IsOpen=true},
                new Section{ Id=18, SectionNumber="6579",   SectionType=enType.Theory   ,   CourseID=8 ,   TeacherID=null,     ScheduleID=51 ,     IsOpen=true},
                new Section{ Id=19, SectionNumber="4605",   SectionType=enType.Theory   ,   CourseID=8 ,   TeacherID=null,     ScheduleID=52 ,     IsOpen=true},
                new Section{ Id=20, SectionNumber="3401",   SectionType=enType.Theory   ,   CourseID=9 ,   TeacherID=null,     ScheduleID=57 ,     IsOpen=true},
                new Section{ Id=21, SectionNumber="8910",   SectionType=enType.Theory   ,   CourseID=9 ,   TeacherID=null,     ScheduleID=58 ,     IsOpen=true},
                new Section{ Id=22, SectionNumber="7654",   SectionType=enType.Theory   ,   CourseID=10,   TeacherID=null,     ScheduleID=55 ,     IsOpen=true},
                new Section{ Id=23, SectionNumber="3719",   SectionType=enType.Theory   ,   CourseID=10,   TeacherID=null,     ScheduleID=56 ,     IsOpen=true},
                new Section{ Id=24, SectionNumber="2087",   SectionType=enType.Practical,   CourseID=10,   TeacherID=null,     ScheduleID=59 ,     IsOpen=true},
                new Section{ Id=25, SectionNumber="4935",   SectionType=enType.Theory   ,   CourseID=11,   TeacherID=null,     ScheduleID=60 ,     IsOpen=true},
                new Section{ Id=26, SectionNumber="7256",   SectionType=enType.Theory   ,   CourseID=11,   TeacherID=null,     ScheduleID=61 ,     IsOpen=true},
                new Section{ Id=27, SectionNumber="1852",   SectionType=enType.Theory   ,   CourseID=12,   TeacherID=null,     ScheduleID=16 ,     IsOpen=true},
                new Section{ Id=28, SectionNumber="7301",   SectionType=enType.Theory   ,   CourseID=12,   TeacherID=null,     ScheduleID=17 ,     IsOpen=true},
                new Section{ Id=29, SectionNumber="2740",   SectionType=enType.Practical,   CourseID=12,   TeacherID=null,     ScheduleID=18 ,     IsOpen=true},
                new Section{ Id=30, SectionNumber="1328",   SectionType=enType.Theory   ,   CourseID=13,   TeacherID=null,     ScheduleID=62 ,     IsOpen=true},
                new Section{ Id=31, SectionNumber="4820",   SectionType=enType.Theory   ,   CourseID=13,   TeacherID=null,     ScheduleID=63 ,     IsOpen=true},
                new Section{ Id=32, SectionNumber="3194",   SectionType=enType.Theory   ,   CourseID=14,   TeacherID=null,     ScheduleID=39 ,     IsOpen=true},
                new Section{ Id=33, SectionNumber="2068",   SectionType=enType.Theory   ,   CourseID=14,   TeacherID=null,     ScheduleID=40 ,     IsOpen=true},
                new Section{ Id=34, SectionNumber="8295",   SectionType=enType.Theory   ,   CourseID=15,   TeacherID=null,     ScheduleID=80 ,     IsOpen=true},
                new Section{ Id=35, SectionNumber="5794",   SectionType=enType.Theory   ,   CourseID=15,   TeacherID=null,     ScheduleID=81 ,     IsOpen=true},
                new Section{ Id=36, SectionNumber="5403",   SectionType=enType.Theory   ,   CourseID=16,   TeacherID=null,     ScheduleID=76 ,     IsOpen=true},
                new Section{ Id=37, SectionNumber="9416",   SectionType=enType.Theory   ,   CourseID=16,   TeacherID=null,     ScheduleID=77 ,     IsOpen=true},
                new Section{ Id=38, SectionNumber="2831",   SectionType=enType.Theory   ,   CourseID=17,   TeacherID=null,     ScheduleID=82 ,     IsOpen=true},
                new Section{ Id=39, SectionNumber="2403",   SectionType=enType.Theory   ,   CourseID=17,   TeacherID=null,     ScheduleID=83 ,     IsOpen=true},
                new Section{ Id=40, SectionNumber="7835",   SectionType=enType.Practical,   CourseID=17,   TeacherID=null,     ScheduleID=84 ,     IsOpen=true},
                new Section{ Id=41, SectionNumber="6507",   SectionType=enType.Theory   ,   CourseID=18,   TeacherID=null,     ScheduleID=5  ,     IsOpen=true},
                new Section{ Id=42, SectionNumber="6182",   SectionType=enType.Theory   ,   CourseID=18,   TeacherID=null,     ScheduleID=6  ,     IsOpen=true},
                new Section{ Id=43, SectionNumber="4913",   SectionType=enType.Theory   ,   CourseID=19,   TeacherID=null,     ScheduleID=47 ,     IsOpen=true},
                new Section{ Id=44, SectionNumber="5108",   SectionType=enType.Theory   ,   CourseID=19,   TeacherID=null,     ScheduleID=48 ,     IsOpen=true},
                new Section{ Id=45, SectionNumber="9461",   SectionType=enType.Theory   ,   CourseID=20,   TeacherID=null,     ScheduleID=101,     IsOpen=true},
                new Section{ Id=46, SectionNumber="3862",   SectionType=enType.Theory   ,   CourseID=20,   TeacherID=null,     ScheduleID=102,     IsOpen=true},
                new Section{ Id=47, SectionNumber="1297",   SectionType=enType.Theory   ,   CourseID=21,   TeacherID=null,     ScheduleID=67 ,     IsOpen=true},
                new Section{ Id=48, SectionNumber="5096",   SectionType=enType.Theory   ,   CourseID=21,   TeacherID=null,     ScheduleID=68 ,     IsOpen=true},
                new Section{ Id=49, SectionNumber="2418",   SectionType=enType.Practical,   CourseID=21,   TeacherID=null,     ScheduleID=69 ,     IsOpen=true},
                new Section{ Id=50, SectionNumber="7450",   SectionType=enType.Theory   ,   CourseID=22,   TeacherID=null,     ScheduleID=19 ,     IsOpen=true},
                new Section{ Id=51, SectionNumber="6487",   SectionType=enType.Theory   ,   CourseID=22,   TeacherID=null,     ScheduleID=20 ,     IsOpen=true},
                new Section{ Id=52, SectionNumber="2109",   SectionType=enType.Practical,   CourseID=22,   TeacherID=null,     ScheduleID=21 ,     IsOpen=true},
                new Section{ Id=53, SectionNumber="8932",   SectionType=enType.Theory   ,   CourseID=23,   TeacherID=null,     ScheduleID=28 ,     IsOpen=true},
                new Section{ Id=54, SectionNumber="3640",   SectionType=enType.Theory   ,   CourseID=23,   TeacherID=null,     ScheduleID=29 ,     IsOpen=true},
                new Section{ Id=55, SectionNumber="1593",   SectionType=enType.Practical,   CourseID=23,   TeacherID=null,     ScheduleID=30 ,     IsOpen=true},
                new Section{ Id=56, SectionNumber="4268",   SectionType=enType.Theory   ,   CourseID=24,   TeacherID=null,     ScheduleID=7  ,     IsOpen=true},
                new Section{ Id=57, SectionNumber="5709",   SectionType=enType.Theory   ,   CourseID=24,   TeacherID=null,     ScheduleID=8  ,     IsOpen=true},
                new Section{ Id=58, SectionNumber="3471",   SectionType=enType.Theory   ,   CourseID=25,   TeacherID=null,     ScheduleID=53 ,     IsOpen=true},
                new Section{ Id=59, SectionNumber="8695",   SectionType=enType.Theory   ,   CourseID=25,   TeacherID=null,     ScheduleID=54 ,     IsOpen=true},
                new Section{ Id=60, SectionNumber="7402",   SectionType=enType.Theory   ,   CourseID=26,   TeacherID=null,     ScheduleID=49 ,     IsOpen=true},
                new Section{ Id=61, SectionNumber="2810",   SectionType=enType.Theory   ,   CourseID=26,   TeacherID=null,     ScheduleID=50 ,     IsOpen=true},
                new Section{ Id=62, SectionNumber="9491",   SectionType=enType.Theory   ,   CourseID=27,   TeacherID=null,     ScheduleID=73 ,     IsOpen=true},
                new Section{ Id=63, SectionNumber="2048",   SectionType=enType.Theory   ,   CourseID=27,   TeacherID=null,     ScheduleID=74 ,     IsOpen=true},
                new Section{ Id=64, SectionNumber="3785",   SectionType=enType.Practical,   CourseID=27,   TeacherID=null,     ScheduleID=75 ,     IsOpen=true},
                new Section{ Id=65, SectionNumber="4917",   SectionType=enType.Theory   ,   CourseID=28,   TeacherID=null,     ScheduleID=22 ,     IsOpen=true},
                new Section{ Id=66, SectionNumber="3682",   SectionType=enType.Theory   ,   CourseID=28,   TeacherID=null,     ScheduleID=23 ,     IsOpen=true},
                new Section{ Id=67, SectionNumber="1859",   SectionType=enType.Practical,   CourseID=28,   TeacherID=null,     ScheduleID=24 ,     IsOpen=true},
                new Section{ Id=68, SectionNumber="1023",   SectionType=enType.Theory   ,   CourseID=29,   TeacherID=null,     ScheduleID=41 ,     IsOpen=true},
                new Section{ Id=69, SectionNumber="3042",   SectionType=enType.Theory   ,   CourseID=29,   TeacherID=null,     ScheduleID=42 ,     IsOpen=true},
                new Section{ Id=70, SectionNumber="1042",   SectionType=enType.Theory   ,   CourseID=30,   TeacherID=null,     ScheduleID=99 ,     IsOpen=true},
                new Section{ Id=71, SectionNumber="1056",   SectionType=enType.Theory   ,   CourseID=30,   TeacherID=null,     ScheduleID=100,     IsOpen=true},
                new Section{ Id=72, SectionNumber="1067",   SectionType=enType.Theory   ,   CourseID=31,   TeacherID=null,     ScheduleID=93 ,     IsOpen=true},
                new Section{ Id=73, SectionNumber="1078",   SectionType=enType.Theory   ,   CourseID=31,   TeacherID=null,     ScheduleID=94 ,     IsOpen=true},
                new Section{ Id=74, SectionNumber="1089",   SectionType=enType.Practical,   CourseID=31,   TeacherID=null,     ScheduleID=95 ,     IsOpen=true},
                new Section{ Id=75, SectionNumber="1204",   SectionType=enType.Theory   ,   CourseID=32,   TeacherID=null,     ScheduleID=96 ,     IsOpen=true},
                new Section{ Id=76, SectionNumber="1034",   SectionType=enType.Theory   ,   CourseID=32,   TeacherID=null,     ScheduleID=97 ,     IsOpen=true},
                new Section{ Id=77, SectionNumber="1245",   SectionType=enType.Theory   ,   CourseID=33,   TeacherID=null,     ScheduleID=90 ,     IsOpen=true},
                new Section{ Id=78, SectionNumber="1256",   SectionType=enType.Theory   ,   CourseID=33,   TeacherID=null,     ScheduleID=91 ,     IsOpen=true},
                new Section{ Id=79, SectionNumber="1267",   SectionType=enType.Theory   ,   CourseID=34,   TeacherID=null,     ScheduleID=85 ,     IsOpen=true},
                new Section{ Id=80, SectionNumber="1278",   SectionType=enType.Theory   ,   CourseID=34,   TeacherID=null,     ScheduleID=86 ,     IsOpen=true},
                new Section{ Id=81, SectionNumber="1305",   SectionType=enType.Theory   ,   CourseID=35,   TeacherID=null,     ScheduleID=87 ,     IsOpen=true},
                new Section{ Id=82, SectionNumber="1320",   SectionType=enType.Theory   ,   CourseID=35,   TeacherID=null,     ScheduleID=88 ,     IsOpen=true},
                new Section{ Id=83, SectionNumber="1346",   SectionType=enType.Practical,   CourseID=35,   TeacherID=null,     ScheduleID=89 ,     IsOpen=true},
                new Section{ Id=84, SectionNumber="1357",   SectionType=enType.Theory   ,   CourseID=36,   TeacherID=null,     ScheduleID=70 ,     IsOpen=true},
                new Section{ Id=85, SectionNumber="1406",   SectionType=enType.Theory   ,   CourseID=36,   TeacherID=null,     ScheduleID=71 ,     IsOpen=true},
                new Section{ Id=86, SectionNumber="1423",   SectionType=enType.Practical,   CourseID=36,   TeacherID=null,     ScheduleID=72 ,     IsOpen=true},
                new Section{ Id=87, SectionNumber="1435",   SectionType=enType.Theory   ,   CourseID=37,   TeacherID=null,     ScheduleID=9  ,     IsOpen=true},
                new Section{ Id=88, SectionNumber="1430",   SectionType=enType.Theory   ,   CourseID=37,   TeacherID=null,     ScheduleID=10 ,     IsOpen=true},
                new Section{ Id=89, SectionNumber="1507",   SectionType=enType.Theory   ,   CourseID=38,   TeacherID=null,     ScheduleID=11 ,     IsOpen=true},
                new Section{ Id=90, SectionNumber="1529",   SectionType=enType.Theory   ,   CourseID=38,   TeacherID=null,     ScheduleID=12 ,     IsOpen=true},
                new Section{ Id=91, SectionNumber="1604",   SectionType=enType.Theory   ,   CourseID=39,   TeacherID=null,     ScheduleID=43 ,     IsOpen=true},
                new Section{ Id=92, SectionNumber="1629",   SectionType=enType.Theory   ,   CourseID=39,   TeacherID=null,     ScheduleID=44 ,     IsOpen=true},
                new Section{ Id=93, SectionNumber="1738",   SectionType=enType.Theory   ,   CourseID=40,   TeacherID=null,     ScheduleID=78 ,     IsOpen=true},
                new Section{ Id=94, SectionNumber="1826",   SectionType=enType.Theory   ,   CourseID=40,   TeacherID=null,     ScheduleID=79 ,     IsOpen=true},
                new Section{ Id=95, SectionNumber="1907",   SectionType=enType.Theory   ,   CourseID=41,   TeacherID=null,     ScheduleID=31 ,     IsOpen=true},
                new Section{ Id=96, SectionNumber="1938",   SectionType=enType.Theory   ,   CourseID=41,   TeacherID=null,     ScheduleID=32 ,     IsOpen=true},
                new Section{ Id=97, SectionNumber="2046",   SectionType=enType.Practical,   CourseID=41,   TeacherID=null,     ScheduleID=33 ,     IsOpen=true},
                new Section{ Id=98, SectionNumber="2178",   SectionType=enType.Theory   ,   CourseID=42,   TeacherID=null,     ScheduleID=34 ,     IsOpen=true},
                new Section{ Id=99, SectionNumber="2025",   SectionType=enType.Theory   ,   CourseID=42,   TeacherID=null,     ScheduleID=35 ,     IsOpen=true},
                new Section{ Id=100,SectionNumber="2305",   SectionType=enType.Practical,   CourseID=42,   TeacherID=null,     ScheduleID=36 ,     IsOpen=true},
                new Section{ Id=101,SectionNumber="2315",   SectionType=enType.Practical,   CourseID=33,   TeacherID=null,     ScheduleID=92 ,     IsOpen=true},
                new Section{ Id=102,SectionNumber="2316",   SectionType=enType.Practical,   CourseID=32,   TeacherID=null,     ScheduleID=98 ,     IsOpen=true}



            };
        }

    }
}


