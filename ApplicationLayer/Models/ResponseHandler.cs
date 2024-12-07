using ApplicationLayer.Resources;
using Microsoft.Extensions.Localization;
using System.Net;

namespace ApplicationLayer.Models
{
    public class ResponseHandler
    {
        private readonly IStringLocalizer<SharedResoruces> _stringLocalizer;

        public ResponseHandler(IStringLocalizer<SharedResoruces> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public Response<T> Deleted<T>(string? message = null)
        => new ResponseBuilder<T>()
                .WithStatusCode(HttpStatusCode.OK)
                .WithSuccess(true)
                .WithMessage(message ?? _stringLocalizer[SharedResorucesKeys.Deleted])
                .Build();


        public Response<T> Success<T>(T entity, object? meta = null)
            => new ResponseBuilder<T>()
                .WithStatusCode(HttpStatusCode.OK)
                .WithSuccess(true)
                .WithMessage(_stringLocalizer[SharedResorucesKeys.Success])
                .WithData(entity)
                .WithMeta(meta)
                .Build();


        public Response<T> Unauthorized<T>()
        => new ResponseBuilder<T>()
                .WithStatusCode(HttpStatusCode.Unauthorized)
                .WithSuccess(false)
                .WithMessage(_stringLocalizer[SharedResorucesKeys.Unauthorized])
                .Build();


        public Response<T> BadRequest<T>(string? message = null)

          => new ResponseBuilder<T>()
               .WithStatusCode(HttpStatusCode.BadRequest)
               .WithSuccess(false)
               .WithMessage(message ?? _stringLocalizer[SharedResorucesKeys.BadRequest])
               .Build();


        public Response<T> UnprocessableEntity<T>(string? message = null)
           => new ResponseBuilder<T>()
               .WithStatusCode(HttpStatusCode.UnprocessableEntity)
               .WithSuccess(false)
               .WithMessage(message ?? _stringLocalizer[SharedResorucesKeys.UnprocessableEntity])
               .Build();


        public Response<T> NotFound<T>(string? message = null)
            => new ResponseBuilder<T>()
                .WithStatusCode(HttpStatusCode.NotFound)
                .WithSuccess(false)
                .WithMessage(message ?? _stringLocalizer[SharedResorucesKeys.NotFound])
                .Build();


        public Response<T> Created<T>(T entity, object? meta = null)
            => new ResponseBuilder<T>()
                .WithStatusCode(HttpStatusCode.Created)
                .WithSuccess(true)
                .WithMessage(_stringLocalizer[SharedResorucesKeys.Created])
                .WithData(entity)
                .WithMeta(meta)
                .Build();

    }
}
