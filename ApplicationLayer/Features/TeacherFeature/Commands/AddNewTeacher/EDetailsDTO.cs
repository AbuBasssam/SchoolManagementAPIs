using DomainLayer.Enums;

namespace ApplicationLayer.Features.Teachers.Commands.AddNewTeacher
{
    public class EDetailsDTO
    {
        public enContractType ContractType { get; set; }
        public double Salary {  get; set; }

        public EDetailsDTO(enContractType contractType, double salary)
        {
            ContractType = contractType;
            Salary = salary;
        }

    }
}