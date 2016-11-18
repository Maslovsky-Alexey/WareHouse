using Microsoft.AspNetCore.Mvc.ModelBinding;
using WareHouse.MyOData;

namespace WebAPI
{
    // TODO: а почему это не часть MyOData?
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