namespace AutoXen.Web.ModelBinders
{
    using System;

    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class TrimModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!context.Metadata.IsComplexType &&
                context.Metadata.ModelType == typeof(string))
            {
                return new TrimModelBinder();
            }

            return null;
        }
    }
}
