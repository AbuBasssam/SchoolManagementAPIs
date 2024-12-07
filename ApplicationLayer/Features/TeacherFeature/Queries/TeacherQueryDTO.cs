using ApplicationLayer.Models;
using DomainLayer.Enums;

namespace ApplicationLayer.Features.Teacher.Queries
{
    public class TeacherQueryDTO
    {
        public AddUserInfoDTO Info { get; set; }
        public string SubjectExpertise { get; set; }
        public string Bio { get; set; }
        private enContractType _ContractType { get; set; }
        public string ContractType => _ContractType.ToString();
        public double Salary { get; set; }

        public TeacherQueryDTO(AddUserInfoDTO info, string subjectExpertise, string bio, enContractType contractType, double salary)
        {
            Info = info;
            SubjectExpertise = subjectExpertise;
            Bio = bio;
            _ContractType = contractType;
            Salary = salary;
        }
    }
}