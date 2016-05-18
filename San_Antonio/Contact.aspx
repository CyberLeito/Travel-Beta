<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Travel_Beta.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <p>We want to hear from you. To help speed up our reply, it may be quicker to contact someone in your local region. At present we have stores and offices in over 60 countries around the world.</p>
    <p></p>
    <p>You can easily contact us at:</p>
    <p>Email: customer@santonio.com.my</p>
    <p>Phone: +60 17 2909870</p>
        <asp:Image ID="Image1" class="AboutImg2" runat="server" ImageUrl="~/Content/cus.jpg" />

    <p></p>
    <address>
        <strong>Support:</strong>   <a href="mailto:SupportService@sanantonio.com">SupportSerice@sanantonio.com.my</a><br />
        <strong>Marketing:</strong> <a href="mailto:MarketingService@sanantonio.com">MarketingService@sanantonio.com.my</a>
    </address>
</asp:Content>
