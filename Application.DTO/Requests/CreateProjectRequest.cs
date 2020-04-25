using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.Requests
{
    public class CreateProjectRequest
    {
        [Required]
        public string ProjectName { get; set; }

    }
}
