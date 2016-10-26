<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="DesignationMaster.aspx.cs" Inherits="admin_DesignationMaster" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <fieldset>
        <legend>Legend</legend>
        <table class="nostyle">
            <tr>
                <td>Designation Name</td>
                <td>
                    <asp:TextBox runat="server" ID="tbDesignationName" CssClass="input-text"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbDesignationName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox runat="server" ID="cbIsActive" Text="Active" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="btSave" CssClass="input-submit" Text="Save" OnClick="btSave_Click" ValidationGroup="vgA" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <asp:Repeater runat="server" ID="rData">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>Designation Name</th>
                    <th>Active</th>
                    <th>Operations</th>
                </tr>
            </table>
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
                    <asp:Button runat="server" Text="Edit" ID="btEdit" CommandName="cE" CommandArgument='<%#((DataRowView)Container.DataItem)["DesignationIDP"] %>' />
                    <asp:Button runat="server" Text="Delete" ID="btDelete" CommandName="cD" CommandArgument='<%#((DataRowView)Container.DataItem)["DesignationIDP"] %>' OnClientClick="return confirm('Do You Really Want To Delete This Record?');" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

