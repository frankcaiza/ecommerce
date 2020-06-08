<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WfmProductoNuevo.aspx.cs" Inherits="Ecommerce.WebASP.WebForm.Administrador.Prodcuto.WfmProductoNuevo" %>

<%@ Register Src="~/UserControl/UserControlCat.ascx" TagName="UC_CATEGORIA" TagPrefix="UC_CAT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td colspan="2" style="font-size: large"><strong>Producto</strong></td>
        </tr>

        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>

        <tr>
            <td style="width: 144px">Id</td>
            <td>
                <asp:Label ID="lblId" runat="server" Text="Label"></asp:Label></td>

        </tr>

        <tr>
            <td style="width: 144px">Cateogira</td>
            <td>
               <%-- <asp:DropDownList ID="ddlCat" runat="server"></asp:DropDownList></td>--%>
            <UC_CAT:UC_CATEGORIA ID="UC_CAT1" runat="server"></UC_CAT:UC_CATEGORIA>
        </tr>

        <tr>
            <td style="width: 144px">Codigo</td>
            <td>
                <asp:TextBox ID="txtCod" runat="server"></asp:TextBox></td>
                
        </tr>

        <tr>
            <td style="width: 144px">Nombre</td>
            <td>
                <asp:TextBox ID="txtNom" runat="server"></asp:TextBox></td>

        </tr>

        <tr>
            <td style="width: 144px">Precio de Compra</td>
            <td>
                <asp:TextBox ID="txtPC" runat="server"></asp:TextBox></td>

        </tr>

        <tr>
            <td style="width: 144px">Pecio de Venta</td>
            <td>
                <asp:TextBox ID="txtPV" runat="server"></asp:TextBox></td>

        </tr>

        <tr>
            <td style="width: 144px">Imagen</td>
            <td>
                <asp:FileUpload ID="fuImagen" runat="server" /></td>
        </tr>

        <tr>
            <td style="width: 144px">Descripcion</td>
            <td>
                <asp:TextBox ID="txtDes" runat="server"></asp:TextBox></td>

        </tr>

        <tr>
            <td style="width: 144px">Stock Minimo</td>
            <td>
                <asp:TextBox ID="txtSMin" runat="server"></asp:TextBox></td>

        </tr>

        <tr>
            <td style="width: 144px">Stock Maximo</td>
            <td>
                <asp:TextBox ID="txtSMax" runat="server"></asp:TextBox></td>

        </tr>




    </table>
</asp:Content>
