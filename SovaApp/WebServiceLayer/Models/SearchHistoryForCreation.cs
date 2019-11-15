using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceLayer.Models
{
    public class SearchHistoryForCreation
    {
        [Required]
        [MaxLength(20)]
        public string Email { get; set; }
        public DateTime SearchDate { get { return DateTime.Now; }}
       
        [Required]
        [MaxLength(100)]
        public string SearchText { get; set; }
    }
}
