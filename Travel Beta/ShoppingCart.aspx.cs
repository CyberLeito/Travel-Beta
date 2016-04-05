using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travel_Beta.Models;
using Travel_Beta.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity;


namespace Travel_Beta
{
    public partial class ShoppingCart : System.Web.UI.Page
    {

        protected void BindUserDetails()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["AccessDB"].ToString();
            OleDbCommand cmd = new OleDbCommand();
            DataSet ds = new DataSet();
            cmd.CommandText = "SELECT * From Addresses where UserID = '" + Context.User.Identity.GetUserId() + "'";
            cmd.Connection = con;
            OleDbDataAdapter Da = new OleDbDataAdapter(cmd);
            Da.Fill(ds);

            if (ds.Tables.Count > 0)   //check for NOT empty..err..return from access query
            {
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Rows.Count > 0)
                    {
                        // do your job
                        gxDetails.DataSource = ds;
                        gxDetails.DataBind();
                    }
                    else
                    {
                        // check1.Text = "NO rows int htekjsd";
                        SetAddrr.Visible = true;

                    }
                }
            }// end of NOT Empty query check


            //  gvDetails.UseAccessibleHeader = true;
            // gvDetails.HeaderRow.TableSection = TableRowSection.TableHeader;
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            bool loggedIn = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;

            if(loggedIn == false)
            {
                Response.Redirect("~/Account/Login");
            }

            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                decimal cartTotal = 0;
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingCartTitle.InnerText = "Shopping Cart is Empty";
                    UpdateBtn.Visible = false;
                    CheckoutImageBtn.Visible = false; //paypal checkout button
                    ImageButton2.Visible = false; //visa checkout button
                    SetAddrr.Visible = false;
                }
            }

            BindUserDetails();
        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartActions actions = new ShoppingCartActions();
            return actions.GetCartItems();
        }
        public List<CartItem> UpdateCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCartItems();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
        }

        protected void CheckoutBtn_Click(object sender, ImageClickEventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                Session["payment_amt"] = usersShoppingCart.GetTotal();
            }
            Response.Redirect("Checkout/CheckoutStart.aspx");
        }


        protected void CheckoutBtn_Click2(object sender, ImageClickEventArgs e)
        {
           Response.Redirect("Checkout/VisaPayStart.aspx");
        }

        //=============================================================================================================
        //=============================================================================================================
        //=============================================================================================================
        //=============================================================================================================
       



        protected void AddressFill(object sender, EventArgs e)
        {
            string usrID = Context.User.Identity.GetUserId();
            
            OleDbConnection Conn = new OleDbConnection();
            Conn.ConnectionString = ConfigurationManager.ConnectionStrings["AccessDB"].ToString();
            Conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            
            cmd.CommandText = "insert into Addresses(Country,ContactName,StreetAddress,City,State,UserID) values('" + country.Text + "','" + Cname.Text + "','" + streetAddress.Text + "','" + city.Text + "','" + Xstate.Text + "','"+ usrID +"')";
            cmd.Connection = Conn;
            int a = cmd.ExecuteNonQuery();
            //-----------------------POP_SUCCSS-------------------------------------------------
            string message = "Address Added Successfully";
            string url = "../";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            //------------------------------------------------------------------------------------

        }



    }
}
