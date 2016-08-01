using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoeStore.Infrastructure
{
    public class ErrorResult : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly ErrorMessage _result;
        private readonly HttpStatusCode _statusCode = HttpStatusCode.BadRequest;

        public ErrorResult(HttpRequestMessage request, string message)
        {
            _request = request;
            _result = new ErrorMessage
            {
                error_code = (int)_statusCode,
                error_msg = message
            };
        }

        public ErrorResult(HttpRequestMessage request, string message, HttpStatusCode statusCode)
        {
            _request = request;
            _result = new ErrorMessage
            {
                error_code = (int)statusCode,
                error_msg = message
            };
            _statusCode = statusCode;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(_statusCode, _result);

            return Task.FromResult(response);
        }
    }
}