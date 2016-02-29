<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Travel_Beta._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg">
        <img src="Content/KL-Skyline_Night_HDR.JPG" width="100%" height="350px"/>
    </div>
    <div class="jumbotron">
        <h1>Tropica Travels</h1>
        <p class="lead">Tropica Travels is Malaysia&#39;s leading tourism and travel company. we show you the inside out of Malaysia.</p>
    </div>

    <div class="row">
        <div class="col-md-4" >
            <p>
                <%--<asp:Image ID="Image1" runat="server" HorizontalAlign="Center" width="100%" ImageUrl="http://www.millenniumhotels.com/content/dam/global/en/grand-millennium-kuala-lumpur/images/KL-Skyline_Night_HDR.JPG"/>--%>
            </p>
            <p>
                 <%-----------------%>
        <div id="CategoryMenu" class = "products" style="text-align: center">       
            <asp:ListView ID="categoryList"  
                ItemType="Travel_Beta.Models.Category" 
                runat="server"
                SelectMethod="GetCategories" >
                <ItemTemplate>
                    <b style="font-size: large; font-style: normal">
                        <a href="/ProductList.aspx?id=<%#: Item.CategoryID %>">
                        <%#: Item.CategoryName %>
                        </a>
                    </b>
                </ItemTemplate>
                <ItemSeparatorTemplate>  |  </ItemSeparatorTemplate>
            </asp:ListView>
        </div>
    <%-----------------%>
                <br />
                &nbsp;</p>
        </div>
    </div>

</asp:Content>
