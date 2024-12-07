using DomainLayer.Contracts;

namespace DomainLayer.Entities
{
    public class Attendance : IEntity
    {
        #region var/ prop
        public int Id { get; set; }
        public int StudentID { get; set; }
        public int SectoinID { get; set; }
        public DateOnly Date { get; set; }
        public bool IsPresent { get; set; }
        public Student Student { get; set; } = null!;
        public Section Section { get; set; } = null!;
        #endregion


    }
}
