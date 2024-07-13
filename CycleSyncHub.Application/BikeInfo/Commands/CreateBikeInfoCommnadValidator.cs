using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CycleSyncHub.Application.BikeInfo.Commands
{
    public class CreateBikeInfoCommnadValidator : AbstractValidator<CreateBikeInfoCommand>
    {
        public CreateBikeInfoCommnadValidator()
        {
            RuleFor(s => s.Cost).NotEmpty().NotNull();
            RuleFor(s => s.Info).NotEmpty().NotNull();
            RuleFor(s => s.BikeEncodedName).NotEmpty().NotNull();

        }
    }
}
