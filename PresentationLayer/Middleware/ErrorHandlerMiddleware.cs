using ApplicationLayer.Models;
using DomainLayer;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace PresentationLayer.Middleware
{
    // Global middleware to catch errors

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<ErrorHandlerMiddleware> _logger;


        public ErrorHandlerMiddleware(RequestDelegate next)//ILogger<ErrorHandlerMiddleware> logger
        {
            _next = next;
            //_logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                // Intercept the 403 status code and change it to 401 if needed
                if (context.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized; // Change 403 to 401
                    var responseModel = new ResponseBuilder<string>()
                        .WithSuccess(false)
                        .WithMessage("Access denied. You are not authorized.")
                        .WithErrors(new List<string> { "Access denied." })
                        .Build();

                    var result = JsonSerializer.Serialize(responseModel);
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(result);
                }
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ResponseBuilder<string>().WithSuccess(false).WithErrors(new List<string> { error?.Message! }).Build();
                //TODO:: cover all validation errors
                switch (error)
                {
                    case UnauthorizedAccessException:
                        // custom application error
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.Unauthorized;
                        response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;

                    case ValidationException:
                        // custom validation error
                        responseModel.Message = error.Message;
                        responseModel.StatusCode = HttpStatusCode.UnprocessableEntity;
                        response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        break;

                    case KeyNotFoundException:
                        // not found error
                        responseModel.Message = error.Message; ;
                        responseModel.StatusCode = HttpStatusCode.NotFound;
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    case DbUpdateException e:
                        // can't update error
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    case BadRequestException e:
                        responseModel.Message = e.Message;
                        responseModel.StatusCode = HttpStatusCode.BadRequest;
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;


                    case Exception e:
                        if (e.GetType().ToString() == "ApiException")
                        {
                            responseModel.Message += e.Message;
                            responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message;
                            responseModel.StatusCode = HttpStatusCode.BadRequest;
                            response.StatusCode = (int)HttpStatusCode.BadRequest;
                        }
                        responseModel.Message = e.Message;
                        responseModel.Message += e.InnerException == null ? "" : "\n" + e.InnerException.Message;

                        responseModel.StatusCode = HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                    default:
                        // unhandled error
                        responseModel.Message = error?.Message;
                        responseModel.StatusCode = HttpStatusCode.InternalServerError;
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;

                }
                //// If the response status code is 403, change it to 401
                //if (response.StatusCode == (int)HttpStatusCode.Forbidden)
                //{
                //    response.StatusCode = (int)HttpStatusCode.Unauthorized; // Change 403 to 401
                //    responseModel.Message = "Access denied. You are not authorized."; // Optional custom message
                //}
                // Log the error details
                // _logger.LogError(error, "An error occurred: {Message}", responseModel.Message);
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
