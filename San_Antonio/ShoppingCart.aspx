<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="Travel_Beta.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    

    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="Travel_Beta.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />        
        <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}"/>     
        <asp:TemplateField   HeaderText="Quantity">            
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:TextBox> 
                </ItemTemplate>        
        </asp:TemplateField>    
        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Product.UnitPrice)))%>
                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Remove Item">            
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>    
        </Columns>    
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />
     <table> 
    <tr>
      <td>
        <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" CausesValidation="false" />
      </td>
      <td>
        <!--Checkout Placeholder -->
          <asp:ImageButton ID="CheckoutImageBtn" runat="server" 
                      ImageUrl="http://www.friendsofwcc.org/uploads/images/icons/dues-with-paypal.png" 
                      Width="145" AlternateText="Check out with PayPal" 
                      OnClick="PayX_click" CausesValidation="false"
                      BackColor="Transparent" BorderWidth="0" />
          <asp:ImageButton ID="ImageButton2" runat="server" 
                      ImageUrl="http://promotions.newegg.com/nepro/15-5474/images/vcobtn.jpg" 
                      Width="145" AlternateText="Check out with PayPal" 
                      OnClick="CheckoutBtn_Click2" CausesValidation="false"
                      BackColor="Transparent" BorderWidth="0" />
                   
      </td>
    </tr>
    </table>

    <div ></div> 
    <div >
        <br />
     <h4>Shipping Address</h4>
         


       <asp:FormView ID="gxDetails"
  RunAt="server">

  <ItemTemplate>
    <table>
      <tr>
        <td align="right"><b>Country: </b></td>       
        <td><%# Eval("Country") %></td>
      </tr>
      <tr>
        <td align="right"><b>Name: </b></td>     
        <td><%# Eval("ContactName") %></td>
      </tr>
      <tr>
        <td align="right"><b>Street Address: </b></td>      
        <td><%# Eval("StreetAddress") %></td>
      </tr>
      <tr>
        <td align="right"><b>City: </b></td>
        <td><%# Eval("City") %></td>
      </tr>
      <tr>
        <td align="right"><b>State: </b></td>       
        <td><%# Eval("State") %></td>
      </tr>
    </table>                 
  </ItemTemplate>                 
</asp:FormView>






       <%-- <asp:Label ID="check1" runat="server" />
        <asp:Button type="button" runat="server" Text="CHECK" class="btn btn-default" onclick="BindUserDetails" CausesValidation="false" />
       --%>    

        <%--//////////////////////*************************////////////////////////--%>
         <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
  <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>


        <div id="contxx" class="container">
  
  <!-- Trigger the modal with a button -->
            <div id="SetAddrr" runat="server">
  <button type="button" class="btn btn-info " data-toggle="modal" data-target="#myModal">Set Shipping address</button>
            </div>
  <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Shipping Address</h4>
        </div>
        <div class="modal-body">
            <%--///////////////////////*************************////////////////////////--%>
          <p>Enter your shipping address.</p>
            <br />

            <div class="form-group">
            <asp:Label ID="lbl1" runat="server" CssClass="col-md-2 control-label">Country:</asp:Label>
            <asp:TextBox ID="country" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="country" runat="server" Text="* Country required." SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
            <asp:Label ID="Label1" runat="server" CssClass="col-md-2 control-label">Contact Name:</asp:Label>
            <asp:TextBox ID="Cname" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Contact name required." ControlToValidate="Cname" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
            <asp:Label ID="Label2" runat="server" CssClass="col-md-2 control-label">Street Address:</asp:Label>
            <asp:TextBox ID="streetAddress" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Street address required." ControlToValidate="streetAddress" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
            <asp:Label ID="Label3" runat="server" CssClass="col-md-2 control-label">City:</asp:Label>
            <asp:TextBox ID="city" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="city" runat="server" Text="* Country required." SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
           
            <div class="form-group">
            <asp:Label ID="Label4" runat="server" CssClass="col-md-2 control-label">State:</asp:Label>
            <asp:TextBox ID="Xstate" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="Xstate" runat="server" Text="* Country required." SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>


            <%--////////////////////////////////////////--%>
        </div>
        <div class="modal-footer">   
          <asp:Button type="button" runat="server" Text="Submit" class="btn btn-default" onclick="AddressFill" CausesValidation="True" />
           
        </div>
      </div>
      
    </div>
  </div> 
 
</div>  <%--///////_EXIT MODAL_ POPUP    //////--%>

      

    </div>  <%--///////_RIGHT box div    //////--%>
    
    </asp:Content>