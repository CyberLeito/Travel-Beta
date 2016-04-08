<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisaPayStart.aspx.cs" Inherits="Travel_Beta.Checkout.VisaPayStart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <br />
    <br />
    <div class="form-horizontal">
        <h4>Fill Payment info</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

    <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CardNumber" autocomplete="off" CssClass="col-md-2 control-label">Card Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CardNumber"  CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="CardNumber"
                    CssClass="text-danger" ErrorMessage="Card Number is required." />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ErrorMessage="Invalid card number" ControlToValidate="CardNumber" CssClass="text-danger" Display="Dynamic"
                    ValidationExpression="^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$" ></asp:RegularExpressionValidator> 
            </div>
        </div>


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ExpDate" CssClass="col-md-2 control-label">Expiry Date</asp:Label>
            <div class="col-md-10">
                <table>
                     <tr>
                         <td>
              <asp:DropDownList ID="ExpDate" CssClass="form-control" style="max-width: 80px;" runat="server" >
                    </asp:DropDownList>
                             </td>
                         <td>
                <asp:DropDownList ID="ExpMonth" CssClass="form-control" style="max-width: 80px;" runat="server" >
                    </asp:DropDownList>
                             </td>
                          </tr>
                    </table>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ExpDate"
                    CssClass="text-danger" ErrorMessage="Expiry date Year is required." />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ExpMonth"
                    CssClass="text-danger" ErrorMessage="Expiry date Month is required." />

                </div>
       </div>


        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="CVV" CssClass="col-md-2 control-label">CVV Number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" autocomplete="off" ID="CVV" style="max-width: 140px;"  CssClass="form-control" />

                <asp:RequiredFieldValidator runat="server" ControlToValidate="CVV"
                    CssClass="text-danger" ErrorMessage="Security Number is required." />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                    ErrorMessage="Invalid card number" ControlToValidate="CVV" CssClass="text-danger" Display="Dynamic"
                    ValidationExpression="^[0-9]{3,4}$" ></asp:RegularExpressionValidator> 
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Fullname" autocomplete="off" CssClass="col-md-2 control-label">Full Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Fullname" TextMode="singleline" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Fullname"
                    CssClass="text-danger" ErrorMessage="Card holder's Full name is required is required." />
            </div>
        </div>

         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="PhoneNumber" autocomplete="off" CssClass="col-md-2 control-label">Phone number</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PhoneNumber" TextMode="singleline" CssClass="form-control" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Enter valid Phone number! Eg; '601234567890'" ControlToValidate="PhoneNumber" CssClass="text-danger" Display="Dynamic"
                    ValidationExpression="\d{11}" ></asp:RegularExpressionValidator> 
                 <asp:RequiredFieldValidator runat="server" ControlToValidate="PhoneNumber"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Phone number is required." />
            </div>
        </div>


         <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="Pay_click" CssClass="btn btn-primary"  Text="Checkout with Visa" />

                
            </div>
        </div>






        </div>



</asp:Content>
