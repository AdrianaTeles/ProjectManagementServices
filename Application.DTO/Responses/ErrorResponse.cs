using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Responses
{/// <summary>
 /// This represents the response entity for error.
 /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }


        public string StackTrace { get; set; }
    }
}
