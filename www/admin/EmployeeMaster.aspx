<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="EmployeeMaster.aspx.cs" Inherits="admin_EmployeeMaster" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <asp:HiddenField runat="server" ID="hfID" />
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Employee</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Name</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbName" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Mobile No</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbMobileNo" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbMobileNo" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Email ID</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbEmailID" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r3" ControlToValidate="tbEmailID" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Address</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbAddress" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Designation</label>
                                <div class="col-lg-4">
                                    <asp:DropDownList runat="server" ID="ddlDesignation" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2"></label>
                                <div class="col-lg-4">
                                    <asp:CheckBox runat="server" ID="cbIsActive" Text="" />&nbsp;&nbsp;Active
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2"></label>
                                <div class="col-lg-4">
                                    <asp:Button runat="server" ID="btSave" CssClass="btn btn-primary" OnClick="btSave_Click" Text="Save" ValidationGroup="vgA" />
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
                                                <th>Name</th>
                                                <th>Mobile No.</th>
                                                <th>Email ID</th>
                                                <th>Designation</th>
                                                <th>Active</th>
                                                <th>Operations</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#((DataRowView)Container.DataItem)["Name"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["Mobile"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["EmailID"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["DesignationName"] %></td>
                                        <td>
                                            <%#((DataRowView)Container.DataItem)["IsActive"] %>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" Text="Edit" ID="btEdit" CommandName="cE" CssClass="btn btn-primary" CommandArgument='<%#((DataRowView)Container.DataItem)["EMPIDP"] %>' />
                                            <asp:Button runat="server" Text="Delete" ID="btDelete" CommandName="cD" CssClass="btn btn-danger" CommandArgument='<%#((DataRowView)Container.DataItem)["EMPIDP"] %>' OnClientClick="return confirm('Do You Really Want To Delete This Record?');" />
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

