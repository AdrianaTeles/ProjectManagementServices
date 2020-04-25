
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
   public class ProjectDuration
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Duration { get; set; }
    }
}
