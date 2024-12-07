using System.Collections;
using System.Text;

namespace DomainLayer.Helper_Classes
{
    public class ScheduleConflict
    {
        public string SectionNumber { get; set; }
        public BitArray WeekSchedule { get; set; }
        public TimeSpan[] TimeSlot { get; set; }

        public ScheduleConflict(string sectionNumber, BitArray weekSchedule, TimeSpan[] timeSlot)
        {
            SectionNumber = sectionNumber;
            WeekSchedule = weekSchedule;
            TimeSlot = timeSlot;
        }
        private string _DayScheduleConflictFormat(BitArray Days)
        {
            StringBuilder ConflictDays = new StringBuilder();
            ConflictDays = Days[0] ? ConflictDays.Append("SUN ") : ConflictDays.Append("  ");
            ConflictDays = Days[1] ? ConflictDays.Append("MON ") : ConflictDays.Append("  ");
            ConflictDays = Days[2] ? ConflictDays.Append("TUE ") : ConflictDays.Append("  ");
            ConflictDays = Days[3] ? ConflictDays.Append("WED ") : ConflictDays.Append("  ");
            ConflictDays = Days[4] ? ConflictDays.Append("THU") : ConflictDays.Append("  ");
            return ConflictDays.ToString().TrimEnd();

        }
        public override string ToString() =>

        $"Section Number: {SectionNumber} " +
        $"Scheduled Time: {TimeSlot[0].ToString("hh\\:mm")} - {TimeSlot[1].ToString("hh\\:mm")}   " +
        $"Day Schedule: " + _DayScheduleConflictFormat(WeekSchedule);



    }
}
