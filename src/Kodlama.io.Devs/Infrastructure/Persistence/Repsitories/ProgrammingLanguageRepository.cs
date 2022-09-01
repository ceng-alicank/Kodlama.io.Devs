using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repsitories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage, AppDbContext>, IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(AppDbContext context) : base(context)
        {

        }
    }
}
