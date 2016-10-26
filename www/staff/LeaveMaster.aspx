<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="LeaveMaster.aspx.cs" Inherits="staff_LeaveMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <table width="100%" border="1">
        <tr>
            <td valign="top">Remarks
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbRemarks" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbRemarks" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Leave Type
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlLeaveType" AutoPostBack="true" OnSelectedIndexChanged="ddlLeaveType_SelectedIndexChanged">
                    <asp:ListItem Value="0">-- Select Leave Type --</asp:ListItem>
                    <asp:ListItem Value="1">Single</asp:ListItem>
                    <asp:ListItem Value="2">Multiple</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="ddlLeaveType" InitialValue="0" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr runat="server" id="trFromDate" visible="false">
            <td>From Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbFromDate"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr runat="server" id="trToDate" visible="false">
            <td>To Date
            </td>
            <td>
                <asp:TextBox runat="server" ID="tbToDate"></asp:TextBox>
            </td>
            <td></td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Button runat="server" ID="btSave" Text="Save" ValidationGroup="vgA" />
            </td>
        </tr>
    </table>
</asp:Content>
