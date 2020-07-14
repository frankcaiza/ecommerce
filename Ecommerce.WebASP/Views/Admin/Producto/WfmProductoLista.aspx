<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WfmProductoLista.aspx.cs" Inherits="Ecommerce.WebASP.WebForm.Administrador.Prodcuto.WfmProductoLista" %>

<%@ Register Src="~/UserControl/UC_Gridview_Datos.ascx" TagName="UC_DATOS" TagPrefix="UC_DAT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h3>Lista Productos</h3>
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
        <div class="col-sm-1">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Icons/icons8-añadir-24.png" Width="32px" Height="32px" OnClick="imgNuevo_Click" />
        </div>
    </div>
    <hr />
    <br />

    <UC_DAT:UC_DATOS ID="UC_DAT1" runat="server"></UC_DAT:UC_DATOS>
</asp:Content>
