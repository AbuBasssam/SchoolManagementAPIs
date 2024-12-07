using ApplicationLayer.Comman;
using ApplicationLayer.Interfaces.Persentation_Interfaces;
using ApplicationLayer.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer.Features.MedicalContitions.Queries.GetMedicalContionsList
{
    public class MedicalConditionsPageQueryHandler : IRequestHandler<GetMedicalConditionsPageQuery, PaginatedResult<MedicalContionQueryDTO>>
    {
        #region Field(s)
        private readonly IMedicalConditioService _services;
        private readonly IMapper _mapper;

        #endregion

        #region Constructure(s)
        public MedicalConditionsPageQueryHandler(IMedicalConditioService Services, IMapper mapper, ResponseHandler responseHandler)
        {
            _services = Services;
            _mapper = mapper;
        }
        #endregion

        #region Handler(s)
        public async Task<PaginatedResult<MedicalContionQueryDTO>> Handle(GetMedicalConditionsPageQuery request, CancellationToken cancellationToken)
        {
            var medicalCondition = await _services.GetMedicalConditionPage(request.PageNumber).ToListAsync(cancellationToken);

            if (medicalCondition == null || !medicalCondition.Any())
                return PaginatedResult<MedicalContionQueryDTO>
                   .Create().WithSucceeded(false).WithMessages(new List<string> { $"No conditions found!" }).Build();

            var PaginateInfo = await _services.GetPaginateInfo();


            // Map the list of Medical Conditions to MedicalContionQueryDTO
            var Page = _mapper.Map<List<MedicalContionQueryDTO>>(medicalCondition);


            return PaginatedResult<MedicalContionQueryDTO>
                .Create()
                .WithSucceeded(true)
                .WithData(Page)
                .WithTotaCount(PaginateInfo.TotalCount)
                .WithCurrentPage(request.PageNumber)
                .WithTotalPages(PaginateInfo.NumberOfPages)
                .WithPageSize(Page.Count)
                .Build();

        }

        #endregion
    }

}
