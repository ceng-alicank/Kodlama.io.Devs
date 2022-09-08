using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repsitories
{
    public class TechnologyRepository : EfRepositoryBase<Technology, AppDbContext>, ITechnologyRepository
    {
        public TechnologyRepository(AppDbContext context) : base(context)
        {

        }

    }
}
