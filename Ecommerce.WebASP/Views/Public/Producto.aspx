<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Ecommerce.WebASP.Views.Public.Producto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="breadcrumb" class="section">
        <!-- container -->
        <div class="container">
            <!-- row -->
            <div class="row">
                <div class="col-md-12">
                    <ul class="breadcrumb-tree">
                        <li><a href="Principal.aspx">Productos</a></li>
                        <li><%= _infoPro.PRO_NOMBRE %></li>
                    </ul>
                </div>
            </div>
            <!-- /row -->
        </div>
        <!-- /container -->
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-5 col-md-push-2">
                <div id="product-main-img">
                    <div class="product-preview">
                        <img src='<%= ResolveClientUrl(_infoPro.PRO_IMAGEN) %>' alt="">
                    </div>
                    <div class="product-preview">
                        <img src='<%= ResolveClientUrl(_infoPro.PRO_IMAGEN) %>' alt="">
                    </div>
                </div>
            </div>
            <div class="col-md-2  col-md-pull-5">
                <div id="product-imgs">
                    <div class="product-preview">
                        <img src='<%= ResolveClientUrl(_infoPro.PRO_IMAGEN) %>' alt="">
                    </div>
                    <div class="product-preview">
                        <img src='<%= ResolveClientUrl(_infoPro.PRO_IMAGEN) %>' alt="">
                    </div>
                </div>
            </div>
            <div class="col-md-5">
                <div class="product-details text-center">
                    <h2 class="product-name"><%= _infoPro.PRO_NOMBRE %>
                        <label class="product-price">$ <%= _infoPro.PRO_PRECIO_VENTA %> </label>
                    </h2>
                    <p><%= _infoPro.PRO_DESCRIPCION %>.</p>
                     <asp:TextBox ID="txtCantidad" CssClass="form-control" runat="server" TextMode="Number" value="1"></asp:TextBox>
                    <br />
                    <div class="add-to-cart text-center">
                        <asp:LinkButton ID="btnAdd" runat="server" CssClass="add-to-cart-btn" OnClick="btnAdd_Click"><i class="fa fa-shopping-cart"></i>Comprar</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../../vendor/js/jquery.min.js"></script>
    <script src="../../vendor/js/bootstrap.min.js"></script>
    <script src="../../vendor/js/slick.min.js"></script>
    <script src="../../vendor/js/nouislider.min.js"></script>
    <script src="../../vendor/js/jquery.zoom.min.js"></script>
    <script src="../../vendor/js/main.js"></script>
</asp:Content>
