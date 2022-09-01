using Application.Features.ProgrammingLanguages.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UpdateProgrammingLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommandRequest>
    {
        public UpdateProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
