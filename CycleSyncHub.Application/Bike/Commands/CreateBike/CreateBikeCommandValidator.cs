using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CycleSyncHub.Application.Commands.CreateBike;
using CycleSyncHub.Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace CycleSyncHub.Application.Bike.Commands.CreateBike
{
    public class CreateBikeCommandValidator : AbstractValidator<CreateBikeCommand>
    {
        public CreateBikeCommandValidator(IBikeRepository repository)
        {
            RuleFor(c => c.Model)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20)
                .Custom((value, context) =>
                {
                    var existingBike = repository.GetByName(value).Result;
                    if (existingBike != null)
                    {
                        context.AddFailure($"{value} name is reserved");
                    }
                });

            RuleFor(c => c.Description)
                .NotEmpty();

            RuleFor(c => c.TypeOfBike)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(10);

        }
    }
}
