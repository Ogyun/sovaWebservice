using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.Models
{
    public class NoteForCreation
    {
        [Required]
        [MaxLength(20)]
        public string UserEmail { get; set; }
        [Required]
        [MaxLength(500)]
        public string Notetext { get; set; }
        [Required]
        [MaxLength(50)]
        public string QuestionId { get; set; }
    }
}
