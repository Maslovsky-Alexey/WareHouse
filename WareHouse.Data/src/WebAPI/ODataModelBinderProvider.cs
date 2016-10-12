using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WareHouse.MyOData;

namespace WebAPI
{
    public class ODataModelBinderProvider : IModelBinderProvider
    {
        
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {

            if (context.Metadata.ModelType != typeof(MyODataConfigurates))
                return null;

            return new ODataModelBinder(context.Metadata.ModelType);
        }
        
    }
}
