<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WfmProductoNuevo.aspx.cs" Inherits="Ecommerce.WebASP.WebForm.Administrador.Prodcuto.WfmProductoNuevo" %>

<%@ Register Src="~/UserControl/UserControlCat.ascx" TagName="UC_CATEGORIA" TagPrefix="UC_CAT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <hr />
    <div class="col-sm-12">
        <div class="col-sm-8">
            <h3>Informacion de Producto</h3>
            <asp:Label ID="lblId" runat="server"></asp:Label>
            <asp:Label ID="lblImg" runat="server"></asp:Label>
        </div>
        <div class="col-sm-4">
            <asp:ImageButton ID="ImageButton3" Width="32px" Height="32px" CssClass="text-right" CausesValidation="false" runat="server" ImageUrl="~/Icons/icons8-search-property-64.png" OnClick="ImageButton3_Click1" title="Listado Productos" />
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <div class="col-sm-12">
        <div class="col-sm-6">
            <div class="form-group">
                <label>Categoria</label>
                <UC_CAT:UC_CATEGORIA ID="UC_CAT1" CssClass="form-control" runat="server"></UC_CAT:UC_CATEGORIA>
            </div>
            <div class="form-group">
                <label>Codigo</label>
                <asp:TextBox ID="txtCod" CssClass="form-control" runat="server"></asp:TextBox>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtCod" runat="server" ErrorMessage="Codigo Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                </strong>
            </div>
            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox ID="txtNom" CssClass="form-control" runat="server"></asp:TextBox>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNom" runat="server" ErrorMessage="Nombre Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                </strong>
            </div>
            <div class="form-group">
                <label>Precio Compra</label>
                <asp:TextBox ID="txtPC" CssClass="form-control" runat="server"></asp:TextBox>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPC" runat="server" ErrorMessage="Precio de Compra Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                </strong>
            </div>
            <div class="form-group">
                <label>Precio Venta</label>
                <asp:TextBox ID="txtPV" CssClass="form-control" runat="server"></asp:TextBox>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtPV" runat="server" ErrorMessage="Precio de Venta Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                </strong>
            </div>
            <div class="form-group">
                <label>Stock Minimo</label>
                <asp:TextBox ID="txtSMin" CssClass="form-control" runat="server"></asp:TextBox>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtSMin" runat="server" ErrorMessage="Stock Minimo Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                </strong>
            </div>
            <div class="form-group">
                <label>Stock Maximo</label>
                <asp:TextBox ID="txtSMax" CssClass="form-control" runat="server"></asp:TextBox>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtSMax" runat="server" ErrorMessage="Stock Maximo Campo Requerido " ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                </strong>
            </div>
        </div>
        <div class="col-sm-6">
            <div class="form-group">
                <label>Imagen</label>
                <asp:FileUpload ID="fuimagen" CssClass="file" type="file" accept=".png, .jpg, .pdf" runat="server" />
            </div>
            <div class="form-group">
                <label>Descripcion</label>
                <asp:TextBox ID="txtDes" CssClass="form-control" TextMode="multiline" Columns="50" Rows="5" runat="server"></asp:TextBox>
                <strong>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtDes" runat="server" ErrorMessage="Descripcion Campo Requerido" ForeColor="Red" Style="color: #FF0000">*</asp:RequiredFieldValidator>
                </strong>
            </div>
            <div class="form-group">
                <label>Mensaje</label>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" Style="color: #CC0000" />
            </div>
        </div>
        <div class="col-sm-12">
            <asp:ImageButton ID="ImageButton1" Width="32px" Height="32px" CausesValidation="false" runat="server" ImageUrl="~/Icons/icons8-añadir-24.png" title="Nuevo" OnClick="ImageButton1_Click1" />

            <asp:ImageButton ID="ImageButton2" Width="32px" Height="32px" runat="server" ImageUrl="~/Icons/icons8-guardar-24.png" OnClick="ImageButton2_Click1" title="Guardar" />
            <br />
            <hr />
        </div>
    </div>
    <script>
        var imgData = $('#<%=lblImg.ClientID%>').text();
        var idFileInp = $('#<%=fuimagen.ClientID%>');
        if (imgData != "") {
            var img = '<%=ResolveClientUrl(lblImg.Text)%>';
            var imgName = img.split("/");

            idFileInp.fileinput({
                overwriteInitial: true,
                initialPreviewAsData: true,
                initialPreview: [
                    img
                ],
                initialPreviewConfig: [
                    { caption: imgName[4], size: 329892, width: "120px", url: "{$url}", key: 1 },
                ]
            });
            
        } 
    </script>
</asp:Content>
