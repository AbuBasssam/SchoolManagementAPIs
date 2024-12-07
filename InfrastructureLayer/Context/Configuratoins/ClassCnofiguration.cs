using DomainLayer.Converters;
using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{

    public class ClassCnofiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");


            builder.ToTable(t => { t.HasCheckConstraint("CK_Class_Capacity", "ClassCapacity>0 AND ClassCapacity<=45"); });


            builder.HasKey(c => c.Id);


            builder.HasAlternateKey(c => c.ClassName).HasName("UQ_Class_Name");


            builder.Property(c => c.Id).ValueGeneratedOnAdd();


            builder.Property(c => c.ClassName).HasColumnType("NVARCHAR").HasMaxLength(20).IsRequired();


            builder.Property(c => c.ClassCapacity).HasColumnType("tinyint").IsRequired();


            builder.Property(c => c.ClassType).HasConversion(c => enTypeConverter.Converter(c), c => enTypeConverter.Converter(c));


            builder.HasData(LoadClasses());


        }
        private static List<Class> LoadClasses()
        {
            return new List<Class>
            {
                 new Class { Id = 1,  ClassName = "A-1-20", ClassType = enType.Theory,    ClassCapacity = 35 },
                 new Class { Id = 2,  ClassName = "B-2-15", ClassType = enType.Practical, ClassCapacity = 25 },
                 new Class { Id = 3,  ClassName = "C-1-30", ClassType = enType.Theory,    ClassCapacity = 30 },
                 new Class { Id = 4,  ClassName = "D-2-18", ClassType = enType.Practical, ClassCapacity = 20 },
                 new Class { Id = 5,  ClassName = "E-1-28", ClassType = enType.Theory,    ClassCapacity = 30 },
                 new Class { Id = 6,  ClassName = "F-3-22", ClassType = enType.Practical, ClassCapacity = 28 },
                 new Class { Id = 7,  ClassName = "G-1-26", ClassType = enType.Theory,    ClassCapacity = 40 },
                 new Class { Id = 8,  ClassName = "H-2-12", ClassType = enType.Theory,    ClassCapacity = 25 },
                 new Class { Id = 9,  ClassName = "I-3-27", ClassType = enType.Practical, ClassCapacity = 30 },
                 new Class { Id = 10, ClassName = "J-1-24", ClassType = enType.Theory,    ClassCapacity = 35 },
                 new Class { Id = 11, ClassName = "K-2-21", ClassType = enType.Theory,    ClassCapacity = 32 },
                 new Class { Id = 12, ClassName = "L-3-19", ClassType = enType.Practical, ClassCapacity = 22 },
                 new Class { Id = 13, ClassName = "M-1-29", ClassType = enType.Theory,    ClassCapacity = 30 },
                 new Class { Id = 14, ClassName = "N-2-25", ClassType = enType.Practical, ClassCapacity = 20 },
                 new Class { Id = 15, ClassName = "O-3-11", ClassType = enType.Theory,    ClassCapacity = 35 },
                 new Class { Id = 16, ClassName = "P-1-16", ClassType = enType.Practical, ClassCapacity = 18 },
                 new Class { Id = 17, ClassName = "Q-2-14", ClassType = enType.Theory,    ClassCapacity = 40 },
                 new Class { Id = 18, ClassName = "R-3-23", ClassType = enType.Practical, ClassCapacity = 25 },
                 new Class { Id = 19, ClassName = "S-1-17", ClassType = enType.Theory,    ClassCapacity = 30 },
                 new Class { Id = 20, ClassName = "T-2-13", ClassType = enType.Practical, ClassCapacity = 27 },
                 new Class { Id = 21, ClassName = "U-3-12", ClassType = enType.Theory,    ClassCapacity = 35 },
                 new Class { Id = 22, ClassName = "V-1-20", ClassType = enType.Practical, ClassCapacity = 20 },
                 new Class { Id = 23, ClassName = "W-2-15", ClassType = enType.Theory,    ClassCapacity = 40 },
                 new Class { Id = 24, ClassName = "X-3-28", ClassType = enType.Practical, ClassCapacity = 25 },
                 new Class { Id = 25, ClassName = "Y-1-10", ClassType = enType.Theory,    ClassCapacity = 30 },
                 new Class { Id = 26, ClassName = "Z-2-18", ClassType = enType.Theory,    ClassCapacity = 35 },
                 new Class { Id = 27, ClassName = "AA-3-22",ClassType = enType.Practical, ClassCapacity = 28 },
                 new Class { Id = 28, ClassName = "AB-1-19",ClassType = enType.Theory,    ClassCapacity = 40 },
                 new Class { Id = 29, ClassName = "AC-2-14",ClassType = enType.Theory,    ClassCapacity = 32 },
                 new Class { Id = 30, ClassName = "AD-3-24",ClassType = enType.Practical, ClassCapacity = 24 },
                 new Class { Id = 31, ClassName = "AE-1-21",ClassType = enType.Theory,    ClassCapacity = 35 },
                 new Class { Id = 32, ClassName = "AF-2-16",ClassType = enType.Practical, ClassCapacity = 25 },
                 new Class { Id = 33, ClassName = "AG-3-18",ClassType = enType.Practical, ClassCapacity = 30 },
                 new Class { Id = 34, ClassName = "AH-1-22",ClassType = enType.Theory,    ClassCapacity = 40 },
                 new Class { Id = 35, ClassName = "AI-2-19",ClassType = enType.Theory,    ClassCapacity = 30 },
                 new Class { Id = 36, ClassName = "AJ-3-27",ClassType = enType.Practical, ClassCapacity = 20 },
                 new Class { Id = 37, ClassName = "AK-1-23",ClassType = enType.Practical, ClassCapacity = 25 },
                 new Class { Id = 38, ClassName = "AL-2-11",ClassType = enType.Theory,    ClassCapacity = 30 },
                 new Class { Id = 39, ClassName = "AM-3-12",ClassType = enType.Practical, ClassCapacity = 40 },
                 new Class { Id = 40, ClassName = "AN-1-26",ClassType = enType.Practical, ClassCapacity = 15 },

            };
        }
    }
}


