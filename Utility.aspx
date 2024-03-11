<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Utility.aspx.vb" Inherits="OnlineStoreFall2023.Utility" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:SqlDataSource ID="DSMainCategory" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringOnlineStore %>" SelectCommand="SELECT * FROM [Category] WHERE Parent = 0"></asp:SqlDataSource>
    </form>
</body>
</html>
