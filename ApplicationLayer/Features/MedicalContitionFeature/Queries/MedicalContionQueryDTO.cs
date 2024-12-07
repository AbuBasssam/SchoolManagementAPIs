using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.MedicalContitions.Queries
{
    public class MedicalContionQueryDTO
    {
        #region Field(s)
        public string ConditionName { get; set; }

        #endregion
        
        #region Constructure(s)
        public MedicalContionQueryDTO(string conditionName)
        {
            ConditionName = conditionName;
        }

        #endregion

    }
}
