﻿<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="UserWiseTaskList.aspx.cs" Inherits="admin_UserWiseTaskList" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/js/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=tbFromDate.ClientID%>').datepicker({
                numberOfMonths: 3,
                showButtonPanel: true,
                format: "dd-mm-yyyy",
                autoclose: true
            });

            $('#<%=tbToDate.ClientID%>').datepicker({
                numberOfMonths: 3,
                showButtonPanel: true,
                format: "dd-mm-yyyy",
                autoclose: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Task Details</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <div class="col-lg-3">
                                    <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-lg-3">
                                    <asp:TextBox runat="server" ID="tbFromDate" placeholder="From Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <asp:TextBox runat="server" ID="tbToDate" placeholder="To Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <asp:Button runat="server" ID="btSave" CssClass="btn btn-primary" Text="Search" OnClick="btSave_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Record(s)</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <asp:Repeater runat="server" ID="rData">
                                <HeaderTemplate>
                                    <table id="datatable" class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Employee Name</th>
                                                <th>Task Title</th>
                                                <th>Task Date</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#((DataRowView)Container.DataItem)["Name"] %></td>
                                        <td><b><a href='UserTaskDetails.aspx?tt=<%#((DataRowView)Container.DataItem)["TaskIDP"] %>&ud=<%#((DataRowView)Container.DataItem)["UserIDF"]%>' style="text-decoration: none;"><%#((DataRowView)Container.DataItem)["TaskTitle"] %></a></b></td>
                                        <td><%#((DataRowView)Container.DataItem)["TaskDate"] %></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

