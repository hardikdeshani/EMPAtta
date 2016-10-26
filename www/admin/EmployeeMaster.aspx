<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="EmployeeMaster.aspx.cs" Inherits="admin_EmployeeMaster" %>

<%@ Import Namespace="System.Data" %>
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
                    <asp:DropDownList runat="server" ID="ddlDesignation" CssClass="input-text"></asp:DropDownList>
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
    <br />
    <asp:Repeater runat="server" ID="rData">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>Name</th>
                    <th>Mobile No.</th>
                    <th>Email ID</th>
                    <th>Designation</th>
                    <th>Active</th>
                    <th>Operations</th>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#((DataRowView)Container.DataItem)["Name"] %></td>
                <td><%#((DataRowView)Container.DataItem)["Mobile"] %></td>
                <td><%#((DataRowView)Container.DataItem)["EmailID"] %></td>
                <td><%#((DataRowView)Container.DataItem)["DesignationName"] %></td>
                <td>
                    <%#((DataRowView)Container.DataItem)["IsActive"] %>
                </td>
                <td>
                    <asp:Button runat="server" Text="Edit" ID="btEdit" CommandName="cE" CommandArgument='<%#((DataRowView)Container.DataItem)["EMPIDP"] %>' />
                    <asp:Button runat="server" Text="Delete" ID="btDelete" CommandName="cD" CommandArgument='<%#((DataRowView)Container.DataItem)["EMPIDP"] %>' OnClientClick="return confirm('Do You Really Want To Delete This Record?');" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

