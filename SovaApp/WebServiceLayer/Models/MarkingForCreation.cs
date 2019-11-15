using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.Models
{
    public class MarkingForCreation
    {
        [Required]
        [MaxLength(20)]
        public string UserEmail { get; set; }
        [MaxLength(50)]
        public string QuestionId { get; set; }
    }
}