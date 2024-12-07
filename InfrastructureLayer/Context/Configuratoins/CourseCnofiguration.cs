using DomainLayer.Converters;
using DomainLayer.Entities;
using DomainLayer.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class CourseCnofiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");


            builder.ToTable(t => t.HasCheckConstraint("CK_Course_Level", "([CourseLevel]>=(1) AND [CourseLevel]<=(3))"));


            builder.ToTable(t => t.HasCheckConstraint("CK_Course_Hours", "([CourseHours]>(1) AND [CourseHours]<=(4))"));


            builder.HasKey(su => su.Id);


            builder.Property(su => su.Id).ValueGeneratedOnAdd();


            builder.HasAlternateKey(su => su.CourseCode).HasName("UQ_Course_Code");


            builder.HasAlternateKey(su => su.CourseName).HasName("UQ_Course_Name");


            builder.Property(su => su.CourseCode).HasColumnType("NVARCHAR").HasMaxLength(10).IsRequired();


            builder.Property(su => su.CourseName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();


            builder.Property(su => su.CourseLevel).HasConversion(su => enLevelConverter.Converter(su), su => enLevelConverter.Converter(su));


            builder.Property(su => su.CourseHours).HasConversion(su => enCourseHoursConverter.Converter(su), su => enCourseHoursConverter.Converter(su));


            builder.Property(su => su.HasPractical).HasColumnType("bit").IsRequired();


            builder.Property(su => su.HasPrerequisite).HasColumnType("bit").IsRequired();


            builder.HasOne(c => c.PrerequisiteCourse).WithOne().HasForeignKey<Course>(c => c.PrerequisiteID);


            builder.HasData(LoadCourses());



        }
        private static List<Course> LoadCourses()
        {
            return new List<Course>
{
                new Course { Id = 1,    CourseName = "Math 1"                    ,CourseCode = "101-MTH",    CourseLevel = enLevel.FirstGrade,     HasPractical = false,  HasPrerequisite=false, CourseHours=  enCourseHours.FourHours },
                new Course { Id = 2,    CourseName = "Math 2"                    ,CourseCode = "201-MTH",    CourseLevel = enLevel.FirstGrade,     HasPractical = false,  HasPrerequisite=true , CourseHours=  enCourseHours.FourHours },
                new Course { Id = 3,    CourseName = "Physics 1"                 ,CourseCode = "102-PHY",    CourseLevel = enLevel.FirstGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 4,    CourseName = "English 1"                 ,CourseCode = "103-ENG",    CourseLevel = enLevel.FirstGrade,     HasPractical = false,  HasPrerequisite=false, CourseHours=  enCourseHours.FourHours },
                new Course { Id = 5,    CourseName = "Biology 1"                 ,CourseCode = "104-BIO",    CourseLevel = enLevel.FirstGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 6,    CourseName = "History 1"                 ,CourseCode = "105-HIS",    CourseLevel = enLevel.FirstGrade,     HasPractical = false,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 7,    CourseName = "Chemistry 1"               ,CourseCode = "106-CHE",    CourseLevel = enLevel.FirstGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 8,    CourseName = "Geography 1"               ,CourseCode = "111-GEO",    CourseLevel = enLevel.FirstGrade,     HasPractical = false,  HasPrerequisite=false, CourseHours=  enCourseHours.TwoHours  },
                new Course { Id = 9,    CourseName = "Physical Education"        ,CourseCode = "107-PEE",    CourseLevel = enLevel.FirstGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours=  enCourseHours.TwoHours  },
                new Course { Id = 10,   CourseName = "Computer Science 1"        ,CourseCode = "109-COM",    CourseLevel = enLevel.FirstGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 11,   CourseName = "Linguistics"               ,CourseCode = "129-LIN",    CourseLevel = enLevel.FirstGrade,     HasPractical = false,  HasPrerequisite=false, CourseHours = enCourseHours.TwoHours  },
                new Course { Id = 12,   CourseName = "Physics 2"                 ,CourseCode = "202-PHY",    CourseLevel = enLevel.FirstGrade,     HasPractical = true ,  HasPrerequisite=true , CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 13,   CourseName = "Introduction to Psychology",CourseCode = "123-PSY",    CourseLevel = enLevel.FirstGrade,     HasPractical = false,  HasPrerequisite=false, CourseHours = enCourseHours.TwoHours  },
                new Course { Id = 14,   CourseName = "English 2"                 ,CourseCode = "203-ENG",    CourseLevel = enLevel.FirstGrade,     HasPractical = false,  HasPrerequisite=true , CourseHours=  enCourseHours.FourHours },


                new Course { Id = 15,   CourseName = "Economics"                 ,CourseCode = "210-ECO",    CourseLevel = enLevel.SecondGrade,    HasPractical = false,  HasPrerequisite=false, CourseHours = enCourseHours.TwoHours  },
                new Course { Id = 16,   CourseName = "Statistics 1"              ,CourseCode = "214-STA",    CourseLevel = enLevel.SecondGrade,    HasPractical = false,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 17,   CourseName = "Environmental Science"     ,CourseCode = "215-ENV",    CourseLevel = enLevel.SecondGrade,    HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 18,   CourseName = "Math 3"                    ,CourseCode = "301-MTH",    CourseLevel = enLevel.SecondGrade,    HasPractical = false,  HasPrerequisite=true , CourseHours = enCourseHours.FourHours },
                new Course { Id = 19,   CourseName = "History2"                  ,CourseCode = "205-HIS",    CourseLevel = enLevel.SecondGrade,    HasPractical = false,  HasPrerequisite=true , CourseHours = enCourseHours.TwoHours  },
                new Course { Id = 20,   CourseName = "Political Science"         ,CourseCode = "230-POL",    CourseLevel = enLevel.SecondGrade,    HasPractical = false,  HasPrerequisite=false, CourseHours = enCourseHours.TwoHours  },
                new Course { Id = 21,   CourseName = "Chemistry 2"               ,CourseCode = "206-CHE",    CourseLevel = enLevel.SecondGrade,    HasPractical = true ,  HasPrerequisite=true , CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 22,   CourseName = "Physics 3"                 ,CourseCode = "302-PHY",    CourseLevel = enLevel.SecondGrade,    HasPractical = true ,  HasPrerequisite=true , CourseHours=  enCourseHours.ThreeHours},
                new Course { Id = 23,   CourseName = "Biology 2"                 ,CourseCode = "204-BIO",    CourseLevel = enLevel.SecondGrade,    HasPractical = true ,  HasPrerequisite=true , CourseHours=  enCourseHours.ThreeHours},
                new Course { Id = 24,   CourseName = "Math 4"                    ,CourseCode = "401-MTH",    CourseLevel = enLevel.SecondGrade,    HasPractical = false,  HasPrerequisite=true , CourseHours = enCourseHours.FourHours },
                new Course { Id = 25,   CourseName = "Geography 2"               ,CourseCode = "211-GEO",    CourseLevel = enLevel.SecondGrade,    HasPractical = false,  HasPrerequisite=true , CourseHours = enCourseHours.TwoHours  },
                new Course { Id = 26,   CourseName = "History 3"                 ,CourseCode = "305-HIS",    CourseLevel = enLevel.SecondGrade,    HasPractical = false,  HasPrerequisite=true , CourseHours=  enCourseHours.TwoHours  },
                new Course { Id = 27,   CourseName = "Chemistry 4"               ,CourseCode = "406-CHE",    CourseLevel = enLevel.SecondGrade,    HasPractical = true ,  HasPrerequisite=true , CourseHours=  enCourseHours.ThreeHours},
                new Course { Id = 28,   CourseName = "Physics 4"                 ,CourseCode = "402-PHY",    CourseLevel = enLevel.SecondGrade,    HasPractical = true ,  HasPrerequisite=true , CourseHours=  enCourseHours.ThreeHours},


                new Course { Id = 29,   CourseName = "English 3"                 ,CourseCode = "303-ENG",    CourseLevel = enLevel.ThirdGrade,     HasPractical = false,  HasPrerequisite=true , CourseHours=  enCourseHours.FourHours },
                new Course { Id = 30,   CourseName = "Mechanical Engineering"    ,CourseCode = "318-MEC",    CourseLevel = enLevel.ThirdGrade,     HasPractical = false,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 31,   CourseName = "Electrical Engineering"    ,CourseCode = "320-ELE",    CourseLevel = enLevel.ThirdGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 32,   CourseName = "Organic Chemistry"         ,CourseCode = "321-ORG",    CourseLevel = enLevel.ThirdGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 33,   CourseName = "Microbiology"              ,CourseCode = "322-MIC",    CourseLevel = enLevel.ThirdGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 34,   CourseName = "Marketing Basics"          ,CourseCode = "326-MAR",    CourseLevel = enLevel.ThirdGrade,     HasPractical = false,  HasPrerequisite=false, CourseHours = enCourseHours.TwoHours  },
                new Course { Id = 35,   CourseName = "Genetics"                  ,CourseCode = "328-GEN",    CourseLevel = enLevel.ThirdGrade,     HasPractical = true ,  HasPrerequisite=false, CourseHours = enCourseHours.TwoHours  },
                new Course { Id = 36,   CourseName = "Chemistry 3"               ,CourseCode = "306-CHE",    CourseLevel = enLevel.ThirdGrade,     HasPractical = true ,  HasPrerequisite=true , CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 37,   CourseName = "Math 5"                    ,CourseCode = "501-MTH",    CourseLevel = enLevel.ThirdGrade,     HasPractical = false,  HasPrerequisite=true , CourseHours = enCourseHours.FourHours },
                new Course { Id = 38,   CourseName = "Math 6"                    ,CourseCode = "601-MTH",    CourseLevel = enLevel.ThirdGrade,     HasPractical = false,  HasPrerequisite=true , CourseHours = enCourseHours.FourHours },
                new Course { Id = 39,   CourseName = "English 4"                 ,CourseCode = "403-ENG",    CourseLevel = enLevel.ThirdGrade,     HasPractical = false,  HasPrerequisite=true , CourseHours=  enCourseHours.FourHours },
                new Course { Id = 40,   CourseName = "Statistics 2"              ,CourseCode = "314-STA",    CourseLevel = enLevel.ThirdGrade,     HasPractical = false,  HasPrerequisite=true , CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 41,   CourseName = "Biology 3"                 ,CourseCode = "304-BIO",    CourseLevel = enLevel.ThirdGrade,     HasPractical = true ,  HasPrerequisite=true , CourseHours = enCourseHours.ThreeHours},
                new Course { Id = 42,   CourseName = "Biology 4"                 ,CourseCode = "404-BIO",    CourseLevel = enLevel.ThirdGrade,     HasPractical = true ,  HasPrerequisite=true , CourseHours = enCourseHours.ThreeHours},

            };

        }
    }

}
