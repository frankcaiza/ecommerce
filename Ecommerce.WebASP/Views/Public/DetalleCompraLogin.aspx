<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCompraLogin.aspx.cs" Inherits="Ecommerce.WebASP.Views.Public.DetalleCompraLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="section">
        <div class="container">
            <div class="row">
                <div class="col-md-6 order-details">
                    <div class="billing-details">
                        <div class="section-title">
                            <h3 class="title">Informacion del Cliente</h3>
                        </div>
                        Estimado Cliente 
                    </div>
                </div>
                <div class="col-md-6 order-details">
                    <div class="section-title text-center">
                        <h3 class="title">Order</h3>
                    </div>
                    <div class="order-summary">
                        <table class="table table-condensed table-striped">
                            <tbody>
                                <tr>
                                    <td class="text-left"><strong>PRODUCTO</strong></td>
                                    <td class="text-right"><strong>PVP/UNITARIO</strong></td>
                                    <td class="text-right"><strong>TOTAL</strong></td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="order-products">
                            <asp:DataList ID="DataList1" runat="server" RepeatDirection="Vertical" CssClass="col-sm-12">
                                <ItemTemplate>
                                    <div class="order-col">
                                        <div>
                                            <img src='<%# ResolveClientUrl(Eval("IMAGEN").ToString()) %>' width="80px" height="90px">
                                        </div>
                                        <div>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("CANTIDAD") %>'></asp:Label>x
                                               <asp:Label ID="Label2" runat="server" Text='<%#Eval("NOMBRE") %>'></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("PVP_BASE") %>'></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("TOTAL_IVA") %>'></asp:Label>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <div class="order-col">
                            <div class="text-left"><strong>TOTAL</strong></div>
                            <div class="text-right">
                                <strong class="order-total">
                                    <asp:Label ID="lblTotal" runat="server" Text='0'></asp:Label>
                                </strong>
                            </div>
                        </div>
                    </div>
                    <div class="payment-method">
                        <asp:RadioButtonList runat="server" AutoPostBack="false" RepeatDirection="Vertical" ID="raPagos" CssClass="input-radio">
                        </asp:RadioButtonList>
                    </div>
                    <a href="#" class="primary-btn order-submit">Place order</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
