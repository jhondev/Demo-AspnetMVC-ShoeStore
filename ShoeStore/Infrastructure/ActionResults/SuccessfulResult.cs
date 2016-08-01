using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShoeStore.Infrastructure
{
    public class SuccessfulResult<T> : IHttpActionResult
    {
        private readonly HttpRequestMessage _request;
        private readonly SuccessfulMessage<T> _data;
        private readonly HttpStatusCode _statusCode = HttpStatusCode.OK;

        public SuccessfulResult(HttpRequestMessage request, T data)
        {
            _request = request;
            _data = new SuccessfulMessage<T> { Data = data };
        }

        public SuccessfulResult(HttpRequestMessage request, T data, HttpStatusCode statusCode)
        {
            _request = request;
            _statusCode = statusCode;
            _data = new SuccessfulMessage<T> { Data = data };
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(_statusCode, _data);

            return Task.FromResult(response);
        }
    }
}
