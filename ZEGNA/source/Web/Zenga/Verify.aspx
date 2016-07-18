<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Verify.aspx.cs" Inherits="Zenga.Web.Store.Verification" %>

<%@ Register src="UC/AdminLoginCheck.ascx" tagname="AdminLoginCheck" tagprefix="uc1" %>

<uc1:AdminLoginCheck ID="AdminLoginCheck1" runat="server" />

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
    <script type="text/javascript">
        $(function () {
            $("[data-mask]").inputmask();
        });

        function gshtime(time) {
            var year = time.getFullYear();       
            var month = time.getMonth() + 1;  
            var day = time.getDate();        
            var hh = time.getHours();      
            var mm = time.getMinutes();    
            var ss = time.getSeconds();    

            var str = year + "-";
            if (month < 10)
                str += "0";
            str += month + "-";
            if (day < 10)
                str += "0";
            str += day + " ";

            if (hh < 10)
                str += "0";
            str += hh + ":";

            if (mm < 10)
                str += "0";
            str += mm + ":";

            if (ss < 10)
                str += "0";
            str += ss + "";

            return (str);
        }
        
        function copyData()
        {
            //counterCode
            //storeName
            //vipCardCode
            //vipCardAmount
            //customerCode
            //vipName
            //vipMobile
            //consumeAmount
            //remark
            $("#counterCode2").text($("#counterCode").text());
            $("#storeName2").text($("#storeName").text());
            $("#vipCardCode2").text($("#vipCardCode").val());
            $("#vipCardAmount2").text($("#vipCardAmount").val());
            
            $("#customerCode2").text($("#customerCode").val());
            $("#vipName2").text($("#vipName").val());
            $("#vipMobile2").text($("#vipMobile").val());
            $("#consumeAmount2").text($("#consumeAmount").val());
            $("#remark2").text($("#remark").val());

            var currTime = new Date();
            var currFormatTime = gshtime(currTime);
            $("#verifyTime").text(currFormatTime);

            //getFormateDate();
        }
        function submitData()
        {
            var postData = "counterCode=" + $("#counterCode2").text();
            postData += "&" + "storeName=" + $("#storeName2").text();
            postData += "&" + "vipCardCode=" + $("#vipCardCode2").text();
            postData += "&" + "vipCardAmount=" + $("#vipCardAmount2").text();
            postData += "&" + "customerCode=" + $("#customerCode2").text();
            postData += "&" + "vipName=" + $("#vipName2").text();
            postData += "&" + "vipMobile=" + $("#vipMobile2").text();
            postData += "&" + "consumeAmount=" + $("#consumeAmount2").text();
            postData += "&" + "remark=" + $("#remark2").text();
            postData += "&" + "verifyTime=" + $("#verifyTime").text();

            $.ajax({
                type: "POST",
                url: "/Handler/SubmitVerifyData.ashx",
                data: postData,
                success: function (msg) {
                    if (msg == "1") {
                        alert('核销成功');
                        window.location.href = '/VerifyPrint.aspx?code=' + $("#vipCardCode").val();
                    }
                    else {
                        alert(msg);
                    }
                }
            });
        }



       

        function queryVoucher()
        {
            $("#infoOK").hide();
            $("#infoFail").hide();
            reset();

            //alert('zz');
            var code = $("#voucherCode").val();
            //alert(code);
            $.ajax({
                type: "POST",
                url: "/Handler/QueryVoucher.ashx",
                data: { "code": code },
                dataType:"json",
                success: function (msg) {
//                    alert("Data Saved: " + msg.Mobile);
                    //{"vipCardInfo":{"Mobile":"18601651913","CustomerCode":"123","MemberCode":"321","MemberName":"gavin","CardCode":"cardCode","CardAmount":"5000","StoreName":"S航海","StorePhone":"123123123"},"vipCardResult":{"Mobile":"18601651913","CounterCode":"AB","Status":1,"ConsumeAmount":14,"Remark":"dfas","CreateTime":"\/Date(1437387589000)\/","UpdateTime":null}}
                    if (msg.vipCardInfo == null)
                    {
                        alert('Invalid Code');
                    }
                    else if (msg.vipCardResult == null) {

                        //alert(msg.vipCardInfo.CardAmount);
                        $("#vipCardCode").val($("#voucherCode").val());
                        $("#vipCardAmount").val(msg.vipCardInfo.CardAmount);
                        $("#customerCode").val(msg.vipCardInfo.CustomerCode);
                        $("#vipName").val(msg.vipCardInfo.MemberName);
                        $("#vipMobile").val(msg.vipCardInfo.Mobile);

                       // <p id="infoFail_verifyTitle">Voucher Code: Z03928392 已经核销，不能重复使用！</p>
                       //    <p id="infoFail_verifyShop">核销门店：上海力宝广场店</p>
                       //    <p id="infoFail_verifyTime">核销时间：2015-08-10 15:29:32</p>
                       //</div>
                       //<div id="infoOK" class="alert alert-success alert-dismissable">
                       //    <i class="fa fa-check"></i>
                        //    <p id="infoOK_title">Voucher Code: Z03928392 尚未核销，可以使用！</p>
                        $("#infoOK_title").text("Voucher Code: " + $("#voucherCode").val() + " 尚未核销，可以使用！");


                        $("#infoOK").show();
                        $("#infoFail").hide();
                    }
                    else {
                        $('#infoFail_verifyTitle').text('Voucher Code: ' + $("#voucherCode").val() + ' 已经核销，不能重复使用！');
                        $("#infoFail_verifyShop").text("核销门店：" + msg.VerifyStoreInfo.StoreName);

                        if (msg.vipCardResult.UpdateTime == null) {
                            var v = new Date();
                            v = msg.vipCardResult.CreateTime;
                            var date = eval('new ' + eval(v).source);
                            $("#infoFail_verifyTime").text("核销时间：" + gshtime(date));
                        }
                        else {
                            var v2 = new Date();
                            v2 = msg.vipCardResult.UpdateTime;
                            var date2 = eval('new ' + eval(v2).source);
                            $("#infoFail_verifyTime").text("核销时间：" + gshtime(date2));
                        }

                        $("#infoOK").hide();
                        $("#infoFail").show();
                    }
                }
            });
            return false;
        }

        function reset()
        {
            $("#vipCardCode").val("");
            $("#vipCardAmount").val("");
            $("#customerCode").val("");
            $("#vipName").val("");
            $("#vipMobile").val("");
            $("#consumeAmount").val("");
            $("#remark").val("");
        }


        $(document).ready(function () {
            //alert('c');
            $("#counterCode").text( $.cookies.get("User"));
            $("#storeName").text($.cookies.get("StoreName"));
            $("#storeType").text($.cookies.get("StoreType"));

            $("#loginUser1").text($.cookies.get("User"));
            $("#loginUser2").text($.cookies.get("User"));


            $("#infoOK").hide();
            $("#infoFail").hide();
        });

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
                            <a href="ImportStore.aspx">
                                <!-- <i class="fa fa-gears"></i> -->
                                <span>上传数据</span>
                            </a>
                        </li>
                       <li>
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
                <h1>Voucher核销创建
        <!-- <small>通过设置...</small> -->
                </h1>
                <ol class="breadcrumb">
                    <li><a href="#"><i class="fa fa-dashboard"></i>主页</a></li>
                    <li class="active">Voucher核销</li>
                </ol>
            </section>


            <section class="content no-print">

                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-solid">
                            <div class="box-header">
                                <h3 class="box-title">门店信息</h3>
                            </div>
                            <!-- /.box-header -->
                            <div class="box-body">
                                <div class="row">
                                    <div class="col-md-2">
                                        <dl class="dl-horizontal">
                                            <dt>柜台编号:</dt>
                                            <dd id="counterCode">SHZZ</dd>
                                        </dl>
                                    </div>
                                    <div class="col-md-3">
                                        <dl class="dl-horizontal">
                                            <dt>店铺类型:</dt>
                                            <dd id="storeType">上海虹桥友谊商城ZZegna店</dd>
                                        </dl>
                                    </div>
                                    <div class="col-md-5">
                                        <dl class="dl-horizontal">
                                            <dt>店铺名称:</dt>
                                            <dd id="storeName">上海虹桥友谊商城ZZegna店</dd>
                                        </dl>
                                    </div>
                                </div>
                            </div>
                            <!-- /.box-body -->
                        </div>
                        <!-- /.box -->
                    </div>
                    <!-- ./col -->
                </div>

                <div class="row">
                    <div class="col-md-6">
                        <div class="box box-solid">
                            <div class="box-header">
                                <h3 class="box-title">Voucher信息:</h3>
                            </div>
                            <!-- /.box-header -->
                            <!-- form start -->
                                <div class="box-body">
                                    <div class="input-group">
                                        <span class="input-group-addon">Voucher Code</span>
                                        <input id="voucherCode" type="text" class="form-control" placeholder="">
                                    </div>
                                </div>
                                <!-- /.box-body -->

                                <div class="box-footer">
                                    <button type="button" onclick="return queryVoucher()" class="btn btn-primary">查询</button>
                                </div>
                        </div>
                        <!-- /.box -->
                    </div>
                    <!-- ./col -->
                    <div class="col-md-6">

                        <div id="infoFail" class="alert alert-danger alert-dismissable">
                            <i class="fa fa-ban"></i>
                            <p id="infoFail_verifyTitle"><%--Voucher Code: Z03928392 已经核销，不能重复使用！--%></p>
                            <p id="infoFail_verifyShop"><%--核销门店：上海力宝广场店--%></p>
                            <p id="infoFail_verifyTime"><%--核销时间：2015-08-10 15:29:32--%></p>
                        </div>
                        <div id="infoOK" class="alert alert-success alert-dismissable">
                            <i class="fa fa-check"></i>
                            <p id="infoOK_title"><%--Voucher Code: Z03928392 尚未核销，可以使用！--%></p>
                        </div>

                    </div>
                    <!-- ./col -->
                    
                </div>

                <div class="row">
                    <div class="col-md-12">
                        <div class="box box-solid">
                            <div class="box-header">
                                <h3 class="box-title">Voucher Code 查询:</h3>
                            </div>
                            <!-- /.box-header -->
                            <!-- form start -->
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-6">

                                            <div class="input-group">
                                                <span class="input-group-addon" style="width: 110px; text-align: left;">Code</span>
                                                <input id="vipCardCode" type="text" class="form-control" placeholder="" disabled>
                                            </div>
                                            </br>
                            <div class="input-group">
                                <span class="input-group-addon" style="width: 110px; text-align: left;">Code 面值</span>
                                <input id="vipCardAmount" type="text" class="form-control" placeholder="" disabled>
                            </div>
                                            </br>
                            <div class="input-group">
                                <span class="input-group-addon" style="width: 110px; text-align: left;">顾客编号</span>
                                <input id="customerCode" runat="server" type="text" readonly="readonly" class="form-control" placeholder="">
                            </div>
                                            </br>
                            <div class="input-group">
                                <span class="input-group-addon" style="width: 110px; text-align: left;">VIP 姓名</span>
                                <input id="vipName" runat="server" type="text" class="form-control" readonly="readonly" placeholder="">
                            </div>
                                            </br>
                            <div class="input-group">
                                <span class="input-group-addon" style="width: 110px; text-align: left;" >VIP 手机号码</span>
                                <input readonly="readonly" id="vipMobile" runat="server" type="text" class="form-control" data-inputmask="&quot;mask&quot;: &quot;99999999999&quot;" data-mask="" name="abc4">
                            </div>
                                            </br>
                            <div class="input-group">
                                <span class="input-group-addon" style="width: 110px; text-align: left;">消费金额</span>
                                <input id="consumeAmount" type="number" class="form-control" placeholder="">
                            </div>
                                            </br>
                            <div class="input-group">
                                <span class="input-group-addon" style="width: 110px; text-align: left;">备注</span>
                                <textarea id="remark" runat="server" style="width: 195px;" class="form-control" rows="3" placeholder=""></textarea>
                            </div>

                                        </div>
                                    </div>
                                </div>
                                <!-- /.box-body -->

                                <div class="box-footer">
                                    <!-- <button type="submit" class="btn btn-default" >确定提交</button> -->
                                    <a type="button" onclick="copyData()" class="btn btn-default" data-toggle="modal" data-target="#myModal">确定提交</a>
                                </div>
                        </div>
                        <!-- /.box -->
                    </div>
                </div>

            </section>
            <!-- /.content -->

            <!-- 模态框（Modal） -->
            <div class="modal fade" id="myModal" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"
                                aria-hidden="true">
                                ×
                            </button>
                            <h4 class="modal-title" id="myModalLabel">Voucher 核销修改
                            </h4>
                        </div>
                        <div class="modal-body">

                            <div class="row">

                                <div class="col-xs-12">
                                    <div class="box">
                                        <div class="box-header">
                                            <h3 class="box-title">门店信息</h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body">
                                            <dl class="dl-horizontal">
                                                <dt>柜台编号:</dt>
                                                <dd id="counterCode2"><%--SHZZ--%></dd>
                                                <dt>店铺名称:</dt>
                                                <dd id="storeName2"><%--上海虹桥友谊商城ZZegna店--%></dd>
                                            </dl>
                                        </div>
                                        <!-- /.box-body -->
                                    </div>
                                </div>

                                <div class="col-xs-12">
                                    <div class="box">
                                        <div class="box-header">
                                            <h3 class="box-title">Voucher Code 信息</h3>
                                        </div>
                                        <!-- /.box-header -->
                                        <div class="box-body Voucher_dl">
                                            <dl class="dl-horizontal">
                                                <dt>Code:</dt>
                                                <dd id="vipCardCode2">SHZZ</dd>
                                                <dt >Code 面值:</dt>
                                                <dd id="vipCardAmount2">¥ 3000</dd>
                                                <dt>核销时间:</dt>
                                                <dd id="verifyTime">2015-08-16 13:24:35</dd>
                                                <dt>顾客编号:</dt>
                                                <dd id="customerCode2"></dd>
                                                <dt>VIP 姓名:</dt>
                                                <dd id="vipName2">小李</dd>
                                                <dt >手机号码:</dt>
                                                <dd id="vipMobile2">1370283393922</dd>
                                                <dt>消费金额:</dt>
                                                <dd id="consumeAmount2">¥ 7000</dd>
                                                <dt >备注:</dt>
                                                <dd id="remark2">优惠券消费</dd>
                                            </dl>
                                        </div>
                                        <!-- /.box-body -->
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="modal-footer no-print">

                            <button type="button" class="btn btn-default"
                                data-dismiss="modal">
                                取消
                            </button>
                            <button type="button" class="btn btn-primary" onclick="submitData()">
                                确认提交
                            </button>
                        </div>
                    </div>
                    <!-- /.modal-content -->
                </div>
                <!-- /.modal-dialog -->
            </div>
            <!-- /.modal -->
        </aside>
        <!-- /.right-side -->
    </div>
    <!-- ./wrapper -->

    </form>

</body>
</html>

