////using System;
////using System.Collections.Generic;
////using System.Text;

////namespace AutoXen.Web.Infrastructure.ModelBinders
////{
////    public class TrimModelBinder : IModelBinder
////    {
////        public object BindModel(ControllerContext controllerContext,
////        ModelBindingContext bindingContext)
////        {
////            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
////            if (valueResult == null || valueResult.AttemptedValue == null)
////                return null;
////            else if (valueResult.AttemptedValue == string.Empty)
////                return string.Empty;
////            return valueResult.AttemptedValue.Trim();
////        }
////    }
////}
