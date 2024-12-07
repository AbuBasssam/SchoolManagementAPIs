using DomainLayer.Enums;

namespace ApplicationLayer.Features.EmplyementDetails.Queries
{
    public class EmplyementDetailQueryDTO
    {
        #region Filed(s)
        public string TeacherNumber { get; set; }
        public string TeacherName { get; set; }
        public DateTime HiringDate { get; set; }
        public enContractType ContractType { get; set; }
        public double Salary { get; set; }

        #endregion

        #region Constructure
        public EmplyementDetailQueryDTO(string teacherNumber, string teacherName, DateTime hiringDate, enContractType contractType, double salary)
        {
            TeacherNumber = teacherNumber;
            TeacherName = teacherName;
            HiringDate = hiringDate;
            ContractType = contractType;
            Salary = salary;
        }
        #endregion
    }
}