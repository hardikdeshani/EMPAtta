<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="UserTaskDetails.aspx.cs" Inherits="admin_UserTaskDetails" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" Runat="Server">
    <fieldset>
        <legend>Task Details</legend>
        <asp:Repeater runat="server" ID="rData">
            <HeaderTemplate>
                <table width="100%">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>Task Date:</td>
                    <td><%#((DataRowView)Container.DataItem)["TaskDate"] %></td>
                </tr>
                <tr>
                    <td>Task Title:</td>
                    <td><%#((DataRowView)Container.DataItem)["TaskTitle"] %></td>
                </tr>
                <tr>
                    <td>Task Discription: </td>
                    <td><%#((DataRowView)Container.DataItem)["TaskDesc"] %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </fieldset>
</asp:Content>

