using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.WebASP.Models;
using Ecommerce.WebASP.LogicaNegocio;

namespace Ecommerce.WebASP.Views.Public
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                loadCatalogo();
            }
        }


        private void loadCatalogo()
        {
            Task<List<TBL_PRODUCTO>> _taskProductos = Task.Run(() => LogicaProducto.getAllProduct());
            _taskProductos.Wait();
            var _listaProducto = _taskProductos.Result;
            loadProductos(_listaProducto);


        }

        protected void imgBuscar_Click(object sender, ImageClickEventArgs e)
        {
            Buscar(ddlBuscar.SelectedValue);
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
        public void loadProductos(List<TBL_PRODUCTO> _listaProducto)
        {


            if (_listaProducto != null && _listaProducto.Count > 0)
            {

                DataList1.DataSource = _listaProducto.Select(data => new
                {
                    ID = data.PRO_ID,
                    NOMBRE = data.PRO_NOMBRE,
                    PRECIO = data.PRO_PRECIO_VENTA,
                    IMAGEN = data.PRO_IMAGEN,
                    CATEGORIA = data.TBL_CATEGORIA.CAT_NOMBRE

                }).ToList();

                DataList1.DataBind();

            }
        }

        protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
        {
            ImageButton objImage = (ImageButton)sender;

            string[] commandArgs = objImage.CommandArgument.ToString().Split(new char[] { ',' });
            string codigo = commandArgs[0];
            Response.Redirect("Producto.aspx?cod=" + codigo, true);
        }

        protected void ImageButton4_Click1(object sender, EventArgs e)
        {
            LinkButton objImage = (LinkButton)sender;

            string[] commandArgs = objImage.CommandArgument.ToString().Split(new char[] { ',' });
            int idProducto = Convert.ToInt32(commandArgs[0]);
            TBL_PRODUCTO _infoPro = new TBL_PRODUCTO();
            var task = Task.Run(() => LogicaProducto.getAllProductxId(idProducto));
            task.Wait();
            _infoPro = task.Result;

            List<Cart> _listCart = new List<Cart>();
            _listCart = (List<Cart>)Session["Cart"];

            Cart _addCart = Cart.intanciaCartXProducto(_infoPro, "1");

            Session["Cart"] = Cart.addCart(_listCart, _addCart);

            Response.Redirect("Principal.aspx", true);
        }

        protected void ImageButton2_Click(object sender, EventArgs e)
        {
            LinkButton objImage = (LinkButton)sender;

            string[] commandArgs = objImage.CommandArgument.ToString().Split(new char[] { ',' });
            string codigo = commandArgs[0];
            Response.Redirect("Producto.aspx?cod=" + codigo, true);
        }
    }
}