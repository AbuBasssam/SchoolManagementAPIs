namespace ApplicationLayer.Features.SectionFeature.Commands.AssignSectionTeacher
{
    public class AssignSectionTeacherCommandDTO
    {
        public string SectionNumber { get; set; }
        public string TeacherNumber { get; set; }

        public AssignSectionTeacherCommandDTO(string sectionNumber, string teacherNumber)
        {
            SectionNumber = sectionNumber;
            TeacherNumber = teacherNumber;
        }

    }
}

