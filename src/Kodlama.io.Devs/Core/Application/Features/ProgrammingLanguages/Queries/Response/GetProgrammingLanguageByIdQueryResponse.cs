﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.Response
{
    public class GetProgrammingLanguageByIdQueryResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}