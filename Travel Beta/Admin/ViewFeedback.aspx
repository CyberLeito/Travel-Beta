<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewFeedback.aspx.cs" Inherits="Travel_Beta.Admin.ViewFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <h3>User Feedbacks</h3>

     <div class="col-sm-8"></div> 
        <div class="col-sm-4">
            <asp:Button ID="ExportFeedback" runat="server" Text="Export all Feedback" CssClass="btn btn-default" OnClick="ExportCSV" />
        </div>

    <asp:GridView ID="gvDetails" runat="server"
        CssClass="table table-hover table-striped" GridLines="None" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="FeedbackID" HeaderText="#"/>
            <asp:BoundField DataField="FeedbackContent" HeaderText="User Feedback"/>
        </Columns>
    </asp:GridView>










</asp:Content>
