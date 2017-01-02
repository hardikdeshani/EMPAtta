<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="YourTimeDurationReport.aspx.cs" Inherits="staff_YourTimeDurationReport" %>

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
                    <h3 class="panel-title">Time Duration Report</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbFromDate" CssClass="form-control" placeholder="From Date"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbToDate" CssClass="form-control" placeholder="To Date"></asp:TextBox>
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
                            <asp:Repeater runat="server" ID="rData" OnItemDataBound="rData_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="datatable" class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Name</th>
                                                <th>Time Duration</th>
                                                <th>Date</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#((DataRowView)Container.DataItem)["Name"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["TotalTime"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["EntryDate"] %></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <tr>
                                        <td></td>
                                        <td><asp:Label ID="lblTotal" runat="server" /></td>
                                        <td></td>
                                    </tr>
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

