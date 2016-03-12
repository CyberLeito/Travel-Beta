using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Travel_Beta.Models
{
    public class FeedbackModel
    {
        [ScaffoldColumn(false)]
        public int FeedbackID { get; set; }

        [Required, StringLength(10000), Display(Name = "User Feedback"), DataType(DataType.MultilineText)]
        public string FeedbackContent { get; set; }
    }
}