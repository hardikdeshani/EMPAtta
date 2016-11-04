<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="DesignationMaster.aspx.cs" Inherits="admin_DesignationMaster" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <asp:HiddenField runat="server" ID="hfID" />
    <fieldset>
        <legend>Designation</legend>
        <table class="nostyle" align="center">
            <tr>
                <td>Designation Name</td>
                <td>
                    <asp:TextBox runat="server" ID="tbDesignationName" CssClass="input-text"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbDesignationName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:CheckBox runat="server" ID="cbIsActive" Text="" />&nbsp;&nbsp;Active
                </td>
                <td>
                    <asp:Button runat="server" ID="btSave" CssClass="input-submit" Text="Save" OnClick="btSave_Click" ValidationGroup="vgA" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <asp:Repeater runat="server" ID="rData" OnItemCommand="rData_ItemCommand">
        <HeaderTemplate>
            <table width="100%">
                <tr>
                    <th>Designation Name</th>
                    <th>Active</th>
                    <th>Operations</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%#((DataRowView)Container.DataItem)["DesignationName"] %>
                </td>
                <td>
                    <%#((DataRowView)Container.DataItem)["IsActive"] %>
                </td>
                <td>
                    <asp:Button runat="server" Text="Edit" ID="btEdit" CssClass="input-submit" CommandName="cE" CommandArgument='<%#((DataRowView)Container.DataItem)["DesignationIDP"] %>' />
                    <asp:Button runat="server" Text="Delete" ID="btDelete" CssClass="input-submit" CommandName="cD" CommandArgument='<%#((DataRowView)Container.DataItem)["DesignationIDP"] %>' OnClientClick="return confirm('Do You Really Want To Delete This Record?');" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

