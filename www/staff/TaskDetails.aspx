<%@ Page Title="" Language="C#" MasterPageFile="~/staff/Staff.master" AutoEventWireup="true" CodeFile="TaskDetails.aspx.cs" Inherits="staff_TaskDetails" %>

<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Column1" runat="Server">
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h3 class="panel-title">Task Details</h3>
                </div>
                <div class="panel-body">
                    <div class=" form">
                        <div class="cmxform form-horizontal tasi-form" id="commentForm">
                            <asp:Repeater runat="server" ID="rData">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="form-group">
                                        <div class="col-lg-12">
                                            <h4><i class="ion-arrow-right-a"></i>&nbsp;Task Date</h4>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-12">
                                            <td><%#((DataRowView)Container.DataItem)["TaskDate"] %></td>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-group">
                                        <div class="col-lg-12">
                                            <h4><i class="ion-arrow-right-a"></i>&nbsp;Task Title</h4>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-12">
                                            <td><%#((DataRowView)Container.DataItem)["TaskTitle"] %></td>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-group">
                                        <div class="col-lg-12">
                                            <h4><i class="ion-arrow-right-a"></i>&nbsp;Task Description</h4>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-12">
                                            <td><%#((DataRowView)Container.DataItem)["TaskDesc"] %></td>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
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

