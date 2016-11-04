<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="LeaveReport.aspx.cs" Inherits="admin_LeaveReport" %>

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
                    <th>Leave Type</th>
                    <th>From Date</th>
                    <th>To Date</th>
                    <th>Total Day(s)</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%#((DataRowView)Container.DataItem)["Name"] %></td>
                <td><%#((DataRowView)Container.DataItem)["Remarks"] %></td>
                <td><%#((DataRowView)Container.DataItem)["LeaveType"] %></td>
                <td><%#((DataRowView)Container.DataItem)["FromDate"] %></td>
                <td><%#((DataRowView)Container.DataItem)["ToDate"] %></td>
                <td><%#((DataRowView)Container.DataItem)["DayCount"] %></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

