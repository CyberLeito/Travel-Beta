using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Travel_Beta.Admin
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindUserDetails();

            string productAction = Request.QueryString["ManageUser"];
            if (productAction == "remove")
            {
                LabelRemUserStatus.Text = "User Removed !";
                LabelRemUserStatus.ForeColor = Color.Green;
            }
        }

        protected void BindUserDetails()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.CommandText = "SELECT FirstName, LastName, Email, UserId From Users";
            cmd.Connection = con;
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(ds);


            gvDetails.DataSource = ds;
            gvDetails.DataBind();
            gvDetails.UseAccessibleHeader = true;
            gvDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void RemUser(object sender, EventArgs e)
        {
            //Remove from Access db
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            Conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Delete from Users where UserId = "+"'" + UserID_tb.Text + "'"+"";
            cmd.Connection = Conn;
            int a = cmd.ExecuteNonQuery();


            // Reload the page.
            string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
            Response.Redirect(pageUrl + "?ManageUser=remove");
        }
    }
}