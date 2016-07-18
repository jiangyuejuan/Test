<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyPwd.aspx.cs" Inherits="Zenga.Web.ModifyPwd" %>

<%@ Register Src="~/UC/AdminLoginCheck.ascx" TagPrefix="uc1" TagName="AdminLoginCheck" %>

<uc1:AdminLoginCheck runat="server" ID="AdminLoginCheck" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
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
    <!--[if lt IE 9]>
            <script src="js/html5shiv.js"></script>
            <script src="js/respond.min.js"></script>
        <![endif]-->

    <!-- jQuery 2.0.2 -->
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
    <title></title>

    <%--    <script type="text/javascript">
        function removeli() {
            var ul = document.querySelector("#rightMenu");
            var lis = ul.querySelectorAll("li");
            lis[2].remove();
        }
    </script>--%>
    <script>
        $(document).ready(function () {
            $("#loginUser1").text($.cookies.get("User"));
            $("#loginUser2").text($.cookies.get("User"));
        });
    </script>
</head>
<body class="skin-ecsr">
    <form id="form1" runat="server">
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

                    <ul class="sidebar-menu" id="rightMenu">
                      <%--  <li>
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
                            <h2 class="page-header">密码修改
                            </h2>
                        </div>
                        <!-- /.col -->

                        <div class="col-xs-12">
                            <div class="box box-solid">


                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-4">

                                            <div class="input-group">
                                                <span class="input-group-addon" style="width: 110px; text-align: left;">旧密码</span>
                                                <asp:TextBox ID="txtOldPwd" CssClass="form-control" runat="server" TextMode="Password" placeholder="输入旧密码"></asp:TextBox>

                                            </div>

                                        </div>
                                    </div>
                                    <br>
                                    <div class="row">
                                        <div class="col-md-4">

                                            <div class="input-group">
                                                <span class="input-group-addon" style="width: 110px; text-align: left;">新密码</span>
                                                <asp:TextBox ID="txtNewPwd" CssClass="form-control" runat="server" placeholder="输入新密码" TextMode="Password"></asp:TextBox>

                                            </div>

                                        </div>
                                    </div>
                                    <br>
                                    <div class="row">
                                        <div class="col-md-4">

                                            <div class="input-group">
                                                <span class="input-group-addon" style="width: 110px; text-align: left;">密码确认</span>
                                                <asp:TextBox ID="txtComfirmPwd" CssClass="form-control" runat="server" placeholder="再次输入新密码" TextMode="Password"></asp:TextBox>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->

                                <div class="box-footer">
                                    <!-- <button type="submit" class="btn btn-default" >确定提交</button> -->
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-default" Text="确认修改" OnClick="btnSubmit_Click" />
                                </div>

                            </div>
                        </div>

                    </div>
        </div>
        </aside><!-- /.right-side -->
        </div><!-- ./wrapper -->

        <!-- add new calendar event modal -->



    </form>
</body>
</html>
