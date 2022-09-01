using Application.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.Response
{
    public class GetProgrammingLanguageListQueryResponse: BasePageableModel
    {
        public IList<ProgrammingLanguageGetListDto>? Items { get; set; }

    }
}
