<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberInfo.aspx.cs" Inherits="Zenga.Web.MemberInfo" %>

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

<%--            <div class="col-sm-12">
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
            </div>--%>

            <div class="col-sm-12">
                <div class="box">
                    <div class="box-header">
                        <h3 class="box-title">用户信息</h3>
                        <div class="box-tools pull-right">
                            <button class="btn btn-success btn-sm edit_info">修改信息</button>
                            <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" OnClick="btnSave_Click" Height="29px" Width="102px" />
                             <%--    <button class="btn btn-success btn-sm edit_info">确认提交</button>--%>
                                 <%--<asp:Button ID="btnConfirm" runat="server" CssClass="btn btn-success" style="   font-size: 12px;" OnClick="btnConfirm_Click" Text="确认提交" Height="29px" Width="82px"  />--%>
                         <%--   <button   style=" background-color: #00a65a;  border-color: white;" CssClass="btn btn-success btn-sm edit_info" class="btn btn-success btn-sm edit_info">确认提交</button>--%>
                        </div>
                    </div>
                    <!-- /.box-header -->
                             <div class="box-body Voucher_dl">
                        <dl class="dl-horizontal">
                            <dt>会员号:</dt>
                            <dd>  <asp:Label ID="lblMemberCode" runat="server"></asp:Label></dd>
                            <dt>姓名:</dt>
                            <dd><asp:Label ID="lblName" runat="server"></asp:Label></dd>
                            <dt>确认姓名:</dt>
                            <dd><asp:Label ID="lblConfirmName" runat="server"></asp:Label></dd>
                            <dt>手机号:</dt>
                            <dd><asp:Label ID="lblMobile" runat="server"></asp:Label></dd>
                            <dt>确认手机号:</dt>
                            <dd><asp:Label ID="lblConfirmMobile" runat="server"></asp:Label></dd>
                            <dt>管理店铺:</dt>
                            <dd><asp:Label ID="lblManageStore" runat="server"></asp:Label>
                                </dd>
                            </dd>
                            <dt>使用店铺:</dt>
                            <dd><asp:Label ID="lblInuseStore" runat="server"></asp:Label></dd>
                            <dt>尊享券金额:</dt>
                            <dd><asp:Label ID="lblAmount" runat="server"></asp:Label><%--<asp:DropDownList ID="drpAmount" runat="server" CssClass="form-control input-sm pull-left" Height="26px" Width="166px"  >
                                                    <asp:ListItem Value="1500">1500</asp:ListItem>
                                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                                    <asp:ListItem Value="3000">3000</asp:ListItem>
                                                    <asp:ListItem Value="3000">5000</asp:ListItem>
                                                </asp:DropDownList></dd>--%>
                         <%--    <dt>状态:</dt>
                            <dd><asp:Label ID="lblStatus" runat="server"></asp:Label></dd>--%>
                            <dt>备注:</dt>
                            <dd><asp:Label ID="lblRemark" runat="server"></asp:Label></dd>
                        </dl>
                    </div>
                    <!-- /.box-body -->

                    <div class="box-body Voucher_dl_info" style="display: none;">
                        <div class="input-group">
                            <span class="input-group-addon">会员号</span>
                            <asp:TextBox ID="txtMemberCode" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">姓名</span>
                            <asp:TextBox ID="txtName" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">确认姓名</span>
                            <asp:TextBox ID="txtConfirmName"  runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">手机号</span>
                            <asp:TextBox ID="txtMobile" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">确认手机号</span>
                            <asp:TextBox ID="txtConfirmMobile" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="input-group">
                            <span class="input-group-addon">管理店铺</span>
                            <%--<input type="" class="form-control" data-inputmask="&quot;mask&quot;: &quot;99999999999&quot;" data-mask="" name="abc4" value="1370283393922">--%>
                            <asp:TextBox ID="txtManageStore" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                                 <div class="input-group">
                            <span class="input-group-addon">使用店铺</span>
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
                            <asp:TextBox ID="txtAmount"  ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                <%--            <div class="input-group">
                            <span class="input-group-addon">状态</span>
                            <asp:TextBox ID="txtStatus"  ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>--%>
                        <div class="input-group">
                            <span class="input-group-addon">备注</span>
                            <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"></asp:TextBox>
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
