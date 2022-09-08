using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repsitories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, AppDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {

        }

    }
}
