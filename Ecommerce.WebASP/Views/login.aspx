<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Ecommerce.WebASP.Views.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8,width=device-width, initial-scale=1" />
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="../vendor/css/bootstrap.min.css"/>
    <link rel="stylesheet" type="text/css" href="../vendor/login/util.css"/>
    <link rel="stylesheet" type="text/css" href="../vendor/login/main.css"/>
    <link rel="shortcut icon" type="image/png" href='../img/icon.jpg' />
</head>
<body>
    <div class="limiter">
        <div class="container-login100">
            <div class="wrap-login100">
                <div class="login100-form-title" style="background-image: url(../img/fondo1.jpg);">
                    <span class="login100-form-title-1"><b>LOGIN</b>
                    </span>
                </div>

                <form id="form1" class="login100-form validate-form" runat="server">
                    <div class="wrap-input100 validate-input m-b-26" data-validate="Username is required">
                        <span class="label-input100">Username</span>
                        <asp:TextBox ID="txt_user" CssClass="input100" placeholder="Enter username" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="wrap-input100 validate-input m-b-18" data-validate="Password is required">
                        <span class="label-input100">Password</span>
                        <asp:TextBox ID="txt_password" CssClass="input100" TextMode="Password" placeholder="Enter Password" runat="server"></asp:TextBox>
                        <span class="focus-input100"></span>
                    </div>

                    <div class="container-login100-form-btn">
                        <asp:Button ID="btn_ingresar" CssClass="login100-form-btn form-control" runat="server" Text="Ingresar" OnClick="btn_ingresar_Click" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>

<script src="../vendor/js/jquery.min.js"></script>
<script src="../vendor/js/bootstrap.min.js"></script>
<script src="../vendor/login/main.js"></script>
<script src="../vendor/js/blockUI.js"></script>
<%
    if (error != "")
    {
%>
<script>
    $(function () {
        var error = '<%= error %>';
        if (error) {
            $.growlUI('Error', '<div class="alert alert-danger">' + error + '</div>');
        }
    });
</script>

<%
    }
%>