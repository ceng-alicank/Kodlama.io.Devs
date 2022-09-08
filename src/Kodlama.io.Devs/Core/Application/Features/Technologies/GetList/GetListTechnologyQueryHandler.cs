using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.GetList
{
    public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQueryRequest, GetListTechnologyQueryResponse>
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IMapper _mapper;

        public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<GetListTechnologyQueryResponse> Handle(GetListTechnologyQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Technology> technologies = await _technologyRepository.GetListAsync
                (
                index: request.pageRequest.Page, size: request.pageRequest.PageSize,
                include:t=>t.Include(c=>c.ProgrammingLanguage)
               
                );
            return _mapper.Map<GetListTechnologyQueryResponse>(technologies); 
        }
    }
}
