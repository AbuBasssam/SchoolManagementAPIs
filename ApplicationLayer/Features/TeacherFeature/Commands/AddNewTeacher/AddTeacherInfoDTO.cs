namespace ApplicationLayer.Features.Teachers.Commands.AddNewTeacher
{
    public class AddTeacherInfoDTO
    {
        public string Email { get; set; }
        public string SubjectExpertise { get; set; }
        public string bio { get; set; }

        public AddTeacherInfoDTO(string email, string subjectExpertise, string bio)
        {
            Email = email;
            SubjectExpertise = subjectExpertise;
            this.bio = bio;
        }
    }
}