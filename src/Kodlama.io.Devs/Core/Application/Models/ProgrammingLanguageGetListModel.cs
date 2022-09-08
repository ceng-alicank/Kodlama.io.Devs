using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProgrammingLanguageGetListModel:BasePageableModel
    {
        public IList<ProgrammingLanguage>  Items { get; set; }
    }
}
