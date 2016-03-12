using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Travel_Beta.Models;

namespace Travel_Beta.Logic
{
    public class FeedbackAdd
    {
        public bool SubmitFeedback(string FeedbackContent)
        {
            var myFeedback = new FeedbackModel();
            myFeedback.FeedbackContent = FeedbackContent;

            using (ProductContext _db = new ProductContext())
            {
                // Add Feedback to DB.
                _db.Feedback.Add(myFeedback);
                _db.SaveChanges();
            }
            // Success.
            return true;
        }
    }
}