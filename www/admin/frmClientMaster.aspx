<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.master" AutoEventWireup="true" CodeFile="frmClientMaster.aspx.cs" Inherits="admin_frmClientMaster" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .checkbox {
            padding-left: 20px;
        }

            .checkbox label {
                display: inline-block;
                vertical-align: middle;
                position: relative;
                padding-left: 10px;
            }

                .checkbox label::before {
                    content: "";
                    display: inline-block;
                    position: absolute;
                    width: 17px;
                    height: 17px;
                    left: 0;
                    margin-left: -20px;
                    border: 1px solid #cccccc;
                    border-radius: 3px;
                    background-color: #fff;
                    -webkit-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                    -o-transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                    transition: border 0.15s ease-in-out, color 0.15s ease-in-out;
                }

                .checkbox label::after {
                    display: inline-block;
                    position: absolute;
                    width: 16px;
                    height: 16px;
                    left: 0;
                    top: 0;
                    margin-left: -20px;
                    padding-left: 3px;
                    padding-top: 1px;
                    font-size: 11px;
                    color: #555555;
                }

            .checkbox input[type="checkbox"] {
                opacity: 0;
                z-index: 1;
            }

                .checkbox input[type="checkbox"]:checked + label::after {
                    font-family: "FontAwesome";
                    content: "\f00c";
                }

        .checkbox-primary input[type="checkbox"]:checked + label::before {
            background-color: #337ab7;
            border-color: #337ab7;
        }

        .checkbox-primary input[type="checkbox"]:checked + label::after {
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <asp:HiddenField runat="server" ID="hfID" />
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Manage Client</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Client Type</label>
                                <div class="col-lg-4">
                                    <asp:DropDownList ID="ddlClientType" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="1">Existing</asp:ListItem>
                                        <asp:ListItem Value="2">Prospect</asp:ListItem>
                                        <asp:ListItem Value="3">Hot Lead</asp:ListItem>
                                        <asp:ListItem Value="4">Closed</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Name</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbName" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Mobile No</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbMobileNo" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r3" ControlToValidate="tbMobileNo" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Email ID</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbEmailID" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r4" ControlToValidate="tbEmailID" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">WebSite Url</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbWebSiteUrl" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r5" ControlToValidate="tbWebSiteUrl" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Project List</label>
                                <div class="col-lg-9">
                                    <asp:CheckBoxList ID="chbProjectList" RepeatColumns="1" RepeatDirection="Vertical" CssClass="checkbox" DataTextField="ProjectName" DataValueField="ProjectID" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Address</label>
                                <div class="col-lg-4">
                                    <asp:TextBox runat="server" ID="tbAddress" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:Repeater runat="server" ID="rData" OnItemCommand="rData_ItemCommand" OnItemDataBound="rData_ItemDataBound">
                                <HeaderTemplate>
                                    <table id="datatable" class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Website URL</th>
                                                <th>Name</th>
                                                <th>Mobile No.</th>
                                                <th>Projects Name</th>
                                                <th>Address</th>
                                                <th>Operations</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%#((DataRowView)Container.DataItem)["WebsiteUrl"] %></td>
                                        <td><%#((DataRowView)Container.DataItem)["Name"] %></td>
                                        <td>
                                            <%#((DataRowView)Container.DataItem)["EmailID"] %><br />
                                            <%#((DataRowView)Container.DataItem)["Mobile"] %><br />
                                            <%#((DataRowView)Container.DataItem)["Password"] %>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProjectName" runat="server" /></td>
                                        <td><%#((DataRowView)Container.DataItem)["Address"] %></td>
                                        <td>
                                            <asp:Button runat="server" Text="Edit" ID="btEdit" CommandName="cE" CssClass="btn btn-primary" CommandArgument='<%#((DataRowView)Container.DataItem)["CustomerID"] %>' /><br />
                                            <%#((DataRowView)Container.DataItem)["IsActive"] %>
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

