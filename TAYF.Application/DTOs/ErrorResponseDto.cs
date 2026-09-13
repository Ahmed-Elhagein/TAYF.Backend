using System;
using System.Collections.Generic;

namespace TAYF.Application.DTOs
{
    /// <summary>
    /// Data transfer object for error responses.
    /// </>
    public class ErrorResponseDto
    {
        /// <summary>
        /// Gets or sets the HTTP status code.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a list of error details.
        /// </summary>
        public List<string> Errors { get; set; } = new();
    }
}