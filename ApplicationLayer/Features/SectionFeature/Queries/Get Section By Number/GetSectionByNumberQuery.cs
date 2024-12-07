using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.SectionFeature.Queries
{
    public class GetSectionByNumberQuery : IRequest<Response<SectionQueryDTO>>
    {
        #region Field(s)
        public string SectionNumber { get; set; }

        #endregion

        #region Constructure(s)
        public GetSectionByNumberQuery(string SectionNumber)
        {
            this.SectionNumber = SectionNumber;
        }
        #endregion
    }
}