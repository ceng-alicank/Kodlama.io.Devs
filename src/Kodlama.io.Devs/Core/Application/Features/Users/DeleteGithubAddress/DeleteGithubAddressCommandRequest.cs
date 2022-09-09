using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.DeleteGithubAddress 
{
    public class DeleteGithubAddressCommandRequest : IRequest<DeleteGithubAddressCommandResponse> , ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles { get; set; }

    }
}
