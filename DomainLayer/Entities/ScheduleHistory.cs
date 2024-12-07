using DomainLayer.Contracts;
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public partial class ScheduleHistory : IEntity
    {
        public int Id { get; set; }
        public int ScheduleID { get; set; }
        public int ChanageByUserID { get; set; }//UserID(Admin role)
        public DateTime ChangeAt { get; set; }
        public Schedule Schedule { get; set; } = null!;
        public User User { get; set; } = null!;
        public enChangeType ChangeType { get; set; }

    }
}
