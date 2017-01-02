﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="staff_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="A fully featured admin theme which can be used to build CRM, CMS, etc.">
    <meta name="author" content="Coderthemes">
    <link rel="shortcut icon" href="images/favicon_1.ico">
    <title>Staff Login</title>
    <!-- Base Css Files -->
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Font Icons -->
    <link href="/assets/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="/assets/ionicon/css/ionicons.min.css" rel="stylesheet" />
    <link href="/css/material-design-iconic-font.min.css" rel="stylesheet">
    <!-- animate css -->
    <link href="/css/animate.css" rel="stylesheet" />
    <!-- Waves-effect -->
    <link href="/css/waves-effect.css" rel="stylesheet">
    <!-- Custom Files -->
    <link href="/css/helper.css" rel="stylesheet" type="text/css" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
    <![endif]-->
    <script src="/js/modernizr.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper-page">
            <div class="panel panel-color panel-primary panel-pages">
                <div class="panel-heading bg-img">
                    <div class="bg-overlay"></div>
                    <h3 class="text-center m-t-10 text-white">Sign In to <strong>Staff Panel</strong> </h3>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal m-t-20">
                        <div class="form-group ">
                            <div class="col-xs-12">
                                <asp:TextBox runat="server" ID="tbUserName" CssClass="form-control input-lg" placeholder="Username"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="r1" ControlToValidate="tbUserName" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-xs-12">
                                <asp:TextBox runat="server" ID="tbPassword" CssClass="form-control input-lg" placeholder="Password" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="r2" ControlToValidate="tbPassword" Display="Dynamic" SetFocusOnError="true" ForeColor="Red" ValidationGroup="vgA"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group text-center m-t-40">
                            <div class="col-xs-12">
                                <asp:Button runat="server" ID="btLogin" CssClass="btn btn-primary btn-lg" Text="Log In" OnClick="btLogin_Click" ValidationGroup="vgA" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script>
        var resizefunc = [];
    </script>
    <script src="/js/jquery.min.js"></script>
    <script src="/js/bootstrap.min.js"></script>
    <script src="/js/waves.js"></script>
    <script src="/js/wow.min.js"></script>
    <script src="/js/jquery.nicescroll.js" type="text/javascript"></script>
    <script src="/js/jquery.scrollTo.min.js"></script>
    <script src="/assets/jquery-detectmobile/detect.js"></script>
    <script src="/assets/fastclick/fastclick.js"></script>
    <script src="/assets/jquery-slimscroll/jquery.slimscroll.js"></script>
    <script src="/assets/jquery-blockui/jquery.blockUI.js"></script>
    <!-- CUSTOM JS -->
    <script src="/js/jquery.app.js"></script>
</body>
</html>
