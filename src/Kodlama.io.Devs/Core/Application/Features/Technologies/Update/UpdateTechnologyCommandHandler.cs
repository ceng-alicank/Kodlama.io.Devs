using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Update
{
    public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommandRequest, UpdateTechnologyCommandResponse>
    {


        private readonly ITechnologyRepository _technologyRepository;

        private readonly IMapper _mapper;
        public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper)
        {
            _technologyRepository = technologyRepository;
            _mapper = mapper;
        }

        public async Task<UpdateTechnologyCommandResponse> Handle(UpdateTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Technology>(request);
            var updatedEntity = await _technologyRepository.UpdateAsync(entity);
            if (updatedEntity != null)
            {
                return _mapper.Map<UpdateTechnologyCommandResponse>(updatedEntity);
            }
            return null;

        }
    }
}
