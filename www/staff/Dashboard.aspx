<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="staff_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <div class="row">
        <div class="col-sm-6" runat="server" id="fcIN">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Clock In</h3>
                </div>
                <div class="panel-body">
                    <div class="form">
                        <div class="cmxform form-horizontal tasi-form">
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Clock In</label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="tbRemarksIn" CssClass="form-control" placeholder="Remarks" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbRemarksIn" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2"></label>
                                <div class="col-lg-10">
                                    <asp:Button runat="server" ID="btClockIn" OnClick="btClockIn_Click" CssClass="btn btn-primary" Text="Clock In" ValidationGroup="vgA" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-sm-6" runat="server" id="fcOUT" visible="false">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Clock Out</h3>
                </div>
                <div class="panel-body">
                    <div class="form">
                        <div class="cmxform form-horizontal tasi-form">
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2">Clock Out</label>
                                <div class="col-lg-10">
                                    <asp:TextBox runat="server" ID="tbRemarksOut" CssClass="form-control" placeholder="Remarks" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbRemarksOut" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgOut"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group ">
                                <label for="cname" class="control-label col-lg-2"></label>
                                <div class="col-lg-10">
                                    <asp:Button runat="server" ID="btClockOut" OnClick="btClockOut_Click" CssClass="btn btn-primary" Text="Clock Out" ValidationGroup="vgOut" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6 col-sm-6 col-lg-3">
            <div class="mini-stat clearfix bx-shadow">
                <span class="mini-stat-icon bg-info"><i class="ion-ios7-time-outline"></i></span>
                <div class="mini-stat-info text-right text-muted">
                    <asp:Label runat="server" ID="lTotalTime"></asp:Label>
                    Total Time
                                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>
