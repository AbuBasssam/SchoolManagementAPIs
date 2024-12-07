using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class TeacherCnofiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");


            builder.HasKey(t => t.Id);


            builder.Property(t => t.SubjectExpertise).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();


            builder.Property(t => t.bio).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired();


            builder.HasOne(s => s.UserInfo).WithOne().HasForeignKey<Teacher>(s => s.UserID);

            builder.HasData(LoadTeachers());
        }
        public static List<Teacher> LoadTeachers()
        {

            return new List<Teacher>
            {
                new Teacher { Id = 1   ,SubjectExpertise="Math"                     ,bio="Expert in algebra, calculus, and general math."                                         , UserID=302} ,
                new Teacher { Id = 2   ,SubjectExpertise="English"                  ,bio="Specializes in grammar and language skills."                                            , UserID=303} ,
                new Teacher { Id = 3   ,SubjectExpertise="Physics"                  ,bio="Knowledgeable in classical and modern physics."                                         , UserID=304} ,
                new Teacher { Id = 4   ,SubjectExpertise="Chemistry"                ,bio="Expert in organic and inorganic chemistry."                                             , UserID=305} ,
                new Teacher { Id = 5   ,SubjectExpertise="Biology"                  ,bio="Focuses on molecular biology and genetics."                                             , UserID=306} ,
                new Teacher { Id = 6   ,SubjectExpertise="History"                  ,bio="Specializes in ancient and modern history."                                             , UserID=307} ,
                new Teacher { Id = 7   ,SubjectExpertise="Geography"                ,bio="Knowledgeable about physical and human geography."                                      , UserID=308} ,
                new Teacher { Id = 8   ,SubjectExpertise="Computer Science"         ,bio="Expert in programming and computer fundamentals."                                       , UserID=309} ,
                new Teacher { Id = 9   ,SubjectExpertise="Economics"                ,bio="Knowledgeable in micro and macroeconomics."                                             , UserID=310} ,
                new Teacher { Id = 10  ,SubjectExpertise="Sociology"                ,bio="Specializes in social theory and social behavior."                                      , UserID=311} ,
                new Teacher { Id = 11  ,SubjectExpertise="Science"                  ,bio="Expert in biology and chemistry."                                                       , UserID=312} ,
                new Teacher { Id = 12  ,SubjectExpertise="History"                  ,bio="Expert in world history."                                                               , UserID=313} ,
                new Teacher { Id = 13  ,SubjectExpertise="Literature"               ,bio="Expert in English literature."                                                          , UserID=314} ,
                new Teacher { Id = 14  ,SubjectExpertise="Art"                      ,bio="Expert in painting and drawing."                                                        , UserID=315} ,
                new Teacher { Id = 15  ,SubjectExpertise="Music"                    ,bio="Expert in music theory."                                                                , UserID=316} ,
                new Teacher { Id = 16  ,SubjectExpertise="Physical Ed."             ,bio="Expert in physical fitness."                                                            , UserID=317} ,
                new Teacher { Id = 17  ,SubjectExpertise="Computer Science"         ,bio="Expert in programming language."                                                        , UserID=318} ,
                new Teacher { Id = 18  ,SubjectExpertise="Geography"                ,bio="Expert in physical and human geography"                                                 , UserID=319} ,
                new Teacher { Id = 19  ,SubjectExpertise="Philosophy"               ,bio="Expert in ethics and philosophy."                                                       , UserID=320} ,
                new Teacher { Id = 20  ,SubjectExpertise="Business"                 ,bio="Expert in business studies."                                                            , UserID=321} ,
                new Teacher { Id = 21  ,SubjectExpertise="Physics"                  ,bio="Expert in mechanics, thermodynamics, and electromagnetism."                             , UserID=322} ,
                new Teacher { Id = 22  ,SubjectExpertise="Chemistry"                ,bio="Specialized in organic and inorganic chemistry, chemical reactions and lab techniques." , UserID=323} ,
                new Teacher { Id = 23  ,SubjectExpertise="Biology"                  ,bio="Expert in genetics, microbiology, and environmental biology."                           , UserID=324} ,
                new Teacher { Id = 24  ,SubjectExpertise="Computer Science"         ,bio="Specialized in programming, data structures, and algorithms."                           , UserID=325} ,
                new Teacher { Id = 25  ,SubjectExpertise="History"                  ,bio="Expert in world history, ancient civilizations, and modern history."                    , UserID=326} ,
                new Teacher { Id = 26  ,SubjectExpertise="Geography"                ,bio="Specialized in physical and human geography, map reading, and environmental studies."   , UserID=327} ,
                new Teacher { Id = 27  ,SubjectExpertise="Literature"               ,bio="Expert in English literature, poetry, and literary analysis."                           , UserID=328} ,
                new Teacher { Id = 28  ,SubjectExpertise="Art"                      ,bio="Specialized in art history, painting techniques, and visual arts."                      , UserID=329} ,
                new Teacher { Id = 29  ,SubjectExpertise="Physical Education"       ,bio="Specialized in fitness, health education, and sports training."                         , UserID=330} ,
                new Teacher { Id = 30  ,SubjectExpertise="Philosophy"               ,bio="Expert in ethics, logic, and critical thinking."                                        , UserID=331} ,
                new Teacher { Id = 31  ,SubjectExpertise="Chemistry"                ,bio="Expert in biochemistry and pharmacology."                                               , UserID=332} ,
                new Teacher { Id = 32  ,SubjectExpertise="Math"                     ,bio="Specializes in advanced calculus and linear algebra."                                   , UserID=333} ,
                new Teacher { Id = 33  ,SubjectExpertise="Biology"                  ,bio="Expert in ecology and environmental science.	"                                         , UserID=334} ,
                new Teacher { Id = 34  ,SubjectExpertise="Physics"                  ,bio="Knowledgeable in quantum physics and relativity."                                       , UserID=335} ,
                new Teacher { Id = 35  ,SubjectExpertise="Chemistry"                ,bio="Expert in analytical chemistry and lab methods."                                        , UserID=336} ,
                new Teacher { Id = 36  ,SubjectExpertise="History"                  ,bio="Specializes in economic history and historiography."                                    , UserID=337} ,
                new Teacher { Id = 37  ,SubjectExpertise="English"                  ,bio="Expert in creative writing and literary critique."                                      , UserID=338} ,
                new Teacher { Id = 38  ,SubjectExpertise="Geography"                ,bio="Knowledgeable about geopolitics and urban geography."                                   , UserID=339} ,
                new Teacher { Id = 39  ,SubjectExpertise="Computer Science"         ,bio="Expert in artificial intelligence and machine learning."                                , UserID=340} ,
                new Teacher { Id = 40  ,SubjectExpertise="Statistics"               ,bio="Specializes in data analysis and statistical methods."                                  , UserID=341} ,
                new Teacher { Id = 41  ,SubjectExpertise="Economics"                ,bio="Knowledgeable in international trade and economic policy."                              , UserID=342} ,
                new Teacher { Id = 42  ,SubjectExpertise="Environmental Science "   ,bio="Expert in sustainability and climate change."                                           , UserID=343} ,
                new Teacher { Id = 43  ,SubjectExpertise="Mechanical Engineering"   ,bio="Specializes in thermodynamics and material science."                                    , UserID=344} ,
                new Teacher { Id = 44  ,SubjectExpertise="Electrical Engineering"   ,bio="Expert in circuit design and electromagnetism."                                         , UserID=345} ,
                new Teacher { Id = 45  ,SubjectExpertise="Marketing"                ,bio="Knowledgeable in digital marketing and consumer behavior. "                             , UserID=346} ,
                new Teacher { Id = 46  ,SubjectExpertise="Philosophy"               ,bio="Expert in metaphysics and epistemology."                                                , UserID=347} ,
                new Teacher { Id = 47  ,SubjectExpertise="Sociology"                ,bio="Specializes in cultural sociology and social networks."                                 , UserID=348} ,
                new Teacher { Id = 48  ,SubjectExpertise="Psychology"               ,bio="Expert in developmental psychology and mental health."                                  , UserID=349} ,
                new Teacher { Id = 49  ,SubjectExpertise="Linguistics"              ,bio="Knowledgeable in syntax and language acquisition."                                      , UserID=350} ,
                new Teacher { Id = 50  ,SubjectExpertise="Art"                      ,bio="Expert in modern art movements and critique."                                           , UserID=351} ,
                new Teacher { Id = 51  ,SubjectExpertise="Music"                    ,bio="Specializes in music composition and theory."                                           , UserID=352} ,
                new Teacher { Id = 52  ,SubjectExpertise="Political Science"        ,bio="Expert in international relations and political theory."                                , UserID=353} ,
                new Teacher { Id = 53  ,SubjectExpertise="Physics"                  ,bio="Knowledgeable in astrophysics and cosmology."                                           , UserID=354} ,
                new Teacher { Id = 54  ,SubjectExpertise="Statistics"               ,bio="Specializes in experimental design and statistical computing."                          , UserID=355} ,
                new Teacher { Id = 55  ,SubjectExpertise="Biology"                  ,bio="Expert in marine biology and conservation."                                             , UserID=356} ,
                new Teacher { Id = 56  ,SubjectExpertise="History"                  ,bio="Knowledgeable in world civilizations and their impacts."                                , UserID=357} ,
                new Teacher { Id = 57  ,SubjectExpertise="Geography"                ,bio="Expert in climate geography and geographical information systems."                      , UserID=358} ,
                new Teacher { Id = 58  ,SubjectExpertise="Computer"                 ,bio="Science    Knowledgeable in web development and cybersecurity."                         , UserID=359} ,
                new Teacher { Id = 59  ,SubjectExpertise="Physical"                 ,bio="Education  Specializes in sports science and health education. "                        , UserID=360} ,
                new Teacher { Id = 60  ,SubjectExpertise="Statistics"               ,bio="Expert in statistical modeling and data visualization."                                 , UserID=361} ,
                new Teacher { Id = 61  ,SubjectExpertise="Chemistry"                ,bio="Specializes in inorganic chemistry and synthesis."                                      , UserID=362} ,
                new Teacher { Id = 62  ,SubjectExpertise="Mathematics"              ,bio="Expert in number theory and mathematical logic."                                        , UserID=363} ,
                new Teacher { Id = 63  ,SubjectExpertise="Biology"                  ,bio="Expert in human anatomy and physiology."                                                , UserID=364} ,
                new Teacher { Id = 64  ,SubjectExpertise="Physics"                  ,bio="Knowledgeable in fluid dynamics and thermodynamics."                                    , UserID=365} ,
                new Teacher { Id = 65  ,SubjectExpertise="Chemistry"                ,bio="Expert in green chemistry and sustainable practices."                                   , UserID=366} ,
                new Teacher { Id = 66  ,SubjectExpertise="History"                  ,bio="Specializes in political history and revolutions."                                      , UserID=367} ,
                new Teacher { Id = 67  ,SubjectExpertise="English"                  ,bio="Expert in technical writing and professional communication."                            , UserID=368} ,
                new Teacher { Id = 68  ,SubjectExpertise="Geography"                ,bio="Knowledgeable about cultural geography and mapping."                                    , UserID=369} ,
                new Teacher { Id = 69  ,SubjectExpertise="Computer Science"         ,bio="Expert in software engineering and system architecture."                                , UserID=370} ,
                new Teacher { Id = 70  ,SubjectExpertise="Statistics"               ,bio="Specializes in biostatistics and health data analysis."                                 , UserID=371} ,
                new Teacher { Id = 71  ,SubjectExpertise="Economics"                ,bio="Expert in behavioral economics and market analysis."                                    , UserID=372} ,
                new Teacher { Id = 72  ,SubjectExpertise="Environmental Science"    ,bio="Science   Knowledgeable in ecosystem management and biodiversity."                      , UserID=373} ,
                new Teacher { Id = 73  ,SubjectExpertise="Mathematics"              ,bio="Expert in applied mathematics and mathematical modeling."                               , UserID=374} ,
                new Teacher { Id = 74  ,SubjectExpertise="Philosophy"               ,bio="Specializes in philosophy of science and ethics."                                       , UserID=375} ,
                new Teacher { Id = 75  ,SubjectExpertise="Sociology"                ,bio="Expert in urban studies and community development."                                     , UserID=376} ,
                new Teacher { Id = 76  ,SubjectExpertise="Psychology"               ,bio="Knowledgeable in cognitive behavioral therapy and research methods."                    , UserID=377} ,
                new Teacher { Id = 77  ,SubjectExpertise="Linguistics"              ,bio="Expert in phonetics and sociolinguistics."                                              , UserID=378} ,
                new Teacher { Id = 78  ,SubjectExpertise="Art"                      ,bio="Specializes in digital art and multimedia."                                             , UserID=379} ,
                new Teacher { Id = 79  ,SubjectExpertise="Music"                    ,bio="Expert in music education and performance."                                             , UserID=380} ,
                new Teacher { Id = 80  ,SubjectExpertise="Political"                ,bio="Science   Knowledgeable in comparative politics and policy analysis."                   , UserID=381} ,
                new Teacher { Id = 81  ,SubjectExpertise="Mathematics"              ,bio="Expert in statistics and probability theory."                                           , UserID=382} ,
                new Teacher { Id = 82  ,SubjectExpertise="Chemistry"                ,bio="Specializes in pharmaceutical chemistry and drug design."                               , UserID=383} ,
                new Teacher { Id = 83  ,SubjectExpertise="Biology"                  ,bio="Expert in plant biology and agronomy."                                                  , UserID=384} ,
                new Teacher { Id = 84  ,SubjectExpertise="History"                  ,bio="Knowledgeable in military history and strategy."                                        , UserID=385} ,
                new Teacher { Id = 85  ,SubjectExpertise="Geography"                ,bio="Expert in economic geography and regional planning."                                    , UserID=386} ,
                new Teacher { Id = 86  ,SubjectExpertise="Computer Science"         ,bio="Specializes in data science and analytics."                                             , UserID=387} ,
                new Teacher { Id = 87  ,SubjectExpertise="Physical Education"       ,bio="Expert in kinesiology and sports management."                                           , UserID=388} ,
                new Teacher { Id = 88  ,SubjectExpertise="Statistics"               ,bio="Knowledgeable in time series analysis and forecasting."                                 , UserID=389} ,
                new Teacher { Id = 89  ,SubjectExpertise="Chemistry"                ,bio="Expert in materials science and nanotechnology."                                        , UserID=390} ,
                new Teacher { Id = 90  ,SubjectExpertise="Mathematics"              ,bio="Specializes in discrete mathematics and combinatorics."                                 , UserID=391} ,
                new Teacher { Id = 91  ,SubjectExpertise="Biology"                  ,bio="Expert in genetics and molecular biology."                                              , UserID=392} ,
                new Teacher { Id = 92  ,SubjectExpertise="Physics"                  ,bio="Knowledgeable in quantum mechanics and particle physics."                               , UserID=393} ,
                new Teacher { Id = 93  ,SubjectExpertise="English"                  ,bio="Expert in language acquisition and pedagogy."                                           , UserID=394} ,
                new Teacher { Id = 94  ,SubjectExpertise="History"                  ,bio="Specializes in social history and historiography."                                      , UserID=395} ,
                new Teacher { Id = 95  ,SubjectExpertise="Geography"                ,bio="Expert in environmental geography and conservation."                                    , UserID=396} ,
                new Teacher { Id = 96  ,SubjectExpertise="Computer Science"         ,bio="Science    Knowledgeable in cloud computing and virtualization."                        , UserID=397} ,
                new Teacher { Id = 97  ,SubjectExpertise="Sociology"                ,bio="Expert in social psychology and group dynamics."                                        , UserID=398} ,
                new Teacher { Id = 98  ,SubjectExpertise="Philosophy"               ,bio="Specializes in political philosophy and social justice."                                , UserID=399} ,
                new Teacher { Id = 99  ,SubjectExpertise="Psychology"               ,bio="Knowledgeable in educational psychology and learning theories."                         , UserID=400} ,
                new Teacher { Id = 100 ,SubjectExpertise="Linguistics"              ,bio="Expert in morphology and semantics."                                                    , UserID=401} ,
                new Teacher { Id = 101 ,SubjectExpertise="Mathematics"              ,bio="Specializes in operational research and optimization."                                  , UserID=402}

            };
        }
    }

}





































































































