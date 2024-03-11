<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Payment.aspx.vb" Inherits="OnlineStoreFall2023.Payment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Credit Card: <asp:TextBox ID="tbCreditCard" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnAPI" runat="server" Text="Button" /><br />
            Authorization Code: <asp:Label ID="lblAuthCode" runat="server" Text="Label"></asp:Label><br />
            Transaction ID: <asp:Label ID="lblTransactionID" runat="server" Text="Label"></asp:Label><br />
            Return Array: <asp:Label ID="lblReturnArray" runat="server" Text="Label"></asp:Label><br />
        </div>
    </form>
</body>
</html>
