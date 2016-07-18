<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberInfoNew.aspx.cs" Inherits="Zenga.Web.MemberInfoNew" %>


<%@ Register Src="~/UC/AdminLoginCheck.ascx" TagPrefix="uc1" TagName="AdminLoginCheck" %>

<style type="text/css">
    .auto-style1 {
        height: 22px;
    }
    .auto-style2 {
        width: 47px;
    }
    .auto-style3 {
        height: 22px;
        width: 47px;
    }
    .auto-style4 {
        width: 47px;
        height: 32px;
    }
    .auto-style5 {
        height: 32px;
    }
</style>

<uc1:AdminLoginCheck runat="server" ID="AdminLoginCheck" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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

    <style>
        .red {color:red;}
        .Voucher_dl_info .input-group-addon {
            width: 200px;
        }
        .input-group .form-control{
            width:200px;
        }
        #btnSave {
            display:none;
        }

    </style>
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
             
            <nav class="navbar navbar-static-top" role="navigation">
                <!-- Sidebar toggle button-->
                <a href="#" class="navbar-btn sidebar-toggle" data-toggle="offcanvas" role="button">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                </a>
                <div class="navbar-right">
                    <ul class="nav navbar-nav">

                        <li class="dropdown user user-menu">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                <i class="glyphicon glyphicon-user"></i>
                                <span><label id="loginUser1"></label> <i class="caret"></i></span>
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
                            <h2 class="page-header">用户信息</h2>
                        </div>
                        <!-- /.col -->

                        <div class="col-xs-12">
                            <div class="box box-solid">
                           

                                    
                                                    <div class="box-tools" style="text-align:right;padding:10px 10px 0px 0px;">
                                                          <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click"  Height="29px" Width="102px" />
                            <button class="btn btn-success btn-sm edit_info" >修改信息</button>
                             <%--    <button class="btn btn-success btn-sm edit_info">确认提交</button>--%>
                                 <%--<asp:Button ID="btnConfirm" runat="server" CssClass="btn btn-success" style="   font-size: 12px;" OnClick="btnConfirm_Click" Text="确认提交" Height="29px" Width="82px"  />--%>
                         <%--   <button   style=" background-color: #00a65a;  border-color: white;" CssClass="btn btn-success btn-sm edit_info" class="btn btn-success btn-sm edit_info">确认提交</button>--%>
                        </div>
                             <div class="box-body Voucher_dl">
                                <table style="width:100%;">
                                    <tr>
                                        <td class="auto-style4"></td>
                                        <td class="auto-style5" width="200">会员号:</td>
                                        <td class="auto-style5">  <asp:Label ID="lblMemberCode" runat="server"></asp:Label></td>
                                        <td class="auto-style5">
                                                    &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style1">姓名:</td>
                                        <td class="auto-style1"><asp:Label ID="lblName" runat="server"></asp:Label></td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>确认姓名:</td>
                                        <td><asp:Label ID="lblConfirmName" runat="server"></asp:Label></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>手机号:</td>
                                        <td><asp:Label ID="lblMobile" runat="server"></asp:Label></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>确认手机号:</td>
                                        <td><asp:Label ID="lblConfirmMobile" runat="server"></asp:Label></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>管理店铺:</td>
                                        <td><asp:Label ID="lblManageStore" runat="server"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3"></td>
                                        <td class="auto-style1">使用店铺:</td>
                                        <td class="auto-style1"><asp:Label ID="lblInuseStore" runat="server"></asp:Label></td>
                                        <td class="auto-style1"></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>尊享券金额:</td>
                                        <td><asp:Label ID="lblAmount" runat="server"></asp:Label></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>备注:</td>
                                        <td><asp:Label ID="lblRemark" runat="server"></asp:Label></td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style2">&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                  </table>  
                             </div>
                        <div class="box-body Voucher_dl_info" style="display: none;">
                        <div class="input-group">
                            <span class="input-group-addon" >会员号</span>
                            <asp:TextBox ID="txtMemberCode" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">姓名</span>
                            <asp:TextBox ID="txtName" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon  red">确认姓名</span>
                            <asp:TextBox ID="txtConfirmName"  runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">手机号</span>
                            <asp:TextBox ID="txtMobile" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon  red">确认手机号</span>
                            <asp:TextBox ID="txtConfirmMobile" MaxLength=11 runat="server" CssClass="form-control" style="display:inline-block;"></asp:TextBox>
                              <div style="display:inline-block;color:red;">
                         <asp:RangeValidator ID="RangeValidator1" runat="server" 
            ErrorMessage="请输入11位手机号！" ControlToValidate="txtConfirmMobile" MaximumValue="99999999999" 
            MinimumValue="10000000000" Type="Double"></asp:RangeValidator>
                                  </div>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">管理店铺</span>
                            <%--<input type="" class="form-control" data-inputmask="&quot;mask&quot;: &quot;99999999999&quot;" data-mask="" name="abc4" value="1370283393922">--%>
                            <asp:TextBox ID="txtManageStore" ReadOnly="true" runat="server" CssClass="form-control" class ="red"></asp:TextBox>
                        </div>
                                 <div class="input-group">
                            <span class="input-group-addon  red">使用店铺</span>
                                     <%--<input type="" class="form-control" data-inputmask="&quot;mask&quot;: &quot;99999999999&quot;" data-mask="" name="abc4" value="1370283393922">--%>
                           <%-- <asp:TextBox ID="txtInuseStore" runat="server" CssClass="form-control">--%><asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control input-sm pull-left" Height="26px"  Width="356px" >
                                                 
                                                </asp:DropDownList></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">尊享券金额</span>
                <%--            <asp:DropDownList ID="drpAmount" runat="server" CssClass="form-control input-sm pull-left" Height="26px" Width="166px"  >
                                                    <asp:ListItem Value="1500">1500</asp:ListItem>
                                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                                    <asp:ListItem Value="3000">3000</asp:ListItem>
                                                    <asp:ListItem Value="3000">5000</asp:ListItem>
                                                </asp:DropDownList></dd>--%>
                            <asp:TextBox ID="txtAmount"  ReadOnly="true" runat="server" CssClass="form-control "></asp:TextBox>

                        </div>
                <%--            <div class="input-group">
                            <span class="input-group-addon">状态</span>
                            <asp:TextBox ID="txtStatus"  ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>--%>
                        <div class="input-group">
                            <span class="input-group-addon  red">备注</span>
                            <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                                

           

                            </div>
                            
                        </div>


                    </div>

            
        </div>
        </aside><!-- /.right-side -->
        </div><!-- ./wrapper -->

        <!-- add new calendar event modal -->



    </form>

     


    <script type="text/javascript">
        $(function () {
            $("#btnSave").css('display', 'none');
            $('.edit_info').on('click', function () {
                var text = $(this).text();
                if (text == '修改信息') {
                    $('.Voucher_dl').hide();
                    $('.Voucher_dl_info').show();
                    $(this).text('确认修改');
                } else {
                    if ($('#txtConfirmMobile').val().length > 0 && $('#txtConfirmMobile').val().length != 11)
                        return false;

                    $('#btnSave').click();

                    $('.Voucher_dl_info').hide();
                    $('.Voucher_dl').show();
                    $(this).text('修改信息');
                }
                return false;
            });
        });
    </script>
</body>
</html>
