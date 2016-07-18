<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Zenga.Web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="lockscreen">
<head  runat="server">
        <meta charset="UTF-8"/>
        <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport' />
        <!-- bootstrap 3.0.2 -->
        <link href="css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <!-- font Awesome -->
        <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <!-- Theme style -->
        <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body class="">
    <div class="form-box" id="login-box">
            <!-- <div class="header">登 录</div> -->
            <img src="img/logo.png" width="100%"/>
            <h4 class="text-yellow" style="text-align: center;">VIP Voucher 门店核查系统v1.0</h4>
            <form id="Form1"  runat="server">
                <div class="body bg-333">
                    <div class="form-group">
                        <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="账号"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtPwd" runat="server" CssClass="form-control" placeholder="密码" TextMode="Password"></asp:TextBox>
                    </div>          
                    <!-- <div class="form-group">
                        <input type="checkbox" name="remember_me"/> 忘记密码
                    </div> -->
                </div>
                <div class="footer bg-333">                                                               
                    <asp:Button ID="btnSubmit" runat="server" Text=" 登 录 " CssClass="btn btn-default btn-block" OnClick="btnSubmit_Click" />
                    <!-- <p><a href="#">I forgot my password</a></p>
                    
                    <a href="register.html" class="text-center">Register a new membership</a> -->
                </div>
            </form>

        </div>
    <!-- jQuery 2.0.2 -->
        <script src="js/jquery.min.js"></script>
        <!-- Bootstrap -->
        <script src="js/bootstrap.min.js" type="text/javascript"></script>
</body>
</html>
