<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="staff_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <fieldset>
        <legend>Legend</legend>
        <table class="nostyle">
        <tr>
            <td align="center" colspan="3">
                <table width="100%" border="1">
                    <tr>
                        <th>Clock In</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="tbRemarksIn" CssClass="input-text" placeholder="Remarks" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbRemarksIn" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="btClockIn" CssClass="input-submit" Text="Clock In" ValidationGroup="vgA" />
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center" colspan="3">
                <table width="100%" border="1">
                    <tr>
                        <th>Clock Out</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="tbRemarksOut" CssClass="input-text" placeholder="Remarks" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbRemarksOut" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgOut"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button runat="server" ID="btClockOut" CssClass="input-submit" Text="Clock Out" ValidationGroup="vgOut" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        </table>
    </fieldset>
</asp:Content>
