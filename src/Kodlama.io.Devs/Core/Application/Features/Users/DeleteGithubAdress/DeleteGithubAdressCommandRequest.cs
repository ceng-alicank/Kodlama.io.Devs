using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.DeleteGithubAdress
{
    public class DeleteGithubAdressCommandRequest : IRequest<DeleteGithubAdressCommandResponse>
    {
        public int Id { get; set; }
    }
}
