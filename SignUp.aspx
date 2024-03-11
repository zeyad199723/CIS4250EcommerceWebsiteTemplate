<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="SignUp.aspx.vb" Inherits="OnlineStoreFall2023.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <h1>Sign Up for an Account</h1>
</br>

<div class="signup-form-group">
 <asp:Label ID="FirstNameLabel" runat="server" Text="First Name"></asp:Label>
 <asp:TextBox ID="FirstNameTextBox" runat="server" Placeholder="Enter your first name" style="margin-bottom: 10px;"></asp:TextBox>
</div>
</br>

<div class="signup-form-group">
 <asp:Label ID="LastNameLabel" runat="server" Text="Last Name"></asp:Label>
 <asp:TextBox ID="LastNameTextBox" runat="server" Placeholder="Enter your last name" style="margin-bottom: 10px;"></asp:TextBox>
</div>
</br>

<div class="signup-form-group">
 <asp:Label ID="EmailLabel" runat="server" Text="Email Address"></asp:Label>
 <asp:TextBox ID="EmailTextBox" runat="server" Placeholder="Enter your email address" style="margin-bottom: 10px;"></asp:TextBox>
</div>
</br>

<div class="signup-form-group">
 <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
 <asp:TextBox ID="PasswordTextBox" runat="server" Placeholder="Enter a password" TextMode="Password" style="margin-bottom: 10px;"></asp:TextBox>
</div>
</br>

<asp:Button ID="SignupButton" runat="server" Text="Sign Up" style="margin-top: 10px;" class="signup-button"></asp:Button>


</asp:Content>
