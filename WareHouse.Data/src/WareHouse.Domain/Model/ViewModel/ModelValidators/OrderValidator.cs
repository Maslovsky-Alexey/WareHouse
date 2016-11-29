using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model.ViewModel.ModelValidators
{
    public class OrderValidator : AbstractValidator<OrderViewModel>
    {
        public OrderValidator()
        {
            RuleFor(x => x)
                .NotNull();

            RuleFor(x => x.Client)
                .NotNull()
                .Must(x => x.Id >= 0);

            RuleFor(x => x.Count)
                .GreaterThan(0);

            RuleFor(x => x.Employee)
                .NotNull()
                .Must(x => !string.IsNullOrEmpty(x.Name));

            RuleFor(x => x.Item)
                .NotNull()
                .Must(x => x.Id >= 0);
        }
    }
}
