<%@ Page Title="" Language="C#" MasterPageFile="~/Customer/CustomerMaster.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Customer_Home" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <asp:HiddenField runat="server" ID="hfID" />
    <asp:HiddenField runat="server" ID="hfGUID" />
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Add Task</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Ticket No</label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="tbTicketNo" ReadOnly="true" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Task Title *</label>
                                <div class="col-lg-10">
                                    <asp:DropDownList ID="ddlTitle" DataTextField="Title" DataValueField="TitleIDP" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="ddlTitle" InitialValue="-1" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Task Discription *</label>
                                <div class="col-lg-10">
                                    <FCKeditorV2:FCKeditor runat="server" ID="FCKeditor"></FCKeditorV2:FCKeditor>

                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-offset-2 col-lg-10">
                                    <asp:Button runat="server" ID="btAddTask" OnClick="btAddTask_Click" CssClass="btn btn-primary" Text="Save" ValidationGroup="vgA" />
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
                                                <th>Ticket No</th>
                                                <th>Task Title</th>
                                                <th>Task Status</th>
                                                <th>Task Date</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#((DataRowView)Container.DataItem)["TicketNo"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["TaskTitle"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["TaskStatus"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["TaskGivenDate"] %></td>
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

