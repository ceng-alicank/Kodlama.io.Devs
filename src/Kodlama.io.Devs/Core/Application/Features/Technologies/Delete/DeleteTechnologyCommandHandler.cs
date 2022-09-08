using Application.Services.Repositories;
using MediatR;

namespace Application.Features.Technologies.Delete
{
    public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommandRequest,bool>
    {
        private readonly ITechnologyRepository _technologyRepository;

        public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public async Task<bool> Handle(DeleteTechnologyCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id !=null)
            {
                var entity = await _technologyRepository.GetAsync(t => t.Id == request.Id);
                if (entity != null)
                {
                    await _technologyRepository.DeleteAsync(entity);
                    return true;    
                }
            }
            return false;
        }
    }
}
