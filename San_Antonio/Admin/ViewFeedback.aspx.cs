using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Models;
using System.Web.ModelBinding;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Travel_Beta.Admin
{
    public partial class ViewFeedback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindUserDetails();
        }

        //public IQueryable<FeedbackModel> GetFeedback([QueryString("id")] int? feedbackId)
        //{
        //    var _db = new Travel_Beta.Models.ProductContext();
        //    IQueryable<FeedbackModel> query = _db.Feedback;
        //    if (feedbackId.HasValue && feedbackId > 0)
        //    {
        //        query = query.Where(p => p.FeedbackID == feedbackId);
        //    }
        //    return query;
        //}

        //protected ViewFeedback()
        //{

        //    OleDbConnection Conn = new OleDbConnection();
        //    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        //    Conn.Open();
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.CommandText = "SELECT * From Feedback";
        //    cmd.Connection = Conn;
        //    int a = cmd.ExecuteNonQuery();

        //}


        protected void BindUserDetails()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();
            cmd.CommandText = "SELECT * From Feedback";
            cmd.Connection = con;
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(ds);

           
            gvDetails.DataSource = ds;
            gvDetails.DataBind();
            gvDetails.UseAccessibleHeader = true;
            gvDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        ///////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////
        protected void ExportCSV(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlCommand cmd = new SqlCommand();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            cmd.CommandText = "SELECT * From Feedback";
            cmd.Connection = con;
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);

                //Build the CSV file data as a Comma separated string.
                string csv = string.Empty;

                foreach (DataColumn column in dt.Columns)
                {
                    //Add the Header row for CSV file.
                    csv += column.ColumnName + ',';
                }

                //Add new line.
                csv += "\r\n";

                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        //Add the Data rows.
                        csv += row[column.ColumnName].ToString().Replace(",", ";") + ',';
                    }

                    //Add new line.
                    csv += "\r\n";
                }

                //Download the CSV file.
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=Feedback.csv");
                Response.Charset = "";
                Response.ContentType = "application/text";
                Response.Output.Write(csv);
                Response.Flush();
                Response.End();
            }
             
    }

}