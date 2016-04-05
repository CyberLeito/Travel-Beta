using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Models;
using Travel_Beta.Logic;
using System.Data.OleDb;
using System.Configuration;

namespace Travel_Beta.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {

        protected void GoToFeedback(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ViewFeedback.aspx");
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

                //add to ACCESS
                OleDbConnection Conn = new OleDbConnection();
                Conn.ConnectionString = ConfigurationManager.ConnectionStrings["AccessDB"].ToString();
                Conn.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "insert into Products(ProductName,Description,UnitPrice,CategoryID,ProductImage)values('" + AddProductName.Text + "','" + AddProductDescription.Text + "','" + AddProductPrice.Text + "','" + DropDownAddCategory.SelectedValue + "','" + path + ProductImage.FileName + "')";
                cmd.Connection = Conn;
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    LabelAccessDBStatus.Text = "Added to access DB";
                }

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

                    //Remove from Access db
                    OleDbConnection Conn = new OleDbConnection();
                    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["AccessDB"].ToString();
                    Conn.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = "Delete from Products where ProductID = "+ productId +"";
                    cmd.Connection = Conn;
                    int a = cmd.ExecuteNonQuery();
                    if (a > 0)
                    {
                        LabelAccessDBStatus.Text = "Products removed from access DB";
                    }



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
