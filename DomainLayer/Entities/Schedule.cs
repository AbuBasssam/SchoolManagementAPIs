using DomainLayer.Contracts;
using DomainLayer.Helper_Classes;

namespace DomainLayer.Entities
{
    public class Schedule : IEntity
    {
        #region var/prop
        public int Id { get; set; }

        public int ClassID { get; set; }

        public Class Class { get; set; } = null!;

        public WeekSchedule WeekSchedule { get; set; } = null!;

        public TimeSlot TimeSlot { get; set; } = null!;

        #endregion
    }

}
