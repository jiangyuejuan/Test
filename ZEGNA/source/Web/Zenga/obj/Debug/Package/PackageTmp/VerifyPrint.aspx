<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyPrint.aspx.cs" Inherits="Zenga.Web.VerifyPrint" %>

<%@ Register Src="~/UC/AdminLoginCheck.ascx" TagPrefix="uc1" TagName="AdminLoginCheck" %>

<uc1:AdminLoginCheck runat="server" ID="AdminLoginCheck" />
<!DOCTYPE html>
<html>
<head>
    <meta charset="UTF-8">
    <title>admin</title>
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- bootstrap 3.0.2 -->
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- font Awesome -->
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Ionicons -->
    <link href="css/ionicons.min.css" rel="stylesheet" type="text/css" />

    <!-- bootstrap wysihtml5 - text editor -->
    <link href="css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" type="text/css" />
    <!-- Theme style -->
    <link href="css/admin.css" rel="stylesheet" type="text/css" />

    <!-- DATA TABLES -->
    <link href="css/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />

    <!-- daterange picker -->
    <link href="css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <script src="js/jquery.min.js"></script>
    <!-- jQuery UI 1.10.3 -->
    <script src="js/jquery-ui-1.10.3.min.js" type="text/javascript"></script>
    <!-- Bootstrap -->
    <script src="js/bootstrap.min.js" type="text/javascript"></script>

    <!-- Bootstrap WYSIHTML5 -->
    <script src="js/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js" type="text/javascript"></script>
    <!-- iCheck -->
    <script src="js/plugins/iCheck/icheck.min.js" type="text/javascript"></script>

    <!-- AdminLTE App -->
    <!--<script src="js/AdminLTE/app.js" type="text/javascript"></script>-->

    <!-- InputMask -->
    <script src="js/plugins/input-mask/jquery.inputmask.js" type="text/javascript"></script>
    <script src="js/plugins/input-mask/jquery.inputmask.date.extensions.js" type="text/javascript"></script>
    <script src="js/plugins/input-mask/jquery.inputmask.extensions.js" type="text/javascript"></script>

    <!-- DATA TABES SCRIPT -->
    <script src="js/plugins/datatables/jquery.dataTables.js" type="text/javascript"></script>
    <script src="js/plugins/datatables/dataTables.bootstrap.js" type="text/javascript"></script>

    <!-- date-range-picker -->
    <script src="js/plugins/daterangepicker/daterangepicker.js" type="text/javascript"></script>

    <!-- AdminLTE base -->
    <script src="js/Admin/base.js" type="text/javascript"></script>

    <script src="Content/jquery.cookies.2.2.0.min.js"></script>

    <!--[if lt IE 9]>
            <script src="js/html5shiv.js"></script>
            <script src="js/respond.min.js"></script>
        <![endif]-->
    <script>
        $(document).ready(function () {
            $("#loginUser1").text($.cookies.get("User"));
            $("#loginUser2").text($.cookies.get("User"));
        });

        function result() {
            $('title').html('Voucher核销');

            $.ajax({
                type: "POST",
                url: "/Handler/Result.ashx",
                data: { "code": $("#lblVoucherCode").text(), "VipName": $("#lblVipName").text(), "ConsumeAmount": $("#lblConsumeAmount").text(), "ShopName": $("#lblShopName").text(), "mobile": $("#lblVipMobile").text(), "date": $("#lblVerifyTime").text(), "CounterCode": $("#lblCounterCode").text() },
                dataType: "text",
                success: function (msg) {
                    //alert('');
                    //alert(msg);
                }
            });
            //alert("3");
            window.print();
            return false;
        }
    </script>
</head>

<body class="skin-ecsr">
    <form id="form1" runat="server">
        <!-- header logo: style can be found in header.less -->
        <header class="header">
            <div class="logo">
                VIP Voucher 门店核查系统 v1.0
            </div>

            <nav class="navbar navbar-static-top" role="navigation">
                <!-- Sidebar toggle button-->
                <a href="#" class="navbar-btn sidebar-toggle" data-toggle="offcanvas" role="button">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </a>
                <div class="navbar-right">
                    <ul class="nav navbar-nav">

                        <li class="dropdown user user-menu">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <i class="glyphicon glyphicon-user"></i>
                                <span>
                                    <label id="loginUser1"></label>
                                    <i class="caret"></i></span>
                            </a>
                            <ul class="dropdown-menu">
                                <!-- User image -->
                                <li class="user-header bg-light-blue">
                                    <img src="img/avatar.gif" class="img-circle" alt="User Image" />
                                    <p id="loginUser2"></p>
                                </li>
                                <!-- Menu Footer-->
                                <li class="user-footer">
                                    <div class="pull-right">
                                        <asp:LinkButton ID="lbtnLogout" CssClass="btn btn-default btn-flat" OnClick="lbtnLogout_Click" runat="server">登 出</asp:LinkButton>
                                    </div>
                                </li>
                            </ul>

                        </li>
                    </ul>
                </div>
            </nav>
        </header>
        <div class="nav_info">
            <img src="img/logo_i.png" width="200px">
        </div>
        <div class="wrapper row-offcanvas row-offcanvas-left">

            <aside class="left-side sidebar-offcanvas">

                <section class="sidebar">

                    <ul class="sidebar-menu">
                     <%--   <li>
                            <asp:HyperLink ID="hlinkHexiao" runat="server" NavigateUrl="~/Verify.aspx">Voucher核销</asp:HyperLink>
                        </li>
                        <li>
                            <a href="VerifyList.aspx">
                                <!-- <i class="fa fa-gears"></i> -->
                                <span>Voucher核销列表</span>
                            </a>
                        </li>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ImportStore.aspx">上传数据</asp:HyperLink>
                        </li>--%>
                        <li>
                            <a href="ModifyPwd.aspx">
                                <!-- <i class="fa fa-gears"></i> -->
                                <span>修改密码</span>
                            </a>
                        </li>
                               </li>
                                      <li>
                            <a href="MemberList.aspx">
                                <!-- <i class="fa fa-gears"></i> -->
                                <span>会员信息列表</span>
                            </a>
                        </li>
                        <%-- <li>
                            <a href="verify_print.html">
                                <!-- <i class="fa fa-gears"></i> --> <span>打印预览</span>
                            </a>
                        </li>--%>
                    </ul>
                </section>
                <!-- /.sidebar -->
            </aside>

            <!-- Right side column. Contains the navbar and content of the page -->
            <aside class="right-side pageContent">
                <section class="content">

                    <div class="row">

                        <div class="col-xs-12">
                            <h2 class="page-header">Voucher核销
                            </h2>
                        </div>
                        <!-- /.col -->

                        <div class="col-xs-12">
                            <div class="box box-solid">
                                <div class="box-header">
                                    <h3 class="box-title">门店信息</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body">
                                    <!--                 <dl class="dl-horizontal">
                    <dt>柜台编号:</dt>
                    <dd>SHZZ</dd>
                    <dt>店铺名称:</dt>
                    <dd>上海虹桥友谊商城ZZegna店</dd>
                </dl> -->
                                    <table class="table table_no_border">
                                        <tbody>
                                            <tr>
                                                <th style="width: 90px;">柜台编号:</th>
                                                <td>
                                                    <asp:Label ID="lblCounterCode" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>店铺名称:</th>
                                                <td>
                                                    <asp:Label ID="lblShopName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <!-- /.box-body -->
                            </div>
                        </div>

                        <div class="col-xs-12">
                            <div class="box box-solid">
                                <div class="box-header">
                                    <h3 class="box-title">Voucher Code 信息</h3>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body Voucher_dl">
                                    <table class="table table_no_border">
                                        <tbody>
                                            <tr>
                                                <th style="width: 90px;">Code:</th>
                                                <td>
                                                    <asp:Label ID="lblVoucherCode" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>Code 面值:</th>
                                                <td>¥
                                    <asp:Label ID="lblVoucherFaceAmount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 90px;">核销时间:</th>
                                                <td>
                                                    <asp:Label ID="lblVerifyTime" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>顾客编号:</th>
                                                <td>
                                                    <asp:Label ID="lblCustomerCode" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>VIP 姓名:</th>
                                                <td>
                                                    <asp:Label ID="lblVipName" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th style="width: 90px;">手机号码:</th>
                                                <td>
                                                    <asp:Label ID="lblVipMobile" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>消费金额:</th>
                                                <td>¥
                                    <asp:Label ID="lblConsumeAmount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <th>备注:</th>
                                                <td>
                                                    <asp:Label ID="lblRemark" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                </div>
                                <!-- /.box-body -->
                            </div>
                        </div>
                        <div class="col-xs-12 Signature">
                            <div style="text-align: right;">
                                <h4 style="display: inline-block;">客户签名</h4>
                                <div style="width: 120px; border-bottom: 1px solid #ccc; height: 30px; display: inline-block; margin-left: 10px;"></div>
                            </div>
                        </div>

                        <div class="col-xs-12 no-print" style="text-align: center;">
                            <button type="button" class="btn btn-default" onclick="return result();"><i class="fa fa-print"></i>打印</button>
                        </div>

                    </div>
        </div>
        </aside><!-- /.right-side -->
        </div><!-- ./wrapper -->

        <!-- add new calendar event modal -->


        <!-- jQuery 2.0.2 -->

    </form>

</body>
</html>



