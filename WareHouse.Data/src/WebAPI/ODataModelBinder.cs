using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.MyOData;

namespace WebAPI
{
    public class ODataModelBinder : IModelBinder
    {
        SimpleTypeModelBinder baseBinder;

        public ODataModelBinder(Type type)
        {       
            baseBinder = new SimpleTypeModelBinder(type);
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(MyODataConfigurates))
            {
                bindingContext.Result = ModelBindingResult.Success(MyOData.GetConfiguratesFromQueryString(bindingContext.HttpContext.Request.QueryString.Value));
                return;
            }

            bindingContext.Result = ModelBindingResult.Failed();
        }
    }
}
