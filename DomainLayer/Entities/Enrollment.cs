using DomainLayer.Contracts;

namespace DomainLayer.Entities
{
    public class Enrollment : IEntity
    {
        #region  var/prop
        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int StudentID { get; set; }
        public int SectionID { get; set; }
        public bool? IsStudentPass { get; set; }
        public Student Student { get; set; }

        public Section Section { get; set; }
        #endregion

    }
}
