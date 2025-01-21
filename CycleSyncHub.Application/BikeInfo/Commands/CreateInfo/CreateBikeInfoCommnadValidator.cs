using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CycleSyncHub.Application.BikeInfo.Commands.CreateInfo
{
    public class CreateBikeInfoCommnadValidator : AbstractValidator<CreateBikeInfoCommand>
    {
        public CreateBikeInfoCommnadValidator()
        {
            RuleFor(s => s.Cost).NotEmpty().NotNull();
            RuleFor(s => s.Info).NotEmpty().NotNull().MaximumLength(100);
            RuleFor(s => s.BikeEncodedName).NotEmpty().NotNull();

        }
    }
}
