<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyList.aspx.cs" Inherits="Zenga.Web.VerifyList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/UC/AdminLoginCheck.ascx" TagPrefix="uc1" TagName="AdminLoginCheck" %>

<uc1:AdminLoginCheck runat="server" ID="AdminLoginCheck" />
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                    <ul class="sidebar-menu">
                      <%--  <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ImportStore.aspx">上传Voucher数据</asp:HyperLink>
                        </li>
                        <li>                     
                            <asp:HyperLink ID="hlinkHexiao" runat="server" NavigateUrl="~/Verify.aspx">Voucher核销</asp:HyperLink>
                        </li>
                        <li>
                            <a href="VerifyList.aspx">
                                <!-- <i class="fa fa-gears"></i> -->
                                <span>Voucher核销列表</span>
                            </a>
                        </li>
                        <li>
                            <asp:HyperLink ID="hlkVip" runat="server" NavigateUrl="~/ImportVIP.aspx">上传VIP数据</asp:HyperLink>
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
                <section class="content-header">
                    <h1>核销列表
                        <!--         <small>通过设置...</small> -->
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>主页</a></li>
                        <li class="active">核销列表</li>
                    </ol>
                </section>

                <section class="content">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="box">
                                <div class="box-header">

                                    <div class="box-tools">

                                        <div class="row">

                                            <div class="col-xs-12">
                                                <asp:HiddenField ID="hidMemberCode" runat="server" />
                                                <asp:HiddenField ID="hidStoreCode" runat="server" />
                                          
                                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-success btn-sm pull-left" Text="导出Excel" OnClick="btnExport_Click" />
                                                <%--<a href="#" class="btn btn-success btn-sm pull-left" style="color:#fff;">导出Excel</a>--%>
                                                <div class="input-group pull-right" style="width: 210px; margin-left: 10px;">
                                                    <asp:TextBox ID="reservation" name="table_search" CssClass="form-control input-sm pull-right" runat="server" Style="width: 180px" placeholder="选择时间"></asp:TextBox>
                                                    <div class="input-group-btn">
                                                        <asp:Button ID="btnTimeSearch" CssClass="btn btn-sm btn-default" runat="server" Text="查询" OnClick="btnTimeSearch_Click" />
                                                        <%--<button class="btn btn-sm btn-default"><i class="fa fa-calendar"></i></button>--%>
                                                    </div>

                                                </div>
                                                <div class="input-group pull-right" style="width: 180px;">

                                                    <asp:TextBox ID="txtContent" name="table_search" CssClass="form-control input-sm pull-right" runat="server" Style="width: 142px" placeholder="检索内容"></asp:TextBox>
                                                    <div class="input-group-btn">
                                                        <%--<button class="btn btn-sm btn-default"></button>--%>
                                                        <asp:Button ID="btnContentSearch" CssClass="btn btn-sm btn-default" runat="server" Text="查询" OnClick="btnContentSearch_Click" />
                                                    </div>
                                                </div>
                                                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-control input-sm pull-right" Style="width: 120px;">
                                                    <asp:ListItem Value="0">姓名</asp:ListItem>
                                                    <asp:ListItem Value="1">手机号码</asp:ListItem>
                                                    <asp:ListItem Value="2">Voucher Code</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-header -->
                                <div class="box-body table-responsive">
                                    <asp:GridView ID="gvData" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnSelectedIndexChanged="gvData_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="MemberCode" HeaderText="顾客编号" />
                                            <asp:BoundField DataField="MemberName" HeaderText="姓名" />
                                            <asp:BoundField DataField="Mobile" HeaderText="VIP 手机号码" />
                                            <asp:BoundField DataField="CardCode" HeaderText="Voucher Code" />
                                            <asp:BoundField DataField="CardAmount" HeaderText="Voucher金额" />
                                             <%--<asp:BoundField DataField="City" HeaderText="城市" />--%> 
                                            <asp:BoundField DataField="CounterCode" HeaderText="柜台编号" />
                                            <asp:BoundField DataField="StoreType" HeaderText="店铺类型" />
                                            <asp:BoundField DataField="StoreNameEN" HeaderText="店铺名称" />
                                         <%--<asp:BoundField DataField="StorePhone" HeaderText="店铺电话" />
                                            <asp:BoundField DataField="StoreMasterPhone" HeaderText="经理电话" />
                                            <asp:TemplateField HeaderText="使用情况">     
                                                 <ItemTemplate> 
                                                     <asp:Label ID="LabelState" runat="server" Text='<%#Eval("Status").ToString()=="1"?"已使用":"未使用"%>'></asp:Label>
                                                 </ItemTemplate> 
                                            </asp:TemplateField> --%>
                                            <asp:BoundField DataField="Status" HeaderText="使用情况" /> 
                                            <asp:BoundField DataField="ConsumeAmount" HeaderText="消费金额" /> 
                                            <asp:BoundField DataField="CreateTime" HeaderText="使用时间" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" />
                                            <asp:BoundField DataField="Remark" HeaderText="备注" /> 
                                        </Columns> 
                                    </asp:GridView>
                                    <div id="page" style="width: 100%; text-align: center;">
                                        <webdiyer:AspNetPager ID="AspNetPager1" runat="server" UrlPaging="false" FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PrevPageText="上一页" PageSize="10" AlwaysShow="true" OnPageChanged="AspNetPager1_PageChanged">
                                        </webdiyer:AspNetPager>
                                    </div>
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
                            <div class="modal-dialog" style="width: 815px;">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal"
                                            aria-hidden="true">
                                            ×</button>
                                        <h4 class="modal-title" id="myModalLabel">Voucher核销信息确认
                                        </h4>
                                    </div>
                                    <div class="modal-body">

                                        <iframe class="verifyInfo" src="" style="width: 100%; border: none; height: 625px; background-color: #fff;"></iframe>
                                    </div>
                                    <div class="modal-footer no-print">


                                        <%--            <a href="#" class="btn btn-danger btn-sm">退单</a>--%>
                                        <asp:Button ID="btnCancel" CssClass="btn btn-danger btn-sm" runat="server" Text="退单" OnClick="btnCancel_Click" />
                                        <%--<a href="#" id="print" class="btn btn-primary btn-sm">打印
                                        </a>--%>
                                        <button type="button" id="print" class="btn btn-primary btn-sm" >打印</button>
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

                $(document).on('click', '#gvData tr', function () {
                    var code = $(this).children().eq(5).text();
                    var member = $(this).children().eq(3).text();
                    var state = $(this).children().eq(8).text();
                    $('#hidMemberCode').val(member);
                    $('#hidStoreCode').val(code);
                    if (state.trim() == '已使用') {
                        $('.verifyInfo').attr('src', 'VerifyInfo.aspx?Code=' + code + '&voncher=' + member);
                        // $('#myModal .modal-body').load('pages/voucher/verify_info.html?lid='+lid,function(){
                        $('#myModal').modal({ keyboard: true });
                        // });
                    }
                });

                $(document).on('click', '#print', function () {
                    var vipCardCode = $('#hidMemberCode').val();
                    window.location.href = '/VerifyPrint.aspx?code=' + vipCardCode;
                });

            });
            $(document).ready(function () {
                $("#loginUser1").text($.cookies.get("User"));
                $("#loginUser2").text($.cookies.get("User"));
            });

        </script>

    
</body>

</html>
