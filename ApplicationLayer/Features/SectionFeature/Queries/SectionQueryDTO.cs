using ApplicationLayer.Features.Schedule.Queries;
using DomainLayer.Enums;

namespace ApplicationLayer.Features.SectionFeature.Queries
{
    public class SectionQueryDTO
    {
        #region Field(s)
        public string SectionNumber { get; set; }
        private enType _SectionType { get; set; }
        public string SectionType => _SectionType.ToString();
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public ScheduleDTO ScheduleDTO { get; set; }
        public string TeacherName { get; set; }

        #endregion

        #region Constructure(s)
        public SectionQueryDTO(string sectionNumber, enType sectionType, string courseCode,
            string courseName, ScheduleDTO scheduleDTO, string teacherName)
        {
            SectionNumber = sectionNumber;
            _SectionType = sectionType;
            CourseCode = courseCode;
            CourseName = courseName;
            ScheduleDTO = scheduleDTO;
            TeacherName = teacherName;
        }
        #endregion

    }
}