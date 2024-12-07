using ApplicationLayer.Features.SectionFeature.Queries;
using ApplicationLayer.Models;
using MediatR;

namespace ApplicationLayer.Features.SectionFeature.Commands.AssignSectionTeacher
{
    public class AssignSectionTeacherCommand : IRequest<Response<SectionQueryDTO>>
    {
        public AssignSectionTeacherCommandDTO DTO { get; set; }

        public AssignSectionTeacherCommand(AssignSectionTeacherCommandDTO dto)
        {
            DTO = dto;
        }
    }
}

