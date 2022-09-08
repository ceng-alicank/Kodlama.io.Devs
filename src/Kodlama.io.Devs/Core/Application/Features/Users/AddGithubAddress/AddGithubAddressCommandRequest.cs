using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.AddGithubAddress
{
    public class AddGithubAddressCommandRequest:IRequest<AddGithubAddressCommandResponse>
    {
        public int Id { get; set; }
        public string GithubAddress { get; set; }
    }
}
