<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="staff_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Profile</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Name</label>
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" ID="tbName" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbName" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Mobile No</label>
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" ID="tbMobileNo" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbMobileNo" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Email ID</label>
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" ID="tbEmailID" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r3" ControlToValidate="tbEmailID" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Address</label>
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" ID="tbAddress" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Designation</label>
                                <div class="col-lg-6">
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlDesignation"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="cname" class="control-label col-lg-2">Password</label>
                                <div class="col-lg-6">
                                    <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r4" ControlToValidate="tbPassword" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
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
</asp:Content>

