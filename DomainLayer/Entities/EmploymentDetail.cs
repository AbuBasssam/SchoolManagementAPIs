using DomainLayer.Contracts;
using DomainLayer.Enums;

namespace DomainLayer.Entities
{
    public class EmploymentDetail :IEntity
    {
        #region var/prop
        public int Id { get; set; }
        public DateTime HiringDate { get; set; }
        public enContractType ContractType { get; set; }
        public double Salary { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; } = null!; 
        #endregion
    }
}
