using ApplicationLayer.Features.Classes.Queries.GetClassByID;
using ApplicationLayer.Features.Classes.Queries;
using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.Schedule.Queries.GetScheduleByID
{
    public class GetScheduleByIDQuery : IRequest<Response<ScheduleDTO>>
    {
        #region Field(s)
        public int ID { get; set; }

        #endregion

        #region Consturcture(s)
        public GetScheduleByIDQuery(int Id)
        {
            ID = Id;
        }
        #endregion

    }

}
