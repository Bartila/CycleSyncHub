using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CycleSyncHub.Application.Bike.Commands.EditBike
{
    public class EditBikeCommandValidator : AbstractValidator<EditBikeCommand>
    {
        public EditBikeCommandValidator()
        {
            RuleFor(c => c.Model)
              .NotEmpty()
              .MinimumLength(2)
              .MaximumLength(20);

            RuleFor(c => c.Description)
                .NotEmpty();

            RuleFor(c => c.TypeOfBike)
                .NotEmpty();

            RuleFor(c => c.Weight)
                .NotEmpty();

            RuleFor(c => c.Size)
                .NotEmpty();

            RuleFor(c => c.GroupSet)
                .NotEmpty();

        }
    }
}
