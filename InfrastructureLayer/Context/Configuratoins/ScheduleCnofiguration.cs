using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class ScheduleCnofiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("Schedules");


            builder.HasKey(sch => sch.Id);


            builder.Property(sch => sch.Id).ValueGeneratedOnAdd();


            builder.OwnsOne(sch => sch.WeekSchedule, ws =>
                    {
                        ws.Property(ws => ws.SUN).HasColumnName("SUN").HasColumnType("bit");

                        ws.Property(ws => ws.MON).HasColumnName("MON").HasColumnType("bit");

                        ws.Property(ws => ws.TUE).HasColumnName("TUE").HasColumnType("bit");

                        ws.Property(ws => ws.WED).HasColumnName("WED").HasColumnType("bit");

                        ws.Property(ws => ws.THU).HasColumnName("THU").HasColumnType("bit");
                    });


            builder.OwnsOne(sch => sch.TimeSlot, ts =>
                {
                    ts.Property(ts => ts.StartTime).HasColumnName("StartTime").HasColumnType("time(0)").IsRequired();
                    ts.Property(ts => ts.EndTime).HasColumnName("EndTime").HasColumnType("time(0)").IsRequired();
                });


            builder.HasOne(sch => sch.Class).WithMany().HasForeignKey(sch => sch.ClassID);


            // builder.HasData(LoadSchedules());


        }
        /*private static List<Schedule> LoadSchedules()
        {
            //SUN,MON,TUE,WED 7-8  1,3 ,5,7 ,10,11 ,13,15 ,17,19 , 8,21
            var MathSchedule = new List<Schedule>
            {
                    //Math1  Section 1 
                      new Schedule{Id = 1  ,SectionID =1 ,ClassID=1 ,SUN =true,MON =true,TUE =true,WED =true,StartTime=new TimeSpan(07, 00, 00),EndTime = new TimeSpan(07, 50, 00)},
                     
                    //Math1 Section 2 

                     new Schedule{Id = 2  ,SectionID = 2  ,ClassID=3 ,SUN =true,MON =true,TUE =true,WED =true,StartTime=new TimeSpan(07, 00, 00),EndTime = new TimeSpan(07, 50, 00)},
                    
                     
                     
                     //Math2 Section 1 
                     new Schedule{Id = 3  ,SectionID = 3  ,ClassID=5 ,SUN =true,MON =true,TUE = true,WED =true,StartTime=new TimeSpan(07, 00, 00),   EndTime = new TimeSpan(07, 50, 00)},
                    
                     //Math2 Section 2
                     new Schedule{Id = 4  ,SectionID = 4  ,ClassID=7 ,SUN =true,MON =true,TUE =true,WED =true,StartTime=new TimeSpan(07, 00, 00),EndTime =new TimeSpan(07, 50, 00)},
                    
                    
                    
                    
                    //Math3  Section 1
                     new Schedule{Id = 5  ,SectionID = 41,ClassID=10,  SUN = true,MON = true,TUE = true,WED = true, StartTime = new TimeSpan(07, 00, 00),   EndTime = new TimeSpan(07, 50, 00)},
                    
                    //Math3 Section 2
                     new Schedule{Id = 6  ,SectionID = 42 ,ClassID=11, SUN = true,MON = true,TUE = true,WED = true,StartTime = new TimeSpan(07, 00, 00),EndTime = new TimeSpan(07, 50, 00)},
                    
                    
                     
                     
                     //Math4 Section 1 
                     new Schedule{Id = 7  ,SectionID = 56 ,ClassID=13, SUN = true,MON = true,TUE = true,WED = true,StartTime = new TimeSpan(07, 00, 00),   EndTime = new TimeSpan(07, 50, 00)},
                    
                    //Math4 Section 2 
                     new Schedule{Id = 8  ,SectionID = 57 ,ClassID=15,  SUN = true,MON = true,TUE = true,WED = true,StartTime = new TimeSpan(07, 00, 00),EndTime = new TimeSpan(07, 50, 00)},
                    
                    
                     
                     
                     //Math5 Section 1 
                     new Schedule{Id = 9  ,SectionID = 87 ,ClassID=17, SUN = true,MON = true,TUE = true,WED = true,StartTime = new TimeSpan(07, 00, 00),   EndTime = new TimeSpan(07, 50, 00)},
                    
                     //Math5 Section 2
                     new Schedule{Id = 10 ,SectionID = 88 ,ClassID=19,  SUN = true,MON = true,TUE = true,WED = true, StartTime = new TimeSpan(07, 00, 00),EndTime = new TimeSpan(07, 50, 00)},
                    
                      
                     
                     // Section 1 Math6
                     new Schedule{Id = 11 ,SectionID = 89 ,ClassID=8 , SUN = true,MON = true,TUE = true,WED = true, StartTime = new TimeSpan(07, 00, 00),   EndTime = new TimeSpan(07, 50, 00)},

                     // Section 2 Math6
                     new Schedule{Id = 12 ,SectionID = 90 ,ClassID=21 , SUN = true,MON = true,TUE = true,WED = true, StartTime = new TimeSpan(07, 00, 00),   EndTime = new TimeSpan(07, 50, 00)},


            };

            //Theory: SUN , TUE 8-9  1,3, 5,7, 10,11 ,13,15
            var Physicschedule = new List<Schedule>
            {
                 
                     // Section 1 Physics1  
                    
                     new Schedule{Id =13,SectionID =5  ,ClassID=1,  SUN = true,TUE = true, StartTime = new TimeSpan(08, 00, 00),EndTime = new TimeSpan(08, 50, 00)},
                    
                     // Section 2 Physics1  
                    
                     new Schedule{Id =14 ,SectionID =6  ,ClassID=3,  SUN = true,TUE = true, StartTime = new TimeSpan(08, 00, 00),EndTime = new TimeSpan(08, 50, 00)},
                    
                      // Section 1 Physics1 Practical 
                    
                     new Schedule{Id =15,SectionID =7  ,ClassID=6, THU=true, StartTime = new TimeSpan(07, 00, 00),EndTime = new TimeSpan(08, 00, 00)},
                    
                    
                    
                    
                    
                     // Section 1 Physics 2  
                     new Schedule{Id =16 ,SectionID =27 ,ClassID=5,  SUN = true,TUE = true ,StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00) },
                    
                     // Section 2 Physics 2  
                     new Schedule{Id =17 ,SectionID =28,ClassID=7,  SUN = true,TUE = true, StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00) },
                      
                     // Section 1 Physics2 Practical 
                    
                     new Schedule{Id =18,SectionID =29  ,ClassID=9,  THU=true, StartTime = new TimeSpan(07, 00, 00),EndTime = new TimeSpan(08, 00, 00)},

                    
                     
                     
                     
                     
                     // Section 1 Physics 3  
                     new Schedule{Id =19 ,SectionID =50 ,ClassID=10, SUN = true, TUE = true,  StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00) },
                    
                     // Section 2 Physics 3  
                     new Schedule{Id =20 ,SectionID = 51 ,ClassID=11, SUN = true, TUE = true, StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00)},
                    
                     // Section 1 Physics 3 Practical 
                    
                     new Schedule{Id =21,SectionID =52  ,ClassID=12, THU=true,StartTime = new TimeSpan(07, 00, 00),EndTime = new TimeSpan(08, 00, 00)},

                     
                     
                     
                     
                     
                     
                     
                     
                     
                     
                     
                     
                     // Section 1 Physics4  
                     new Schedule{Id = 22 ,SectionID =65 ,ClassID=13, SUN = true, TUE = true, StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00) },
                    
                     // Section 2 Physics4  
                     new Schedule { Id = 23, SectionID = 66, ClassID = 15, SUN = true, TUE = true ,StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00)},
    
                    
                     // Section 1 Physics 4 Practical 
                    
                     new Schedule{Id =24,SectionID =67  ,ClassID=14, THU=true,StartTime = new TimeSpan(07, 00, 00), EndTime = new TimeSpan(08, 00, 00)},









            };

            //Theory: MON ,WED 8-9   1,3, 5,7, 10,11
            var HistorySchedule = new List<Schedule>
            {
                     // Section 1 History1  
                    
                     new Schedule{Id =45,SectionID =13  ,ClassID=1,  MON = true,WED = true, StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00)},
                    
                     // Section 2 History1  
                    
                     new Schedule{Id =46 ,SectionID =14  ,ClassID=3,  MON = true,WED = true, StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00)},
                    
                    
                    
                    
                    
                     // Section 1 History2  
                    
                     new Schedule{Id =47,SectionID =43  ,ClassID=5, MON = true, WED = true, StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00)},
                    
                     // Section 2 History2  
                    
                     new Schedule{Id =48 ,SectionID =44  ,ClassID=7, MON = true, WED = true, StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00)},
                    
                    
                    
                     // Section 1 History3  
                    
                     new Schedule{Id =49,SectionID =60  ,ClassID=10, MON = true, WED = true, StartTime = new TimeSpan(08, 00, 00),EndTime = new TimeSpan(08, 50, 00)},
                    
                     // Section 2 History3  
                    
                     new Schedule{Id =50 ,SectionID =61  ,ClassID=11, MON = true, WED = true, StartTime = new TimeSpan(08, 00, 00),EndTime = new TimeSpan(08, 50, 00)},


            };

            // SUN,MON,TUE,WED 9-10  1,3, 5,7, 10,11 ,13,15
            var EngilshSchedule = new List<Schedule>
            {
                // Section 1 English1
                    
                     new Schedule{Id = 37  ,SectionID = 8  ,ClassID=1,  SUN = true,MON = true,TUE = true,WED = true ,StartTime = new TimeSpan(09, 00, 00),EndTime = new TimeSpan(9, 50, 00)},
                    
                     // Section 2 English1
                    
                     new Schedule{Id = 38  ,SectionID = 9  ,ClassID=3,  SUN = true,MON = true,TUE = true,WED = true,StartTime = new TimeSpan(09, 00, 00), EndTime = new TimeSpan(9, 50, 00)},
                    
                    
                    
                     // Section 1 English2
                     new Schedule { Id = 39, SectionID = 32, ClassID = 5, SUN = true, MON = true, TUE = true, WED = true ,StartTime = new TimeSpan(09, 00, 00), EndTime = new TimeSpan(9, 50, 00)},
                    
                     // Section 2 English2
                     new Schedule { Id = 40, SectionID = 33, ClassID = 7, SUN = true, MON = true, TUE = true, WED = true ,StartTime = new TimeSpan(09, 00, 00), EndTime = new TimeSpan(9, 50, 00)},
                    

                      // Section 1 English3
                     new Schedule{Id = 41  ,SectionID = 68 ,ClassID=10,  SUN = true,MON = true,TUE = true,WED = true, StartTime =new TimeSpan(09, 00, 00),EndTime = new TimeSpan(9, 50, 00)},
                    
                     // Section 2 English3
                     new Schedule{Id = 42  ,SectionID = 69 ,ClassID=11,  SUN = true,MON = true,TUE = true,WED = true, StartTime = new TimeSpan(09, 00, 00),EndTime = new TimeSpan(9, 50, 00)},
                    
                    
                    
                     // Section 1 English4
                     new Schedule{Id = 43  ,SectionID = 91 ,ClassID=13,  SUN = true,MON = true,TUE = true,WED = true, StartTime =new TimeSpan(09, 00, 00),EndTime = new TimeSpan(9, 50, 00)},
                    
                     // Section 2 English4
                     new Schedule{Id = 44  ,SectionID = 92 ,ClassID=15,  SUN = true,MON = true,TUE = true,WED = true, StartTime =new TimeSpan(09, 00, 00),EndTime = new TimeSpan(9, 50, 00)},





                //________________________________________________________________________________________________________________________________________________________________________________________________________________________________

            };

            //Theory: SUN , TUE 10:30- 11:30   1,3, 5,7, 10,11 ,13,15
            var BiologySchedule = new List<Schedule>
            {
                     //Biology1 Section 1   
                     new Schedule{Id = 25 ,SectionID =10 ,ClassID=1, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     //Biology1 Section 2  
                     new Schedule{Id = 26 ,SectionID =11 ,ClassID=3, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00)  },

                     //Biology1 Section 1  Practical 

                     new Schedule { Id = 27, SectionID = 12, ClassID = 6, THU = true , StartTime = new TimeSpan(08, 10, 00), EndTime = new TimeSpan(09, 10, 00)},

                      //________________________________________________________________________________________________________________________________________________________________________________________________________________________________



                     // Biology2 Section 1  
                     new Schedule{Id = 28 ,SectionID =53 ,ClassID=5, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Biology2 Section 2   
                     new Schedule { Id = 29, SectionID = 54, ClassID = 7, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Biology2 Section 1 Practical 

                     new Schedule{Id =30,SectionID =55  ,ClassID=9, THU=true,StartTime = new TimeSpan(08, 10, 00), EndTime = new TimeSpan(09, 10, 00)},

                //________________________________________________________________________________________________________________________________________________________________________________________________________________________________


                      // Section 1 Biology3  
                     new Schedule{Id = 31 ,SectionID =95 ,ClassID=10, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Section 2 Biology3  
                     new Schedule { Id = 32, SectionID = 96, ClassID = 11, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Section 1 Biology3  Practical 

                     new Schedule{Id =33,SectionID =97  ,ClassID=12, THU=true,StartTime = new TimeSpan(08, 10, 00), EndTime = new TimeSpan(09, 10, 00)},

                //________________________________________________________________________________________________________________________________________________________________________________________________________________________________

                     // Section 1 Biology4  
                     new Schedule{Id = 34 ,SectionID =98 ,ClassID=13, SUN = true, TUE = true ,StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Section 2 Biology4  
                     new Schedule{Id = 35 ,SectionID =99 ,ClassID=15, SUN = true, TUE = true ,StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00)  },

                     // Section 1 Biology4  Practical 

                     new Schedule { Id = 36, SectionID = 100, ClassID = 14, THU = true ,StartTime = new TimeSpan(08, 10, 00), EndTime = new TimeSpan(09, 10, 00)},

               // ________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            };


            //MON ,WED 10:30- 11:30   1,3, 5,7
            var GeographySchedule = new List<Schedule>
            {
                    //Geography1 Section 1   
                     
                     new Schedule{Id =51,SectionID =18  ,ClassID=1,  MON = true,WED = true,  StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00)},
                    
                     //Geography1 Section 2   
                    
                     new Schedule{Id =52 ,SectionID =19  ,ClassID=3,  MON = true,WED = true,  StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00)},
                    
                    
                    
                    
                    
                     //Geography2 Section 1   
                    
                     new Schedule{Id =53,SectionID =58  ,ClassID=5, MON = true, WED = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00)},
                    
                     //Geography2 Section 2   
                    
                     new Schedule{Id =54 ,SectionID =59  ,ClassID=7, MON = true, WED = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00)},

            };

            //---------- for 11:30 is full ---------- 

            //practical: SUN , TUE 11:30- 12:30  2,4
            var PhysicalEducationSchedule = new List<Schedule>
            {
                    //Physical Education Section 1   
                     
                     new Schedule{Id =57,SectionID =20  ,ClassID=2,  SUN = true,TUE = true,  StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20 ,00)},
                    
                     //Physical Education Section 2   
                    
                     new Schedule{Id =58 ,SectionID =21  ,ClassID=4,  SUN = true,TUE = true,  StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20 ,00)},
            };


            //Theory: MON ,WED 11:30- 12:30  1,3
            var ComputerScienceSchedule = new List<Schedule>
            {
                    //Computer Science 1 Section 1   
                     
                     new Schedule{Id =55,SectionID =22  ,ClassID=1,  MON = true,WED = true,  StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20 ,00)},
                    
                     //ComputerScience 1 Section 2   
                    
                     new Schedule{Id =56 ,SectionID =23  ,ClassID=3,  MON = true,WED = true,  StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20 ,00)},
                    

                    //Computer Science practical
                     new Schedule{Id =59 ,SectionID =24  ,ClassID=20,  THU= true,  StartTime = new TimeSpan(9, 20, 00), EndTime = new TimeSpan(10, 20 ,00)},


            };

            //---------- for 12:30 is full ---------- 

            //SUN , TUE 12:30- 1:30  1,3
            var IntroductionToPsychologySchedule = new List<Schedule>
            {
                    //Introduction to Psychology Section 1   
                     
                     new Schedule{Id =62,SectionID =30  ,ClassID=1,  SUN = true,TUE = true,  StartTime = new TimeSpan(12, 30, 00), EndTime = new TimeSpan(01, 20 ,00)},
                    
                     //Introduction to Psychology Section 2   
                    
                     new Schedule{Id =63 ,SectionID =31  ,ClassID=3,  SUN = true,TUE = true,  StartTime = new TimeSpan(12, 30, 00), EndTime = new TimeSpan(01, 20 ,00)},






            };

            //MON ,WED 12:30- 1:30 1,3
            var LinguisticsSchedule = new List<Schedule>
            {
                    //Linguistics Section 1   
                     
                     new Schedule{Id =60,SectionID =25  ,ClassID=1,  MON = true,WED = true,  StartTime = new TimeSpan(12, 30, 00), EndTime = new TimeSpan(01, 20 ,00)},
                    
                     //Linguistics Section 2   
                    
                     new Schedule{Id =61 ,SectionID =26  ,ClassID=3,  MON = true,WED = true,  StartTime = new TimeSpan(12, 30, 00), EndTime = new TimeSpan(01, 20 ,00)},

            };


            //Theory: SUN , TUE 10:30- 11:30  15,17 
            var ChemistrySchedule = new List<Schedule>
            {
                     //Chemistry1 Section 1   
                     new Schedule{Id = 64 ,SectionID =15 ,ClassID=15, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     //Chemistry1 Section 2  
                     new Schedule{Id = 65 ,SectionID =16 ,ClassID=17, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00)  },

                     //Chemistry1 Section 1  Practical 

                     new Schedule { Id = 66, SectionID = 17, ClassID = 6, THU = true , StartTime = new TimeSpan(09, 20, 00), EndTime = new TimeSpan(10, 20, 00)},

                      //________________________________________________________________________________________________________________________________________________________________________________________________________________________________



                     // Chemistry2 Section 1  
                     new Schedule{Id = 67 ,SectionID =47 ,ClassID=19, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Chemistry2 Section 2   
                     new Schedule { Id = 68, SectionID = 48, ClassID = 21, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Chemistry2 Section 1 Practical 

                     new Schedule{Id =69, SectionID =49  ,ClassID=9, THU=true,StartTime = new TimeSpan(09, 20, 00), EndTime = new TimeSpan(10, 20, 00)},

                //________________________________________________________________________________________________________________________________________________________________________________________________________________________________


                      // Section 1 Chemistry3  
                     new Schedule{Id = 70 ,SectionID =84 ,ClassID=23, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Section 2 Chemistry3  
                     new Schedule { Id = 71, SectionID = 85, ClassID = 25, SUN = true, TUE = true, StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Section 1 Chemistry3  Practical 

                     new Schedule{Id =72,SectionID =86  ,ClassID=12, THU=true,StartTime = new TimeSpan(09, 20, 00), EndTime = new TimeSpan(10, 20, 00)},

                //________________________________________________________________________________________________________________________________________________________________________________________________________________________________

                     // Section 1 Chemistry4  
                     new Schedule{Id = 73 ,SectionID =62 ,ClassID=26, SUN = true, TUE = true ,StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00) },

                     // Section 2 Chemistry4  
                     new Schedule{Id = 74 ,SectionID =63 ,ClassID=28, SUN = true, TUE = true ,StartTime = new TimeSpan(10, 30, 00), EndTime = new TimeSpan(11, 20 ,00)  },

                     // Section 1 Chemistry4  Practical 

                     new Schedule { Id = 75, SectionID = 64, ClassID = 14, THU = true ,StartTime = new TimeSpan(09, 20, 00), EndTime = new TimeSpan(10, 20, 00)},

               // ________________________________________________________________________________________________________________________________________________________________________________________________________________________________



            };

            //---------- end of today for batch 1 from SUN - WED ---------- 


            // SUN,MON,TUE 8 -9  class 26,28,29,31
            var StatisticSchedule = new List<Schedule>
            {
                 
                     // Section 1 Statistics1  
                    
                     new Schedule{Id =76,SectionID =36  ,ClassID=26,  SUN = true,MON=true,TUE = true, StartTime = new TimeSpan(08, 00, 00),EndTime = new TimeSpan(08, 50, 00)},
                    
                     // Section 2 Statistics1  
                    
                     new Schedule{Id =77 ,SectionID =37  ,ClassID=28,  SUN = true,MON=true,TUE = true, StartTime = new TimeSpan(08, 00, 00),EndTime = new TimeSpan(08, 50, 00)},
                    
                      
                    
                    
                    
                    
                     // Section 1 Statistics 2  
                     new Schedule{Id =78 ,SectionID =93 ,ClassID=29,  SUN =true,MON=true,TUE = true ,StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00) },
                    
                     // Section 2 Statistics 2  
                     new Schedule{Id =79 ,SectionID =94,ClassID=31,  SUN = true,MON=true,TUE = true, StartTime = new TimeSpan(08, 00, 00), EndTime = new TimeSpan(08, 50, 00) },




            };


            //SUN , TUE 11:30- 12:30  5 ,7 
            var MarketingBasicsSchedule = new List<Schedule>
            {
                 
                     // Section 1 Marketing Basicss1  
                    
                     new Schedule{Id =85,SectionID =79  ,ClassID=5,  SUN = true,TUE = true, StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20 ,00)},
                    
                     // Section 2 Marketing Basicss1  
                    
                     new Schedule{Id =86 ,SectionID =80  ,ClassID=7,  SUN = true,TUE = true, StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20 ,00)},
            };


            //Theory: MON , WED 11:30- 12:30  5 ,7 
            var GeneticsSchedule = new List<Schedule>
            {
                     //Genetics Section 1   
                     new Schedule{Id = 87 ,SectionID =81 ,ClassID=5, SUN = true, TUE = true, StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20 ,00) },

                     //Genetics Section 2  
                     new Schedule{Id = 88 ,SectionID =82 ,ClassID=7, SUN = true, TUE = true, StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20 ,00)  },

                     //Genetics Section 1  Practical 

                     new Schedule { Id = 89, SectionID = 83, ClassID = 14, THU = true , StartTime = new TimeSpan(11, 00, 00), EndTime = new TimeSpan(12, 00, 00)},

            };


            //SUN , TUE 12:30- 1:30  5 ,7 
            var EconomicsSchedule = new List<Schedule>
            {
                 
                     // Section 1 Economicss1  
                    
                     new Schedule{Id =80,SectionID =34  ,ClassID=5,  SUN = true,TUE = true, StartTime = new TimeSpan(12, 30, 00),EndTime = new TimeSpan(01, 20, 00)},
                    
                     // Section 2 Economicss1  
                    
                     new Schedule{Id =81 ,SectionID =35  ,ClassID=7,  SUN = true,TUE = true,StartTime = new TimeSpan(12, 30, 00),EndTime = new TimeSpan(01, 20, 00)},
            };


            //MON , WED 12:30- 1:30  5 ,7 
            var MicrobiologySchedule = new List<Schedule>
            {
                 //Microbiology Section 1   
                     new Schedule{Id = 90 ,SectionID =77 ,ClassID=5, MON = true, WED = true, StartTime = new TimeSpan(12, 30, 00), EndTime = new TimeSpan(01, 20 ,00) },

                     //Microbiology Section 2  
                     new Schedule{Id = 91 ,SectionID =78 ,ClassID=7, MON = true, WED = true, StartTime = new TimeSpan(12, 30, 00), EndTime = new TimeSpan(01, 20 ,00)  },

                     //Microbiology Section 1  Practical 

                     new Schedule { Id = 92, SectionID = 101, ClassID = 9, THU = true , StartTime = new TimeSpan(11, 00, 00), EndTime = new TimeSpan(12, 00, 00)},


            };


            //Theory: MON ,WED 9:00- 10:00  26 ,28
            var EnvironmentalScienceSchedule = new List<Schedule>
            {
                 
                     // Section 1 Environmental Sciences1  
                    
                     new Schedule{Id =82,SectionID =38  ,ClassID=26,  MON = true,WED = true, StartTime = new TimeSpan(09, 00, 00),EndTime = new TimeSpan(09, 50, 00)},
                    
                     // Section 2 Environmental Sciences1  
                    
                     new Schedule{Id =83 ,SectionID =39  ,ClassID=28,  MON = true,WED = true, StartTime = new TimeSpan(09, 00, 00),EndTime = new TimeSpan(09, 50, 00)},
            
                     // Section 2 Environmental Sciences1  Practical
                    
                     new Schedule{Id =84 ,SectionID =40  ,ClassID=6,  THU = true, StartTime = new TimeSpan(11, 00, 00), EndTime = new TimeSpan(12, 00, 00)},
            };


            var ElectricalEngineeringSchedule = new List<Schedule>
            {
                 //ElectricalEngineering Section 1   
                     new Schedule{Id = 93 ,SectionID =72 ,ClassID=26, SUN = true, TUE = true, StartTime = new TimeSpan(09, 00, 00), EndTime = new TimeSpan(09, 50 ,00) },

                     //ElectricalEngineering Section 2  
                     new Schedule{Id = 94 ,SectionID =73 ,ClassID=28, SUN = true, TUE = true, StartTime = new TimeSpan(09, 00, 00), EndTime = new TimeSpan(09, 50 ,00) },

                     
                     //ElectricalEngineering Section 1  Practical 

                     new Schedule { Id = 95, SectionID = 74, ClassID = 12, THU = true , StartTime = new TimeSpan(11, 00, 00), EndTime = new TimeSpan(12, 00, 00)},


            };


            var OrganicChemistrySchedule = new List<Schedule>
            {
                 //OrganicChemistry Section 1   
                     new Schedule{Id = 96 ,SectionID =75 ,ClassID=26, SUN = true, TUE = true, StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20, 00) },

                     //OrganicChemistry Section 2  
                     new Schedule{Id = 97 ,SectionID =76 ,ClassID=28, SUN = true, TUE = true, StartTime = new TimeSpan(11, 30, 00), EndTime = new TimeSpan(12, 20, 00)  },

                     //OrganicChemistry Section 1  Practical 

                     new Schedule { Id = 98, SectionID = 102, ClassID = 27, THU = true , StartTime = new TimeSpan(07, 00, 00), EndTime = new TimeSpan(08, 00, 00)},


            };


            var MechanicalEngineeringSchedule = new List<Schedule>
            {
                    //ElectricalEngineering Section 1   
                     new Schedule{Id = 99 ,SectionID =70 ,ClassID=26, MON = true, WED = true, StartTime = new TimeSpan(07, 00, 00), EndTime = new TimeSpan(07, 50 ,00) },

                     //ElectricalEngineering Section 2  
                     new Schedule{Id = 100 ,SectionID =71 ,ClassID=28, MON = true, WED = true, StartTime = new TimeSpan(07, 00, 00), EndTime = new TimeSpan(07, 50 ,00) },





            };


            var PoliticalScienceSchedule = new List<Schedule>
            {
                    //Political Science Section 1   
                     new Schedule{Id = 101 ,SectionID =45 ,ClassID=26, SUN = true, TUE = true, StartTime = new TimeSpan(07, 00, 00), EndTime = new TimeSpan(07, 50 ,00) },

                     //Political Science Section 2  
                     new Schedule{Id = 102 ,SectionID =46 ,ClassID=28, SUN = true, TUE = true, StartTime = new TimeSpan(07, 00, 00), EndTime = new TimeSpan(07, 50 ,00) },





            };





            var Schedules = new List<Schedule>();

            Schedules.AddRange(MathSchedule);
            Schedules.AddRange(Physicschedule);
            Schedules.AddRange(BiologySchedule);
            Schedules.AddRange(EngilshSchedule);
            Schedules.AddRange(HistorySchedule);
            Schedules.AddRange(GeographySchedule);
            Schedules.AddRange(ComputerScienceSchedule);
            Schedules.AddRange(PhysicalEducationSchedule);
            Schedules.AddRange(LinguisticsSchedule);
            Schedules.AddRange(IntroductionToPsychologySchedule);
            Schedules.AddRange(ChemistrySchedule);
            Schedules.AddRange(StatisticSchedule);
            Schedules.AddRange(EconomicsSchedule);
            Schedules.AddRange(EnvironmentalScienceSchedule);
            Schedules.AddRange(MarketingBasicsSchedule);
            Schedules.AddRange(GeneticsSchedule);
            Schedules.AddRange(MicrobiologySchedule);
            Schedules.AddRange(ElectricalEngineeringSchedule);
            Schedules.AddRange(OrganicChemistrySchedule);
            Schedules.AddRange(MechanicalEngineeringSchedule);
            Schedules.AddRange(PoliticalScienceSchedule);

            return Schedules;

        }
        */

    }
}




