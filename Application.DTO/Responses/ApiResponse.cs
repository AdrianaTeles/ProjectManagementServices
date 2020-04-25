using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Responses
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Errors = new List<string>();
        }

        public ApiResponse(int responseCode, bool hasError, List<string> errors)
        {
            ResponseCode = responseCode;
            HasError = hasError;
            Errors = errors;
        }

        public int ResponseCode { get; set; }

        public bool HasError { get; set; }

        public List<string> Errors { get; set; }
    }
}
