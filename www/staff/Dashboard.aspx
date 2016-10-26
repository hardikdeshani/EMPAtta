<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="staff_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <table width="100%">
        <tr>
            <td align="center" colspan="3">
                <br />
                <br />
                <table width="100%" border="1">
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
            <td align="center" colspan="3">
                <br />
                <br />
                <table width="100%" border="1">
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
</asp:Content>
