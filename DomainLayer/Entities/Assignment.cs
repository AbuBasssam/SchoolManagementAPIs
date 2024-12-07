using DomainLayer.Contracts;

namespace DomainLayer.Entities
{
    public class Assignment : IEntity
    {
        #region var/ prop
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int CourseID { get; set; }
        public Course? Course { get; set; }

        #endregion


    }
}
