using ApplicationLayer.Features.Schedule.Queries;
using ApplicationLayer.Features.SectionFeature.Commans.Interface;
using DomainLayer.Enums;

namespace ApplicationLayer.Features.SectionFeature.Commands
{
    public class AddSectionCommandDTO : ISectionCommand
    {
        public string SectionNumber { get; set; }
        public string CourseCode { get; set; }
        public enType SectionType { get; set; }
        public ScheduleDTO Schedule { get; set; }

        public AddSectionCommandDTO(string sectionNumber, string courseCode, enType sectionType, ScheduleDTO schedule)
        {
            SectionNumber = sectionNumber;
            CourseCode = courseCode;
            SectionType = sectionType;
            Schedule = schedule;
        }

    }

}
