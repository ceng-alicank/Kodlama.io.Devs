using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Create
{
    public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommandRequest, CreateTechnologyCommandResponse>
    {
        private readonly ITechnologyRepository _technologyRepository;

        private readonly IMapper _mapper;

        public CreateTechnologyCommandHandler(IMapper mapper, ITechnologyRepository technologyRepository)
        {
            _mapper = mapper;
            _technologyRepository = technologyRepository;
        }

        public async Task<CreateTechnologyCommandResponse> Handle(CreateTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Technology>(request);
            var createdTechnolgy = await _technologyRepository.AddAsync(entity);
            return _mapper.Map<CreateTechnologyCommandResponse>(createdTechnolgy);
        }
    }
}
