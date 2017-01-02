<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="LeaveReport.aspx.cs" Inherits="admin_LeaveReport" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Leave Report</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-lg-4">
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
                                                <th>Name</th>
                                                <th>Remarks</th>
                                                <th>Leave Type</th>
                                                <th>From Date</th>
                                                <th>To Date</th>
                                                <th>Total Day(s)</th>
                                            </tr>
                                        </thead>
                                        <tbody>
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

