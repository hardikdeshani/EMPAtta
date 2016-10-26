<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="staff_Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 900px; border: 1px solid #000; margin: 0 auto; padding: 5px;">
            <table align="center" width="100%">
                <tr align="center">
                    <td colspan="2">
                        <asp:LinkButton runat="server" ID="lLogout" Text="Logout" OnClick="lLogout_Click"></asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <br />
                        <br />
                        <table>
                            <tr>
                                <th>Clock In</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="tbRemarksIn" placeholder="Remarks" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbRemarksIn" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btClockIn" Text="Clock In" ValidationGroup="vgA" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="center">
                        <table>
                            <tr>
                                <th>Clock Out</th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="tbRemarksOut" placeholder="Remarks" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbRemarksOut" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgOut"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button runat="server" ID="btClockOut" Text="Clock Out" ValidationGroup="vgOut" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
