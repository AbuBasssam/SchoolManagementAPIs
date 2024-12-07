using ApplicationLayer.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace PresentationLayer.Controllers
{

    public abstract class ApiController : ControllerBase
    {
        #region Fields

        private ISender? _sender;

        #endregion

        /// <summary>
        /// Gets the sender.
        /// </summary>
        protected ISender Sender
        {
            get
            {
                if (_sender == null)
                {
                    _sender = HttpContext.RequestServices.GetService<ISender>();
                    if (_sender == null)
                    {
                        throw new InvalidOperationException("ISender service is not registered.");
                    }
                }
                return _sender;
            }
        }
        // protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();
        public ObjectResult NewResult<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case System.Net.HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case System.Net.HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case System.Net.HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case System.Net.HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case System.Net.HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case System.Net.HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                default:
                    return new BadRequestObjectResult(response);
            }
        }
    }
}
