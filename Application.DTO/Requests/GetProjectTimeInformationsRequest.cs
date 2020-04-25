using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Requests
{
   public class GetProjectTimeInformationsRequest
    {
        public Guid Id { get; set; }

        public string ProjectName { get; set; }

        public double  Duration { get; set; }
    }
}
