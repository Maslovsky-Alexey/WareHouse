using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WareHouse.MyOData;

namespace WareHouse.MyOData
{
    public class ODataModelBinder : IModelBinder
    {
        private SimpleTypeModelBinder baseBinder;

        public ODataModelBinder(Type type)
        {
            baseBinder = new SimpleTypeModelBinder(type);
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(MyODataConfigurates))
            {
                bindingContext.Result =
                    ModelBindingResult.Success(
                        MyOData.GetConfiguratesFromQueryString(bindingContext.HttpContext.Request.QueryString.Value));
                return;
            }

            bindingContext.Result = ModelBindingResult.Failed();
        }
    }
}