<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="DesignationMaster.aspx.cs" Inherits="admin_DesignationMaster" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <asp:HiddenField runat="server" ID="hfID" />
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Designation</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Designation Name</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbDesignationName" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbDesignationName" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2"></label>
                                <div class="col-lg-10">
                                    <asp:CheckBox runat="server" ID="cbIsActive" Text="" />&nbsp;&nbsp;Active
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2"></label>
                                <div class="col-lg-10">
                                    <asp:Button runat="server" ID="btSave" CssClass="btn btn-primary" Text="Save" OnClick="btSave_Click" ValidationGroup="vgA" />
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
                                                <th>Designation Name</th>
                                                <th>Active</th>
                                                <th>Operations</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%#((DataRowView)Container.DataItem)["DesignationName"] %>
                                        </td>
                                        <td>
                                            <%#((DataRowView)Container.DataItem)["IsActive"] %>
                                        </td>
                                        <td>
                                            <asp:Button runat="server" Text="Edit" ID="btEdit" CssClass="btn btn-primary" CommandName="cE" CommandArgument='<%#((DataRowView)Container.DataItem)["DesignationIDP"] %>' />
                                            <asp:Button runat="server" Text="Delete" ID="btDelete" CssClass="btn btn-danger" CommandName="cD" CommandArgument='<%#((DataRowView)Container.DataItem)["DesignationIDP"] %>' OnClientClick="return confirm('Do You Really Want To Delete This Record?');" />
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
    <fieldset>
        <legend></legend>
        <table class="nostyle" align="center">
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </fieldset>
    <br />

</asp:Content>

