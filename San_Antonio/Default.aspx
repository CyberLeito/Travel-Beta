<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Travel_Beta._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="bg">
        <img src="Content/KL-Skyline_Night_HDR.JPG" width="100%" height="350px"/vcass>
        <%--<img src="Content/cass.jpg" width="100%" height="350px"/>--%>

    </div>
    <div class="jumbotron">
        <h1>Welcome to San Antonio Online</h1>
        <p class="lead">We felt a connection... Did you?</p>
    </div>

    <div class="row">
        <div class="size-list" >
            
                <%--<asp:Image ID="Image1" runat="server" HorizontalAlign="Center" width="100%" ImageUrl="http://www.millenniumhotels.com/content/dam/global/en/grand-millennium-kuala-lumpur/images/KL-Skyline_Night_HDR.JPG"/>--%>
            
                 <%-----------------%>
                
        <div id="CategoryMenu" class = "products" style="text-align: center">  
            <h3>Select Product Category</h3>     
            <asp:ListView ID="categoryList"  
                ItemType="Travel_Beta.Models.Category" 
                runat="server"
                SelectMethod="GetCategories" >
                <ItemTemplate>
                    <b style="font-size: x-large; font-style: italic">
                        <a href="/ProductList.aspx?id=<%#: Item.CategoryID %>">
                        <%#: Item.CategoryName %>
                        </a>
                    </b>
                </ItemTemplate>
                <ItemSeparatorTemplate>  |  </ItemSeparatorTemplate>
            </asp:ListView>
        </div>
  
                <br />
          </div>
    </div>

</asp:Content>
