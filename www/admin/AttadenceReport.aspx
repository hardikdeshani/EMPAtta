<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="AttadenceReport.aspx.cs" Inherits="admin_AttadenceReport" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <fieldset>
        <legend>Search</legend>
        <table class="nostyle" align="center">
            <tr>
                <td>Name</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="input-submit"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button runat="server" ID="btSave" CssClass="input-submit" Text="Search" OnClick="btSave_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <asp:Repeater runat="server" ID="rData">
        <HeaderTemplate>
            <table width="100%">
                <tr>
                    <th>Name</th>
                    <th>Remarks</th>
                    <th>Colck In / Out Date</th>
                    <th>Entry Type</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#((DataRowView)Container.DataItem)["Name"] %></td>
                <td><%#((DataRowView)Container.DataItem)["Remarks"] %></td>
                <td><%#((DataRowView)Container.DataItem)["ClockInOutDate"] %></td>
                <td><%#((DataRowView)Container.DataItem)["EntryType"] %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

