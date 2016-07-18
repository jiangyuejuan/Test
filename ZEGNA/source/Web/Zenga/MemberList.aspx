<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberList.aspx.cs" Inherits="Zenga.Web.MemberList" %>




<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/UC/AdminLoginCheck.ascx" TagPrefix="uc1" TagName="AdminLoginCheck" %>

<style type="text/css">
    .auto-style1 {
        width: 58px;
    }
    .auto-style2 {
        width: 164px;
    }
    .auto-style3 {
        width: 31px;
    }
    .auto-style5 {
        width: 154px;
    }
    .auto-style6 {
        width: 67px;
    }
</style>

<uc1:AdminLoginCheck runat="server" ID="AdminLoginCheck" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <%--<meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
    <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/ionicons.min.css" rel="stylesheet" type="text/css" />

    <link href="css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css" rel="stylesheet" type="text/css" />
    <link href="css/admin.css" rel="stylesheet" type="text/css" />

    <link href="css/datatables/dataTables.bootstrap.css" rel="stylesheet" type="text/css" />

    <link href="css/daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />--%>
    <title></title>




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
        <!--[if lt IE 9]>
            <script src="js/html5shiv.js"></script>
            <script src="js/respond.min.js"></script>
        <![endif]-->

   <%-- <!-- jQuery 2.0.2 -->
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

    <script type="text/javascript">

        $(document).ready(function () {
            $("#loginUser1").text($.cookies.get("User"));
            $("#loginUser2").text($.cookies.get("User"));
        });

    </script>--%>

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
        </header>
        <div class="nav_info">
            <img src="img/logo_i.png" width="200px">
        </div>
        <div class="wrapper row-offcanvas row-offcanvas-left">

            <aside class="left-side sidebar-offcanvas">

                <section class="sidebar">

                    <ul class="sidebar-menu">
      <%--                  <li>
                            <asp:HyperLink ID="hlinkHexiao" runat="server" NavigateUrl="~/Verify.aspx">Voucher核销</asp:HyperLink>
                        </li>
                        <li>
                            <a href="VerifyList.aspx">
                                <!-- <i class="fa fa-gears"></i> -->
                                <span>Voucher核销列表</span>
                            </a>
                        </li>

                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ImportMemberInfo.aspx">上传数据</asp:HyperLink>
                        </li>--%>
                        <li>
                            <a href="ModifyPwd.aspx">
                                <!-- <i class="fa fa-gears"></i> -->
                                <span>修改密码</span>
                            </a>
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
                <section class="content-header">
                    <h1>会员信息列表</h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>主页</a></li>
                        <li class="active">会员信息列表</li>
                    </ol>
                </section>

                <section class="content">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="box">
                                <div class="box-header">

                                    <div class="box-tools">

                                        <div class="row">

                                        </div>

                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body table-responsive">
                                    <%--<table id="example2" class="table table-bordered table-hover">
                    <thead>
                         <tr>
                            <th>姓名</th>
                            <th>手机号码</th>
                            <th>Voucher Code</th>
                            <th>金额</th>
                            <th>状态</th>
                            <th>绑定用户</th>
                            <th>录入时间</th>
                            <th>登录时间</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr lid="451221512154125">
                            <td class="text-muted">181</td>
                            <td>林刘杰</td>
                            <td>jspsj1</td>
                            <td>下班话术</td>
                            <td>下班</td>
                            <td class="text-muted">已绑定</td>
                            <td class="text-muted">2015-05-24</td>
                            <td class="text-muted">2015-05-26</td>
                        </tr>
                        <tr lid="451221512154125">
                            <td class="text-muted">182</td>
                            <td>林刘杰</td>
                            <td>jspsj2</td>
                            <td>下班话术</td>
                            <td>下班</td>
                            <td class="text-muted">已绑定</td>
                            <td class="text-muted">2015-05-24</td>
                            <td class="text-muted">2015-05-26</td>
                        </tr>
                        <tr lid="451221512154125">
                            <td class="text-muted">183</td>
                            <td>林刘杰</td>
                            <td>jspsj3</td>
                            <td>下班话术</td>
                            <td>下班</td>
                            <td class="text-muted">已绑定</td>
                            <td class="text-muted">2015-05-24</td>
                            <td class="text-muted">2015-05-26</td>
                        </tr>
                    </tbody>
                    

                    
                </table>--%>

                                                    <table style="width:100%;">
                                                        <tr>
                                                            <td class="auto-style1">&nbsp;</td>
                                                            <td class="auto-style2">&nbsp;</td>
                                                            <td class="auto-style3">&nbsp;</td>
                                                            <td class="auto-style6">&nbsp;</td>
                                                            <td class="auto-style5">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">
                                                                <asp:Label ID="Label1" runat="server" Text="状态："></asp:Label>
                                                            </td>
                                                            <td class="auto-style2">
                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control input-sm pull-right"  OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">未确认</asp:ListItem>
                                                    <asp:ListItem Value="1">已确认</asp:ListItem>
                                                    <asp:ListItem Value="2">全部</asp:ListItem>
                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="auto-style3">
                                                                &nbsp;</td>
                                                            <td class="auto-style6">
                                                                <asp:Label ID="Label2" runat="server" Text="手机号："></asp:Label>
                                                            </td>
                                                            <td class="auto-style5">

                                                    <asp:TextBox ID="txtContent0" name="table_search" CssClass="form-control input-sm pull-left" runat="server" Style="width: 148px" placeholder="检索内容" MaxLength="11" OnTextChanged="txtContent0_TextChanged"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                        <asp:Button ID="btnContentSearch0" CssClass="btn btn-sm btn-default" runat="server" Text="查询" OnClick="btnContentSearch_Click" Width="65px" />
                                                            </td>
                                                            <td>
                                          
                                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-success btn-sm pull-left" Text="导出Excel" OnClick="btnExport_Click" Height="30px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style1">&nbsp;</td>
                                                            <td class="auto-style2">&nbsp;</td>
                                                            <td class="auto-style3">&nbsp;</td>
                                                            <td class="auto-style6">&nbsp;</td>
                                                            <td class="auto-style5">&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                    </table>
                                </div>

                                                      <div class="box-body table-responsive">
                                    <asp:GridView ID="gvData" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="False" OnRowCommand="gvData_RowCommand" >
                                        <Columns>
                                            <asp:BoundField DataField="UserID" HeaderText="会员号" />
                                            <asp:BoundField DataField="Name" HeaderText="姓名" />
                                            <asp:BoundField DataField="ConfirmName" HeaderText="确认姓名" />
                                            <asp:BoundField DataField="Mobile" HeaderText="手机号" />
                                            <asp:BoundField DataField="ConfirmMobile" HeaderText="确认手机号" />
                                             <%--<asp:BoundField DataField="City" HeaderText="城市" />--%> 
                                            <asp:BoundField DataField="ManageStore" HeaderText="管理店铺" />
                                            <asp:BoundField DataField="InUserStore" HeaderText="使用店铺" />
                                            <asp:BoundField DataField="Amount" HeaderText="尊享券金额" />
                                         <%--<asp:BoundField DataField="StorePhone" HeaderText="店铺电话" />
                                            <asp:BoundField DataField="StoreMasterPhone" HeaderText="经理电话" />
                                            <asp:TemplateField HeaderText="使用情况">     
                                                 <ItemTemplate> 
                                                     <asp:Label ID="LabelState" runat="server" Text='<%#Eval("Status").ToString()=="1"?"已使用":"未使用"%>'></asp:Label>
                                                 </ItemTemplate> 
                                            </asp:TemplateField> --%>
                                   <%--        <asp:TemplateField HeaderText="使用情况">     
                                                 <ItemTemplate> 
                                                     <asp:Label ID="LabelState" runat="server" Text='<%#Eval("Status").ToString()=="1"?"已确认":"未确认"%>'></asp:Label>
                                                 </ItemTemplate> 
                                            </asp:TemplateField> --%>
                                            <asp:BoundField DataField="Status" HeaderText="状态" />                                           
                                            <asp:BoundField DataField="Remark" HeaderText="备注" /> 
                                          
                                          <asp:TemplateField HeaderText="编辑">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="Button1" runat="server" CausesValidation="false"  CommandArgument='<%#Eval("UserID")%>' CommandName="修改" Text="修改" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                      <%--   <asp:LinkButton ID="LinkButton3" runat="server"  Text="确认提交"  OnClick="btnConfirm_Click" >LinkButton</asp:LinkButton>--%>
                                        <%--    <asp:HyperLinkField HeaderText="编辑" Text="修改"/>--%>
                                        <%--     <asp:ButtonField   HeaderText="确认操作" Text="确认提交"  OnClick="btnConfirm_Click" />--%>
                                            <asp:TemplateField HeaderText="确认操作">
                                                <ItemTemplate>
                                                  <%--  <asp:Button ID="Button2" runat="server" CausesValidation="false"  CommandArgument='<%#Eval("UserID")%>' CommandName="确认提交" Text="确认提交" />--%>
                                                      <asp:LinkButton ID="Button2" runat="server" CausesValidation="false"  CommandArgument='<%#Eval("UserID")%>' CommandName="确认提交" Text="确认提交" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                   

                                        </Columns> 
                                    </asp:GridView>
                                           
                                    <div id="Div1" style="width: 100%; text-align: center;">
                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" UrlPaging="false" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" PageSize="10" AlwaysShow="true" OnPageChanged="AspNetPager1_PageChanged">
                                        </webdiyer:AspNetPager>
                                    </div>
                                </div>
                                          <div id="page" style="width: 100%; text-align: center;">
                                    </div>
                                <!-- /.box-body -->
                                <!--             <div class="box-footer clearfix">
                <ul class="pagination pagination-sm no-margin pull-left">
                    <li><a href="#">«</a></li>
                    <li><a href="#">1</a></li>
                    <li><a href="#">2</a></li>
                    <li><a href="#">3</a></li>
                    <li><a href="#">»</a></li>
                </ul>
            </div> -->
                            </div>
                            <!-- /.box -->
                        </div>
                        <!-- /.row -->


                        <!-- 模态框（Modal） -->
                        <div class="modal fade" id="myModal" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog"  style="width: 815px;">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal"
                                            aria-hidden="true">
                                            ×</button>
                                        <h4 class="modal-title" id="myModalLabel">会员信息修改
                                        </h4>
                                    </div>
                                    <div class="modal-body">
                                         <iframe class="verifyInfo" src="" style="width: 100%; border: none; height: 400px; background-color: #fff;"></iframe>
                                    </div>
                                    <div class="modal-footer no-print">
                                    <%--    <button class="btn btn-danger btn-sm">退单</button>
                                        <a href="#" class="btn btn-primary btn-sm">打印
                                        </a>--%>
                                        <button type="button" class="btn btn-default btn-sm" data-dismiss="modal">关闭</button>
                                    </div>
                                </div>
                                <!-- /.modal-content -->
                            </div>
                            <!-- /.modal-dialog -->
                        </div>
                        <!-- /.modal -->
                </section>
                <!-- /.content -->
            </aside>
            <!-- /.right-side -->
        </div>
        <!-- ./wrapper -->

        <!-- add new calendar event modal -->


    </form>
	        <!-- add new calendar event modal -->


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
        <script type="text/javascript">
            $(function () {
                new Load_tpls($('.addList,.editList'), $('.pageContent'));

                $('#reservation').daterangepicker();

                //$('#gvData').dataTable({
                //    "bPaginate": true,
                //    "bLengthChange": false,
                //    "bFilter": false,
                //    "bSort": true,
                //    "bInfo": true,
                //    "bAutoWidth": false
                //});

                //$('#gvData td:not(:last-child)').click(function () {
                //    var code = $(this).parent().find('td:eq(0)').text();
                //   // alert(code);
                //    if (code == '') return;
                //    $('.verifyInfo').attr('src', 'MemberInfo.aspx?Code=' + code);
                //    $('#myModal').modal({ keyboard: true });
                //    //var member = $(this).children().eq(3).text();
                //    //var state = $(this).children().eq(8).text();
                //    //$('#hidMemberCode').val(member);
                //    //$('#hidStoreCode').val(code);
                //    //if (state.trim() == '已使用') {
                //    //    $('.verifyInfo').attr('src', 'MemberInfo.aspx?Code=' + code);//+ '&voncher=' + member);
                //    //    // $('#myModal .modal-body').load('pages/voucher/verify_info.html?lid='+lid,function(){
                //    //    $('#myModal').modal({ keyboard: true });
                //    //    // });
                //    //}
                //});
                

                //$(document).on('click', '#print', function () {
                //    var vipCardCode = $('#hidMemberCode').val();
                //    window.location.href = '/VerifyPrint.aspx?code=' + vipCardCode;
                //});

            });
            $(document).ready(function () {
                $("#loginUser1").text($.cookies.get("User"));
                $("#loginUser2").text($.cookies.get("User"));
            });

        </script>
</body>

</html>



