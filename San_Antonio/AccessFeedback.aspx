﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccessFeedback.aspx.cs" Inherits="Travel_Beta.AccessFeedback" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h2>Dont Forget your feedback</h2>

    <br />

    
     <asp:Image ID="Image1" class="AboutImg34" runat="server" ImageUrl="~/Content/pic4.jpg" />
    <br />
  


    <div class="Someii">
         <div class="form-group">
            <asp:Label ID="Feedbacklabel" runat="server" CssClass="col-md-2 control-label">Feedback:</asp:Label>
              <asp:TextBox ID="FeedbackEntry" CssClass="form-control" rows = "3" TextMode="multiline" 
                  style="max-width: 500px;" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Text="* Feedback cannot be empty." ControlToValidate="FeedbackEntry" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
           </div>
         <div class="col-md-offset-2 col-md-10">
    <asp:Button ID="SubmitFeedbackButton" runat="server" Text="Submit Feedback" CssClass="btn btn-primary" OnClick="Submit_feedback_ButtonClick"  CausesValidation="true"/>
    </div>
        <asp:Label ID="LabelFeedbackStatus" runat="server" Text=""></asp:Label>
    </div>

</asp:Content>
