using DomainLayer.Enums;

namespace ApplicationLayer.Features.EmplyementDetails.Commands.UpdateEmploymentDetails
{
    public class UpdateEmployementDetailsCommandDTO
    {
        #region Field(s)
        public enContractType ContractType { get; set; }
        public double Salary { get; set; }

        #endregion

        #region Constructure(s)
        public UpdateEmployementDetailsCommandDTO(enContractType contractType, double salary)
        {
            ContractType = contractType;
            Salary = salary;
        }

        #endregion
    }
}