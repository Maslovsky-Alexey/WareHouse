using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Model.ViewModel.ModelValidators
{
    public class ValidationFactory : ValidatorFactoryBase
    {
        private static Dictionary<Type, IValidator> validators = new Dictionary<Type, IValidator>();

        static ValidationFactory()
        {
            validators.Add(typeof(IValidator<OrderViewModel>), new OrderValidator());
            validators.Add(typeof(IValidator<SupplyViewModel>), new SupplyValidator());
            validators.Add(typeof(IValidator<Item>), new ItemValidator());
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            IValidator validator;

            if (validators.TryGetValue(validatorType, out validator))
            {
                return validator;
            }

            return validator;
        }
    }
}
