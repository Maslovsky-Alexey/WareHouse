using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model.ViewModel.ModelValidators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(x => x)
                .NotNull()
                .Must(x => string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Name)
                .Length(3, 30);
        }
    }
}
