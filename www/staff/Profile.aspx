<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="staff_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <fieldset>
        <legend>Legend</legend>
        <table class="nostyle">
            <tr>
                <td width="20%">Name</td>
                <td>
                    <asp:TextBox runat="server" ID="tbName" CssClass="input-text"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Mobile No</td>
                <td>
                    <asp:TextBox runat="server" ID="tbMobileNo" CssClass="input-text"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbMobileNo" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Email ID</td>
                <td>
                    <asp:TextBox runat="server" ID="tbEmailID" CssClass="input-text"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator runat="server" ID="r3" ControlToValidate="tbEmailID" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox runat="server" ID="tbAddress" CssClass="input-text" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Designation</td>
                <td>
                    <asp:DropDownList runat="server" CssClass="input-text" ID="ddlDesignation"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:CheckBox runat="server" ID="cbIsActive" Text="Active" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Button runat="server" ID="btSave" CssClass="input-submit" Text="Save" ValidationGroup="vgA" />
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>

