using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Logic;

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

            ShoppingCartActions SP = new ShoppingCartActions();
            SP.EmptyCart();
        }



    }
}