using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using TAYF.Application.DTOs;

namespace TAYF.API.Middleware
{
    /// <summary>
    /// Middleware to handle exceptions and return consistent error responses.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred while executing the request.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500
            var result = string.Empty;

            switch (exception)
            {
                case ArgumentException argEx:
                    // Treat ArgumentException as 404 Not Found (e.g., plant not found)
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new ErrorResponseDto
                    {
                        StatusCode = (int)code,
                        Message = argEx.Message,
                        Errors = new List<string>()
                    });
                    break;
                case KeyNotFoundException knfEx:
                    code = HttpStatusCode.NotFound;
                    result = JsonSerializer.Serialize(new ErrorResponseDto
                    {
                        StatusCode = (int)code,
                        Message = knfEx.Message,
                        Errors = new List<string>()
                    });
                    break;
                case InvalidOperationException ioEx:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(new ErrorResponseDto
                    {
                        StatusCode = (int)code,
                        Message = ioEx.Message,
                        Errors = new List<string>()
                    });
                    break;
                // Add more exception types as needed
                default:
                    // For any other exception, return 500 with a generic message
                    result = JsonSerializer.Serialize(new ErrorResponseDto
                    {
                        StatusCode = (int)code,
                        Message = "An unexpected error occurred. Please contact support.",
                        Errors = new List<string>() { exception.Message } // In production, you might want to hide the actual message
                    });
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}