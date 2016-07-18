<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifyInfo.aspx.cs" Inherits="Zenga.Web.VerifyInfo" %>

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
    <title></title>
</head>
<body class="skin-ecsr" style="padding: 10px; background-color: #fff;">

    <form id="form1" runat="server">
        <div class="row">

            <div class="col-sm-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">门店信息</h3>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <dl class="dl-horizontal">
                            <dt>柜台编号:</dt>
                            <dd>
                                <asp:Label ID="lblStoreCode" runat="server"></asp:Label></dd>
                            <dt>店铺名称:</dt>
                            <dd>
                                <asp:Label ID="lblStoreName" runat="server"></asp:Label></dd>
                        </dl>
                    </div>
                    <!-- /.box-body -->
                </div>
            </div>

            <div class="col-sm-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">Voucher信息</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-success btn-sm edit_info">修改信息</button>
                            <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" />
                        </div>
                    </div>
                    <!-- /.box-header -->

                    <div class="box-body Voucher_dl">
                        <dl class="dl-horizontal">
                            <dt>会员号:</dt>
                            <dd>
                                <asp:Label ID="lblCardCode" runat="server"></asp:Label></dd>
                            <dt>姓名:</dt>
                            <dd>
                                <asp:Label ID="lblCardAmount" runat="server"></asp:Label></dd>
                            <dt>确认姓名:</dt>
                            <dd>
                                <asp:Label ID="lblConsumeTime" runat="server"></asp:Label></dd>
                            <dt>手机号:</dt>
                            <dd>
                 <%--               <asp:Label ID="lblMemberCode" runat="server"></asp:Label></dd>
                            <dt>手机号:</dt>
                            <dd>--%>
                                <asp:Label ID="lblName" runat="server"></asp:Label></dd>
                            <dt>确认手机号:</dt>
                            <dd>
                                <asp:Label ID="lblMobile" runat="server"></asp:Label></dd>
                            <dt>管理店铺:</dt>
                            <dd>
                                <asp:Label ID="lblConsumeMoney" runat="server"></asp:Label></dd>
                                <dt>使用店铺:</dt>
                            <dd>
                                <asp:Label ID="Label1" runat="server"></asp:Label></dd>
                                  <dt>尊享券金额:</dt>
                            <dd>
                                <asp:Label ID="Label2" runat="server"></asp:Label></dd>
                                                   <dt>状态:</dt>
                            <dd>
                                <asp:Label ID="Label3" runat="server"></asp:Label></dd>
                            <dt>备注:</dt>
                            <dd>
                                <asp:Label ID="lblRemark" runat="server"></asp:Label></dd>
                        </dl>
                    </div>
                    <!-- /.box-body -->

                    <div class="box-body Voucher_dl_info" style="display: none;">
                        <div class="input-group">
                            <span class="input-group-addon">会员号</span>
                            <asp:TextBox ID="txtCardCode" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">姓名</span>
                            <asp:TextBox ID="txtCodeAmount" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">确认姓名</span>
                            <asp:TextBox ID="txtConsumeTime" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">手机号</span>
                            <asp:TextBox ID="txtMemberCode" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">确认手机号</span>
                            <asp:TextBox ID="txtName" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">管理店铺</span>
                            <%--<input type="" class="form-control" data-inputmask="&quot;mask&quot;: &quot;99999999999&quot;" data-mask="" name="abc4" value="1370283393922">--%>
                            <asp:TextBox ID="txtMobile" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">使用店铺</span>
                            <asp:TextBox ID="txtConsumeMoney" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                                 <div class="input-group">
                            <span class="input-group-addon">尊享券金额</span>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>

                                 <div class="input-group">
                            <span class="input-group-addon">状态</span>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">备注</span>
                            <textarea id="txtRemark" style="width: 195px;" runat="server" class="form-control" rows="3" placeholder=""></textarea>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
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

    <!-- AdminLTE base -->
    <script src="js/Admin/base.js" type="text/javascript"></script>

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
