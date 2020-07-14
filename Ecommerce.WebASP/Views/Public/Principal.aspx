<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Ecommerce.WebASP.Views.Public.Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div id="breadcrumb" class="section">
        <div class="container">
            <div class="row">
                <div class="col-sm-12">
                    <div class="col-sm-11">
                        <div class="col-sm-6">
                            <asp:DropDownList ID="ddlBuscar" runat="server" CssClass="form-control">
                                <asp:ListItem Value="T">Todos</asp:ListItem>
                                <asp:ListItem Value="C">Codigo</asp:ListItem>
                                <asp:ListItem Value="N">Nombre</asp:ListItem>
                                <asp:ListItem Value="CA">Categoria</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <asp:ImageButton ID="imgBuscar" runat="server" ImageUrl="~/Icons/icons8-search-property-64.png" Width="32px" Height="32px" OnClick="imgBuscar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="section">
        <div class="container">
            <div class="row">
                <!-- ASIDE -->
                <div id="aside" class="col-md-2">
                    <!-- aside Widget -->
                    <div class="aside">
                        <h3 class="aside-title">Categories</h3>
                        <ul class="nav navbar-nav">
                            <li><a href="#">TECNOLOGIA </a></li>
                            <li><a href="#">ELECTRODOMESTICOS</a></li>
                            <li><a href="#">LIBROS</a></li>
                        </ul>
                    </div>
                    <!-- /aside Widget -->
                </div>
                <div id="store" class="col-md-9">
                    <!-- store products -->
                    <div class="row">
                                                                                                               
                        <div class="col-sm-12">
                            <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" CssClass="col-sm-12">
                                <ItemTemplate>
                                    <div class="col-sm-12">
                                        <div class="product">
                                            <div class="product-img">
                                                <img src='<%# ResolveClientUrl(Eval("IMAGEN").ToString()) %>' width="180px" height="190px">
                                                <div class="product-label">
                                                    <span class="new">NEW</span>
                                                </div>
                                            </div>
                                            <div class="product-body">
                                                <p class="product-category">Category</p>
                                                <h3 class="product-name">
                                                    <asp:Label ID="lblNombre" runat="server" Text='<%#Eval("NOMBRE") %>'></asp:Label>
                                                </h3>
                                                <h4 class="product-price">
                                                    <asp:Label ID="lblPrecio" runat="server" Text='<%#Eval("PRECIO") %>'></asp:Label>
                                                    <del class="product-old-price">
                                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("PRECIO") %>'></asp:Label></del>
                                                </h4>
                                                <div class="product-btns">
                                                                
                                                    <asp:LinkButton ID="ImageButton2" runat="server" CommandArgument='<%#Eval("ID") %>'  CssClass="quick-view"  OnClick="ImageButton2_Click"><i class='fa fa-eye'></i></asp:LinkButton>

                                                </div>
                                            </div>
                                            <div class="add-to-cart">
                                                
                                                <asp:LinkButton ID="ImageButton1" runat="server" CommandArgument='<%#Eval("ID") %>' CssClass="add-to-cart-btn" AlternateText="Agregar"  OnClick="ImageButton4_Click1"><small> Comprar</small></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>

                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                    <div class="store-filter clearfix">
                        <span class="store-qty">Showing 20-100 products</span>
                        <ul class="store-pagination">
                            <li class="active">1</li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#"><i class="fa fa-angle-right"></i></a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
