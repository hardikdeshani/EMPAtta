<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="AttadenceReport.aspx.cs" Inherits="admin_AttadenceReport" %>

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
                    <h3 class="panel-title">Attadence Report</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <div class="col-lg-3">
                                    <asp:DropDownList runat="server" ID="ddlEmployee" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox runat="server" ID="tbFromDate" placeholder="From Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-2">
                                    <asp:TextBox runat="server" ID="tbToDate" placeholder="To Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <asp:DropDownList runat="server" ID="ddlEntryType" CssClass="form-control">
                                        <asp:ListItem Value="0">-- Select Status --</asp:ListItem>
                                        <asp:ListItem Value="1">Clock In</asp:ListItem>
                                        <asp:ListItem Value="2">Clock Out</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2">
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
                                                <th>Remarks</th>
                                                <th>Colck In / Out Date</th>
                                                <th>Entry Type</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr id="tTR" runat="server">
                                        <td><%#((DataRowView)Container.DataItem)["Name"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["Remarks"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["ClockInOutDate"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["EntryType"] %></td>
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

