using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace ShoeStore.Infrastructure
{
    public class ValidateModelAttribute : OrderedActionFilterAttribute
    {
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            ActionExecuting(ref actionContext);

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }

        private void ActionExecuting(ref HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.ContainsValue(null))
            {
                actionContext.Response = actionContext.Request.
                    CreateResponse(HttpStatusCode.BadRequest, 
                    new ErrorMessage 
                    { 
                        error_code = 400,
                        error_msg = "Bad Request"
                    });

                return;
            }

            if (!actionContext.ModelState.IsValid)
            {
                var httpErrorMessage = ResultHelper.GetHttpErrorMessage(actionContext.ModelState);

                actionContext.Response = actionContext.Request.
                    CreateResponse(HttpStatusCode.BadRequest, ResultHelper.GetHttpErrorMessage(actionContext.ModelState));
            }
        }
    }
}
