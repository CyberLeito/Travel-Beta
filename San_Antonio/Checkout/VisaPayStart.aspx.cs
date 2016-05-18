using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Logic;
using Travel_Beta.Models;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Configuration;

namespace Travel_Beta.Checkout
{
    public partial class VisaPayStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //sets range of Expirydate years, 2016 till 21 years from now
            ExpDate.DataSource = Enumerable.Range(2016, 21).ToList();
            ExpDate.DataBind();

            //Sets 12 months for Exp month dropdown
            ExpMonth.DataSource = Enumerable.Range(01, 12).ToList();
            ExpMonth.DataBind();

        }


        protected void Pay_click(object sender, EventArgs e)
        {
            string message = "Payment Successful";
            string url = "../";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


            //-----------------------------------------------------------------------------
            using (Travel_Beta.Logic.ShoppingCartActions myCartOrders = new Travel_Beta.Logic.ShoppingCartActions())
            {
                List<CartItem> myOrderList = myCartOrders.GetCartItems();

                for (int i = 0; i < myOrderList.Count; i++)
                {
                    string Pname = myOrderList[i].Product.ProductName.ToString();
                    string price = myOrderList[i].Product.UnitPrice.ToString();
                    string quantity = myOrderList[i].Quantity.ToString();
                    DateTime DateNow = DateTime.Today;
                    string user = Context.User.Identity.GetUserId();

                    //add to ACCESS
                    SqlConnection Conn = new SqlConnection();
                    Conn.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
                    Conn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "insert into OrdersX(ProductName,Price,Quantity,Date,UserID)values('" + Pname + "','" + price + "','" + quantity + "','" + DateNow + "','" + user + "')";
                    cmd.Connection = Conn;
                    int a = cmd.ExecuteNonQuery();
                    
                }
            }



            ShoppingCartActions SP = new ShoppingCartActions();
            SP.EmptyCart();
        }



    }
}