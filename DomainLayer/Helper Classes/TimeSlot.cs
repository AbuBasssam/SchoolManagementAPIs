namespace DomainLayer.Helper_Classes
{
    public class TimeSlot
    {
        #region var/prop(s)
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        #endregion

        #region Override(s)
        public override string ToString()
        {
            return $"{StartTime.ToString("hh\\:mm")} - {EndTime.ToString("hh\\:mm")}";
        }

        #endregion
    }
}
