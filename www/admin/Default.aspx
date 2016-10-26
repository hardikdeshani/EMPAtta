<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 250px; padding: 5px; border: 1px solid #000; margin: 250px auto">
            <table align="center">
                <tr>
                    <th colspan="3">Admin Login</th>
                </tr>
                <tr>
                    <td>User Name</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbUserName"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbUserName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox runat="server" ID="tbPassword"></asp:TextBox></td>
                    <td>
                        <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbPassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button runat="server" ID="btLogin" Text="Login" ValidationGroup="vgA" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
