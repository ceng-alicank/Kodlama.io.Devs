using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology:Entity
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }

        public Technology()
        {

        }
        public Technology(int id,string name, int programmingLanguageId):base(id)
        {
            Name = name;
            ProgrammingLanguageId = programmingLanguageId;
        }
    }
}
