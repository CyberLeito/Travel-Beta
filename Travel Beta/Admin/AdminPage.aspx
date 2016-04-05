<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Travel_Beta.Admin.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Administration</h1>
    <hr />
    <h3>Add Product</h3>

    
    <div class="col-sm-8"></div> 
    <div class="col-sm-4">
        <asp:Button ID="FeedbackRedir" runat="server" Text="View Customer Feedback" CssClass="btn btn-default" OnClick="GoToFeedback" CausesValidation="false"/>
        <asp:Button ID="Button1" runat="server" Text="Test PopUP" CssClass="btn btn-default" OnClick="popupTest" CausesValidation="false"/>
    
    </div>



    <br />
        <div class="form-group">
            <asp:Label ID="LabelAddCategory" runat="server" CssClass="col-md-2 control-label">Category:</asp:Label></>
              <asp:DropDownList ID="DropDownAddCategory" CssClass="form-control" style="max-width: 280px;" runat="server" 
                    ItemType="Travel_Beta.Models.Category" 
                    SelectMethod="GetCategories" DataTextField="CategoryName" 
                    DataValueField="CategoryID" >
                </asp:DropDownList>
       </div>
       
            <div class="form-group">
            <asp:Label ID="LabelAddName" runat="server" CssClass="col-md-2 control-label">Name:</asp:Label>
            <asp:TextBox ID="AddProductName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* Product name required." ControlToValidate="AddProductName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>
       
        <div class="form-group">
            <asp:Label ID="LabelAddDescription" runat="server" CssClass="col-md-2 control-label">Description:</asp:Label>
              <asp:TextBox ID="AddProductDescription" CssClass="form-control" rows = "3" TextMode="multiline" 
                  style="max-width: 280px;" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Description required." ControlToValidate="AddProductDescription" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
           </div>

         <div class="form-group">
            <asp:Label ID="LabelAddPrice" runat="server" CssClass="col-md-2 control-label">Price:</asp:Label>
              <asp:TextBox ID="AddProductPrice" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Text="* Price required." ControlToValidate="AddProductPrice" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Text="* Must be a valid price without $." ControlToValidate="AddProductPrice" SetFocusOnError="True" Display="Dynamic" ValidationExpression="^[0-9]*(\.)?[0-9]?[0-9]?$"></asp:RegularExpressionValidator>
            </div>

    <div class="form-group">
            <asp:Label ID="LabelAddImageFile" runat="server" CssClass="col-md-2 control-label">Image File:</asp:Label>
         <div class="col-md-10">
              <asp:FileUpload ID="ProductImage" runat="server" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Text="* Image path required." ControlToValidate="ProductImage" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
           </div>
   </div>
    <br />
    <br />
    <p></p>
    <p></p>
     <div class="col-md-offset-2 col-md-10">
    <asp:Button ID="AddProductButton" runat="server" Text="Add Product" CssClass="btn btn-primary" OnClick="AddProductButton_Click"  CausesValidation="true"/>
    </div>
         <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>
         <asp:Label ID="LabelAccessDBStatus" runat="server" Text=""></asp:Label>
    <p></p>
    <br />
    <br />
    <br />
    <hr />
   
    <h3>Remove Product</h3>
    <br />
    <div class="form-group">
            <asp:Label ID="LabelRemoveProduct" runat="server" CssClass="col-md-2 control-label">Product:</asp:Label>
            <asp:DropDownList ID="DropDownRemoveProduct" runat="server" ItemType="Travel_Beta.Models.Product" 
                     CssClass="form-control" style="max-width: 280px;"
                    SelectMethod="GetProducts" AppendDataBoundItems="true" 
                    DataTextField="ProductName" DataValueField="ProductID" >
                </asp:DropDownList>
           </div>

    <p></p>
     <div class="col-md-offset-2 col-md-10">
    <asp:Button ID="RemoveProductButton" runat="server" Text="Remove Product" CssClass="btn btn-primary" OnClick="RemoveProductButton_Click" CausesValidation="false"/>
    </div>
         <asp:Label ID="LabelRemoveStatus" runat="server" Text=""></asp:Label>

       

</asp:Content>