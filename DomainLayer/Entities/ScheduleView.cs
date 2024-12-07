namespace DomainLayer.Entities
{
    public class ScheduleView
    {

        #region var/prop(s)
        public string SectionNumber { get; set; } = null!;
        public string CourseCode { get; set; } = null!;
        public string ClassName { get; set; } = null!;
        public string? TeacherName { get; set; }
        public bool SUN { get; set; }
        public bool MON { get; set; }
        public bool TUE { get; set; }
        public bool WED { get; set; }
        public bool THU { get; set; }

        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        #endregion

    }
}
