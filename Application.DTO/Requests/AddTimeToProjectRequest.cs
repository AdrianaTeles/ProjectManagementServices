using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO.Requests
{
    public class AddTimeToProjectRequest
    {
        [Required]
        public double time { get; set; }
        [Required]
        public Guid projectId { get; set; }
    }
}
