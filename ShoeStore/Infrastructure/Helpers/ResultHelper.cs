using System;
using System.Linq;
using System.Web.Http.ModelBinding;

namespace ShoeStore.Infrastructure
{
    public class ResultHelper
    {
        public static ErrorMessage GetResultMessage(ModelStateDictionary modelStateDictionary)
        {
            var modelState = modelStateDictionary.FirstOrDefault(ms => ms.Value.Errors.Count > 0).Value;

            if (modelState == null)
                throw new Exception("There are no modelstate errors");

            var modelError = modelState.Errors.First();

            return new ErrorMessage { error_msg = string.IsNullOrWhiteSpace(modelError.ErrorMessage) && modelError.Exception != null ? 
                modelError.Exception.Message : modelError.ErrorMessage };
        }

        public static ErrorMessage GetHttpErrorMessage(ModelStateDictionary modelStateDictionary)
        {
            var modelState = modelStateDictionary.FirstOrDefault(ms => ms.Value.Errors.Count > 0).Value;

            if (modelState == null)
                throw new Exception("There are no modelstate errors");

            var modelError = modelState.Errors.First();

            return new ErrorMessage
            {
                error_code = 400,
                error_msg = string.IsNullOrWhiteSpace(modelError.ErrorMessage) && modelError.Exception != null ?
                    modelError.Exception.Message : modelError.ErrorMessage
            };
        }
    }
}