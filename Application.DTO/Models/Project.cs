using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Models
{
    public class Project
    {
        public Guid Id { get; set; }

        public string Duration { get; set; }

        public string ProjectName { get; set; }
    }
}
