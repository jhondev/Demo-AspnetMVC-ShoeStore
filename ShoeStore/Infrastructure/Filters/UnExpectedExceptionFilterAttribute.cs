using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace ShoeStore.Infrastructure
{
    public class UnExpectedExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.
                CreateResponse(HttpStatusCode.InternalServerError,
                new ErrorMessage
                {
                    error_code = 500,
                    //error_msg = $"UnExpectedException {context.Exception}"
                    error_msg = "Server Error"
                });
        }
    }
}