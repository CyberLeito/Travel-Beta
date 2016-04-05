using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

namespace Travel_Beta
{
    public partial class AccessFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_feedback_ButtonClick(object sender, EventArgs e)
        {

            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["AccessDB"].ToString();
            Conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into Feedback(FeedbackContent)values('" + FeedbackEntry.Text + "')";
            cmd.Connection = Conn;
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                LabelFeedbackStatus.Text = "Added to access DB";
            }

        }
    }
}