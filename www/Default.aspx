<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css'>
    <link href="logincss/login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <br>
        <br>
        <br>
        <br>
        <br>
        <br>
        <div class="login-card">
            <h1>User Login</h1>
            <br>
            <div>
                <asp:TextBox runat="server" ID="tbUserName" placeholder="User Name"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbUserName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                <asp:TextBox runat="server" ID="tbPassword" placeholder="Password"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                <asp:Button runat="server" ID="btLogin" CssClass="login login-submit" OnClick="btLogin_Click" Text="Login" ValidationGroup="vgA" />
            </div>
        </div>
    </form>
    <!-- <div id="error"><img src="https://dl.dropboxusercontent.com/u/23299152/Delete-icon.png" /> Your caps-lock is on.</div> -->
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js'></script>
</body>
</html>
