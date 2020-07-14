<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_Gridview_Datos.ascx.cs" Inherits="Ecommerce.WebASP.UserControl.UC_Gridview_Datos" %>
<asp:GridView ID="GridView1" runat="server" Class="table table-striped table-condensed table-bordered" BorderStyle="None" BorderWidth="2" OnRowCommand="GridView1_RowCommand">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:TemplateField HeaderText="Actions" ShowHeader="true">
            <ItemTemplate>
                <asp:ImageButton ID="imbEditar" runat="server" ImageUrl="~/Icons/icons8-edit-64.png" title="Editar" Width="32px" CommandName="Modificar" CommandArgument='<%#Eval("ID") %>' Height="32px" />
                <asp:ImageButton ID="imbEliminar" runat="server" ImageUrl="~/Icons/icons8-trash-can-48.png" title="Eliminar" Width="32px" CommandName="Eliminar" CommandArgument='<%#Eval("ID") %>' Height="32px" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
