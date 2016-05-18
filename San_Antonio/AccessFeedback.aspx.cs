using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;

namespace Travel_Beta
{
    public partial class AccessFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_feedback_ButtonClick(object sender, EventArgs e)
        {
            ////----ACCESS COMMANDS-------
            //OleDbConnection Conn = new OleDbConnection();
            //Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            //Conn.Open();
            //OleDbCommand cmd = new OleDbCommand();
            //cmd.CommandText = "insert into Feedback(FeedbackContent)values('" + FeedbackEntry.Text + "')";
            //cmd.Connection = Conn;
            //int a = cmd.ExecuteNonQuery();
            //if (a > 0)
            //{
            //    LabelFeedbackStatus.Text = "Added to access DB";
            //}
            ////-------ABANDONED------------

            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into Feedback(FeedbackContent)values('" + FeedbackEntry.Text + "')";
            cmd.Connection = Conn;
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                LabelFeedbackStatus.Text = "Added to Database"; // <<usually does not work, IDK why
                FeedbackEntry.Text = "";
            }

        }
    }
}