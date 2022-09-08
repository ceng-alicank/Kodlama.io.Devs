using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.AddGithubAdress
{
    public class AddGithubAdressCommandRequest:IRequest<AddGithubAdressCommandResponse>
    {
        public int Id { get; set; }
        public string GithubAdress { get; set; }
    }
}
