using System.Net;

namespace ApplicationLayer.Models
{
    public class Response<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public object? Meta { get; set; }
        public bool Succeeded { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = null!;
        public T Data { get; set; } = default!;


    }


    // The Builder class
    public class ResponseBuilder<T>
    {
        private readonly Response<T> _response;

        public ResponseBuilder()
        {
            _response = new Response<T>();
        }

        public ResponseBuilder<T> WithStatusCode(HttpStatusCode statusCode)
        {
            _response.StatusCode = statusCode;
            return this;
        }

        public ResponseBuilder<T> WithSuccess(bool succeeded)
        {
            _response.Succeeded = succeeded;
            return this;
        }

        public ResponseBuilder<T> WithMessage(string message)
        {
            _response.Message = message;
            return this;
        }

        public ResponseBuilder<T> WithData(T data)
        {
            _response.Data = data;
            return this;
        }

        public ResponseBuilder<T> WithMeta(object? meta)
        {
            _response.Meta = meta;
            return this;
        }

        public ResponseBuilder<T> WithErrors(List<string> errors)
        {
            _response.Errors = errors;
            return this;
        }

        public Response<T> Build()
        {
            return _response;
        }
    }
}
