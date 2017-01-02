<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="TaskMaster.aspx.cs" Inherits="staff_TaskMaster" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
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
    <asp:HiddenField runat="server" ID="hfID" />
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Manage Task</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Task Title</label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="tbTitle" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbTitle" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Project</label>
                                <div class="col-lg-4">
                                    <asp:DropDownList runat="server" ID="ddlProject" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Work Type</label>
                                <div class="col-lg-4">
                                    <asp:DropDownList runat="server" ID="ddlWorkType" CssClass="form-control">
                                        <asp:ListItem Value="1">Normal</asp:ListItem>
                                        <asp:ListItem Value="2">Error</asp:ListItem>
                                        <asp:ListItem Value="3">Re-Work</asp:ListItem>
                                        <asp:ListItem Value="4">Error Re Work</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Task Discription</label>
                                <div class="col-lg-10">
                                    <FCKeditorV2:FCKeditor ID="FCKeditor" runat="server">
                                    </FCKeditorV2:FCKeditor>
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
                    <h3 class="panel-title">Search</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <div class="form-group">
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbFromDate" CssClass="form-control" placeholder="From Date"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbToDate" CssClass="form-control" placeholder="To Date"></asp:TextBox>
                                </div>
                                <div class="col-lg-4">
                                    <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
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
                            <asp:Repeater runat="server" ID="rData" OnItemCommand="rData_ItemCommand">
                                <HeaderTemplate>
                                    <table id="datatable" class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Task Title</th>
                                                <th>Task Date</th>
                                                <th>Project</th>
                                                <th>Work Type</th>
                                                <th>Edit</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><b><a href='TaskDetails.aspx?tt=<%#((DataRowView)Container.DataItem)["TaskIDP"] %>' style="text-decoration: none;"><%#((DataRowView)Container.DataItem)["TaskTitle"] %></a></b></td>
                                        <td><%#((DataRowView)Container.DataItem)["TaskDate"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["ProjectName"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["WorkType"] %></td>
                                        <td>
                                            <asp:Button runat="server" Text="Edit" ID="btEdit" CommandName="cE" CssClass="btn btn-primary" CommandArgument='<%#((DataRowView)Container.DataItem)["TaskIDP"] %>' />
                                        </td>
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

