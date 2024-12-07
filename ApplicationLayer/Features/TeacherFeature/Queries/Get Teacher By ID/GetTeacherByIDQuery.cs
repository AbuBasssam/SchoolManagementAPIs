using ApplicationLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Teacher.Queries
{
    public class GetTeacherByIDQuery : IRequest<Response<TeacherQueryDTO>>
    {
        public int ID { get; set; }
        public GetTeacherByIDQuery(int Id)
        {
            ID = Id;
        }

    }

}
