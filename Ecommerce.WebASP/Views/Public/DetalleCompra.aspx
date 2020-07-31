<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCompra.aspx.cs" Inherits="Ecommerce.WebASP.Views.Public.DetalleCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="section">
        <div class="container">
            <div class="row">
                <div class="col-md-7">
                    <div class="billing-details">
                        <div class="section-title">
                            <h3 class="title">Informacion del Cliente</h3>
                        </div>
                        <div class="col-sm-12">
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Nombres :</label>
                                    <asp:TextBox ID="txt_nombres" CssClass="form-control" runat="server"></asp:TextBox>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txt_nombres" runat="server" ErrorMessage="Nombres Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                                    </strong>
                                </div>
                                <div class="form-group">
                                    <label>Fecha de Nacimiento :</label>
                                    <asp:TextBox ID="txt_fecha_nacimiento" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txt_fecha_nacimiento" runat="server" ErrorMessage="Fecha de Nacimiento Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                                    </strong>
                                </div>
                                <div class="form-group">
                                    <label>Correo :</label>
                                    <asp:TextBox ID="txt_correo" CssClass="form-control" runat="server" TextMode="Email"></asp:TextBox>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txt_correo" runat="server" ErrorMessage="Correo Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                                    </strong>
                                </div>
                                <div class="form-group">
                                    <label>Direccion :</label>
                                    <asp:TextBox ID="txt_direccion" CssClass="form-control" runat="server"></asp:TextBox>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_direccion" runat="server" ErrorMessage="Direccion Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                                    </strong>
                                </div>
                            </div>
                            <div class="col-sm-6">
                                <div class="form-group">
                                    <label>Apellidos: </label>
                                    <asp:TextBox ID="txt_apellidos" CssClass="form-control" runat="server"></asp:TextBox>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_apellidos" runat="server" ErrorMessage="Apellidos Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                                    </strong>
                                </div>
                                <div class="form-group">
                                    <label>Identificacion :</label>
                                    <asp:TextBox ID="txt_identificacion" CssClass="form-control" runat="server"></asp:TextBox>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txt_identificacion" runat="server" ErrorMessage="Identificacion Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                                    </strong>
                                </div>
                                <div class="form-group">
                                    <label>Telefono :</label>
                                    <asp:TextBox ID="txt_telefono" CssClass="form-control" runat="server"></asp:TextBox>
                                    <strong>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txt_telefono" runat="server" ErrorMessage="Telefono Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                                    </strong>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-5 order-details">
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
                                            $<asp:Label ID="Label5" runat="server" Text='<%#Eval("PVP_BASE") %>'></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("IMPUESTOS") %>'></asp:Label>
                                        </div>
                                        <div>
                                            $<asp:Label ID="Label1" runat="server" Text='<%#Eval("TOTAL_IVA") %>'></asp:Label>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <div class="order-col">
                            <div class="text-left"><strong>SUBTOTAL : </strong></div>
                            <div class="text-right">
                                <strong class="order-total">
                                    <asp:TextBox ID="txt_subtotal" runat="server"></asp:TextBox>
                                </strong>
                            </div>
                        </div>
                        <div class="order-col">
                            <div class="text-left"><strong>TOTAL : </strong></div>
                            <div class="text-right">
                                <strong class="order-total">
                                    <asp:TextBox ID="txt_total" runat="server"></asp:TextBox>
                                </strong>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <hr />
                        <label>Forma de Pago : </label>
                        <asp:RadioButtonList runat="server" ID="raPagos">
                            <asp:ListItem Text="Efectivo" Value="1" />
                            <asp:ListItem Text="Paypal" Value="2" />
                        </asp:RadioButtonList>
                        <strong>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="raPagos" runat="server" ErrorMessage="Pago Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                        </strong>
                        <hr />
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Confirmar Compra" CssClass="primary-btn order-submit form-control" OnClick="Button1_Click" />
                    <hr />
                    <div class="form-group">
                        <label>Mensaje</label>
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="color: #CC0000" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
