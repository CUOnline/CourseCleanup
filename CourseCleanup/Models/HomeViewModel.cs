using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseCleanup.Models
{
    public class HomeViewModel
    {
        [Display(Name = "Start Term")]
        public string StartTerm { get; set; }
        
        [Display(Name = "End Term")]
        public string EndTerm { get; set; }

        public string UserEmail { get; set; }

        public IEnumerable<SelectListItem> Terms { get; set; }
        
        public bool Authorized { get; set; }
    }
}