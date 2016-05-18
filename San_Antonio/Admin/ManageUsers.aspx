<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Travel_Beta.Admin.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <h3>Manage Users</h3>

    <asp:GridView ID="gvDetails" runat="server"
        CssClass="table table-hover table-striped" GridLines="None" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="Firstname"/>
            <asp:BoundField DataField="LastName" HeaderText="Lastname"/>
            <asp:BoundField DataField="Email" HeaderText="Email"/>
            <asp:BoundField DataField="UserId" HeaderText="User ID"/>
        </Columns>
    </asp:GridView>

    <br />

    <h4>Remove User</h4>
    <br />
    <div class="form-group">
            <asp:Label ID="Userid" runat="server" CssClass="col-md-2 control-label">Enter User ID to remove:</asp:Label>
            <asp:TextBox ID="UserID_tb" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="*User ID cannot be empty." ControlToValidate="UserID_tb" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </div>

    <div class="col-md-offset-2 col-md-10">
    <asp:Button ID="RemoveProductButton" runat="server" Text="Remove User" CssClass="btn btn-primary" OnClick="RemUser" CausesValidation="true"/>
    </div>
    <asp:Label ID="LabelRemUserStatus" runat="server" Text=""></asp:Label>

    </asp:Content>
