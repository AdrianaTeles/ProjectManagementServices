using Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Responses
{
    public class GetProjectTimeInformationsResponse : ApiResponse
    {
        public GetProjectTimeInformationsResponse(List<string> errors, int responseCode = 200, bool hasError = false) : base(responseCode, hasError, errors)
        {
            ProjectInformations = new List<DTO.Models.Project>();
        }

        public List<DTO.Models.Project> ProjectInformations { get; set; }
    }
}
