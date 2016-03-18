using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Logic;
using Travel_Beta.Models;

namespace Travel_Beta
{
    public partial class Feedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Submit_feedback_ButtonClick(object sender, EventArgs e)
        {

            FeedbackAdd feedbk = new FeedbackAdd();
            bool addSuccess = feedbk.SubmitFeedback(FeedbackEntry.Text);
            if (addSuccess)
            {
                // Reload the page.
                LabelAddStatus.Text = "Successfully submitted feedback";
                FeedbackEntry.Text = string.Empty;
            }
            else
            {
                LabelAddStatus.Text = "Unable to Submit feedback.";
            }

        }
    }
}