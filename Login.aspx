<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Template.Master" CodeBehind="Login.aspx.vb" Inherits="OnlineStoreFall2023.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div style="text-align: left;">
      <h1>Login to your Account</h1>
<br />

Email: <br />
    <asp:TextBox ID="tbUsername" runat="server"></asp:TextBox><br />
<br />
 <br />

Password: <br />
<asp:TextBox ID="tbPassword" runat="server" Placeholder=""></asp:TextBox>


<br />
<br />

        <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-default"/><br /></div>
        <asp:Label ID="lblMessage" runat="server" Text="" />



</asp:Content>
