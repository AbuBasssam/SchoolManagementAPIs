namespace ApplicationLayer.Features.Enrollment.Commands.AddNewEnrollment
{
    public class AddNewEnrollmentCommandDTO
    {
        public string StudentNumber { get; set; }
        public string SectionNumber { get; set; }

        public AddNewEnrollmentCommandDTO(string studentNumber, string sectionNumber)
        {
            StudentNumber = studentNumber;
            SectionNumber = sectionNumber;
        }
    }
}
