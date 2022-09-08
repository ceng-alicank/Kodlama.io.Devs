using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Create
{
    public class CreateUserCommandRequest:IRequest<CreateUserCommandResponse>
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}
