using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.GetList
{
    public class GetListTechnologyQueryRequest:IRequest<GetListTechnologyQueryResponse>
    {
        public PageRequest pageRequest { get; set; }
    }
}
