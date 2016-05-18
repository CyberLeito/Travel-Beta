using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Models;
using Travel_Beta.Logic;
//using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Travel_Beta.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {

        protected void GoToFeedback(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ViewFeedback.aspx");
        }

        protected void GoToManageUser(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ManageUsers.aspx");
        }

        public void popupTest(object sender, EventArgs e)
        {
    
            string message = "You will now be redirected to Home Page.";
            string url = "../";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                LabelAddStatus.Text = "Product added!";
            }

            if (productAction == "remove")
            {
                LabelRemoveStatus.Text = "Product removed!";
            }


        }

        protected void AddProductButton_Click(object sender, EventArgs e)
        {

            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Images/");
            if (ProductImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(ProductImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    ProductImage.PostedFile.SaveAs(path + ProductImage.FileName);
                    // Save to Images/Thumbs folder.
                    ProductImage.PostedFile.SaveAs(path + "Thumbs/" + ProductImage.FileName);
                }
                catch (Exception ex)
                {
                    LabelAddStatus.Text = ex.Message;
                }

                ////add to ACCESS
                //SqlConnection Conn = new SqlConnection();
                //Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                //Conn.Open();
                //SqlCommand cmd = new SqlCommand();
                //cmd.CommandText = "insert into Products(ProductName,Description,UnitPrice,CategoryID,ProductImage)values('" + AddProductName.Text + "','" + AddProductDescription.Text + "','" + AddProductPrice.Text + "','" + DropDownAddCategory.SelectedValue + "','" + path + ProductImage.FileName + "')";
                //cmd.Connection = Conn;
                //int a = cmd.ExecuteNonQuery();
                //if (a > 0)
                //{
                //    LabelDefaultConnectionStatus.Text = "Added to access DB";
                //}

                // Add product data to DB.
                AddProducts products = new AddProducts();
                bool addSuccess = products.AddProduct(AddProductName.Text, AddProductDescription.Text,
                    AddProductPrice.Text, DropDownAddCategory.SelectedValue, ProductImage.FileName);
                if (addSuccess)

                {
                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=add");
                }
                else
                {
                    LabelAddStatus.Text = "Unable to add new product to database.";
                }
            }
            else
            {
                LabelAddStatus.Text = "Unable to accept file type.";
            }

                           
        }

        public IQueryable GetCategories()
        {
            var _db = new Travel_Beta.Models.ProductContext();
            IQueryable query = _db.Categories;
            return query;
        }

        public IQueryable GetProducts()
        {
            var _db = new Travel_Beta.Models.ProductContext();
            IQueryable query = _db.Products;
            return query;
        }


        //----------------GENERATE REPORTSS----------------------------------------

        protected void GenerateReportOrders(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlCommand cmd = new SqlCommand();
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            string selVal = DropDownList1.SelectedValue.ToString();

            if (selVal == "Monthly")
            {
                cmd.CommandText = "SELECT * From OrdersX WHERE DATEPART(month, Date) = MONTH(GETDATE()) ";

            }
            else if (selVal == "Annual")
            {
                cmd.CommandText = "SELECT * From OrdersX WHERE DATEPART(year, Date) = YEAR(GETDATE()) ";

            }
            else if (selVal == "Entire")
            {
                cmd.CommandText = "SELECT * From OrdersX";

            }
           

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
            Response.AddHeader("content-disposition", "attachment;filename=OrdersReport'"+DropDownList1.SelectedValue+"'.csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv);
            Response.Flush();
            Response.End();
        }



        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {
            using (var _db = new Travel_Beta.Models.ProductContext())
            {
                int productId = Convert.ToInt16(DropDownRemoveProduct.SelectedValue);
                var myItem = (from c in _db.Products where c.ProductID == productId select c).FirstOrDefault();
                if (myItem != null)
                {
                    _db.Products.Remove(myItem);
                    _db.SaveChanges();

                    ////Remove from Access db
                    //SqlConnection Conn = new SqlConnection();
                    //Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                    //Conn.Open();
                    //SqlCommand cmd = new SqlCommand();
                    //cmd.CommandText = "Delete from Products where ProductID = "+ productId +"";
                    //cmd.Connection = Conn;
                    //int a = cmd.ExecuteNonQuery();
                    //if (a > 0)
                    //{
                    //    LabelDefaultConnectionStatus.Text = "Products removed from access DB";
                    //}



                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Unable to locate product.";
                }
            }
        }
    }
}
