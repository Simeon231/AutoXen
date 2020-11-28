namespace AutoXen.Web.Infrastructure.ModelBinders
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class TrimModelBinder : IModelBinder
    {
        ////private readonly IModelBinder objIModelBinder;

        ////public TrimModelBinder(IModelBinder objIModelBinder)
        ////{
        ////    this.objIModelBinder = objIModelBinder ?? throw new
        ////     ArgumentNullException(nameof(objIModelBinder));
        ////}

        public Task BindModelAsync(ModelBindingContext objModelBindingContext)
        {
            if (objModelBindingContext == null)
            {
                throw new ArgumentNullException(nameof(objModelBindingContext));
            }

            var valueProviderResult = objModelBindingContext.ValueProvider.GetValue(objModelBindingContext.ModelName);
            if (valueProviderResult != null && valueProviderResult.FirstValue is string str &&
              !string.IsNullOrEmpty(str))
            {
                objModelBindingContext.Result = ModelBindingResult.Success(str.Trim());
            }

            ////return this.objIModelBinder.BindModelAsync(objModelBindingContext);

            return Task.CompletedTask;
        }
    }
}
