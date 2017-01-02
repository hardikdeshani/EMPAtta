<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="LeaveMaster.aspx.cs" Inherits="staff_LeaveMaster" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/js/jquery.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=tbFromDate.ClientID%>').datepicker({
                numberOfMonths: 3,
                showButtonPanel: true,
                format: "dd-mm-yy",
                autoclose: true
            });

            $('#<%=tbToDate.ClientID%>').datepicker({
                numberOfMonths: 3,
                showButtonPanel: true,
                format: "dd-mm-yy",
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
                    <h3 class="panel-title">Manage Leave</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Remarks</label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="tbRemarks" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbRemarks" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Leave Type</label>
                                <div class="col-lg-4">
                                    <asp:DropDownList runat="server" ID="ddlLeaveType" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLeaveType_SelectedIndexChanged">
                                        <asp:ListItem Value="0">-- Select Leave Type --</asp:ListItem>
                                        <asp:ListItem Value="1">Single</asp:ListItem>
                                        <asp:ListItem Value="2">Multiple</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="ddlLeaveType" InitialValue="0" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group" runat="server" id="trFromDate" visible="false">
                                <label for="cname" class="control-label col-lg-2">From Date</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="tbFromDate"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r3" ControlToValidate="tbFromDate" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group" runat="server" id="trToDate" visible="false">
                                <label for="cname" class="control-label col-lg-2">To Date</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="tbToDate"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <asp:Button runat="server" CssClass="btn btn-primary" ID="btSave" OnClick="btSave_Click" Text="Save" ValidationGroup="vgA" />
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
