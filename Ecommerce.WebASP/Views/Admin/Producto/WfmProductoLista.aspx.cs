using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.WebASP.Models;
using Ecommerce.WebASP.LogicaNegocio;

namespace Ecommerce.WebASP.WebForm.Administrador.Prodcuto
{
    public partial class WfmProductoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
                _taskProductos.Wait();
                var _listaProducto = _taskProductos.Result;
                loadProductos(_listaProducto);
            }
            UC_DatosEventos();
        }

        private void UC_DatosEventos()
        {
            GridView gridview = (GridView)this.UC_DAT1.FindControl("GridView1");
            gridview.RowCommand += new GridViewCommandEventHandler(Uc_Datos_RowCommand);

        }

        void Uc_Datos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string codigo = Convert.ToString(e.CommandArgument);
            if (e.CommandName == "Modificar")
            {
                Response.Redirect("WfmProductoNuevo.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "Eliminar")
            {

            }
        }

        private void loadProductos(List<TBL_PRODUCTO> _listaProducto)
        {


            if (_listaProducto != null && _listaProducto.Count > 0)
            {

                UC_DAT1.loadData(_listaProducto.Select(data => new
                {
                    ID = data.PRO_ID.ToString(),
                    CODIGO = data.PRO_CODIGO,
                    NOMBRE = data.PRO_NOMBRE,
                    PRECIO_COMPRA = data.PRO_PRECIO_COMPRA,
                    PRECIO_VENTA = data.PRO_PRECIO_VENTA,
                    CATEGORIA = data.TBL_CATEGORIA.CAT_NOMBRE,
                    STOCK_MAX = data.PRO_STOCK_MAXIMO,
                    STOCK_MIN = data.PRO_STOCK_MINIMO,
                    DESCRIPCION = data.PRO_DESCRIPCION,
                    ESTADO = data.PRO_ESTADO


                }).ToList());

            }
        }

        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Buscar(ddlBuscar.SelectedValue);
        }

        protected void imgNuevo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WfmProductoNuevo.aspx", true);
        }

        private void Buscar(string op)
        {

            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                List<TBL_PRODUCTO> _listaProducto = new List<TBL_PRODUCTO>();
                string datoBuscar = txtBuscar.Text;
                switch (op)
                {
                    case "T":
                        Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
                        _taskProductos.Wait();
                        _listaProducto = _taskProductos.Result;
                        loadProductos(_listaProducto);
                        break;
                    case "C":
                        Task<List<TBL_PRODUCTO>> _taskProductos2 = Task.Run(() => LogicaProducto.searchProductxCod(datoBuscar));
                        _taskProductos2.Wait();
                        _listaProducto = _taskProductos2.Result;
                        loadProductos(_listaProducto);

                        break;
                    case "N":
                        Task<List<TBL_PRODUCTO>> _taskProductos3 = Task.Run(() => LogicaProducto.searchProductxNom(datoBuscar));
                        _taskProductos3.Wait();
                        _listaProducto = _taskProductos3.Result;
                        loadProductos(_listaProducto);
                        break;
                    case "CA":
                        Task<List<TBL_PRODUCTO>> _taskProductos4 = Task.Run(() => LogicaProducto.searchProductxCat(datoBuscar));
                        _taskProductos4.Wait();
                        _listaProducto = _taskProductos4.Result;
                        loadProductos(_listaProducto);
                        break;

                }
            }
        }

    }
}