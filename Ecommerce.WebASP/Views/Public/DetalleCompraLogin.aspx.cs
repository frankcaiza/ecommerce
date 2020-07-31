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
    public partial class DetalleCompraLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarRadio();
            if (!IsPostBack)
            {
                if (Session["Cart"] != null && Session["Cart"] != null)
                {
                    List<Cart> _listCart = new List<Cart>();
                    _listCart = (List<Cart>)Session["Cart"];
                    loadDetalle(_listCart);
                    TBL_USUARIO _UserLogin = new TBL_USUARIO();
                    _UserLogin = (TBL_USUARIO)Session["Usuario"];
                }
            }

        }

        public void loadDetalle(List<Cart> _listCart)
        {
            decimal total = 0;
            decimal total_iva = 0;


            if (_listCart.Count > 0 && _listCart != null)
            {
                DataList1.DataSource = _listCart.Select(data => new
                {
                    ID = data.id,
                    NOMBRE = data.nombre,
                    IMAGEN = data.imagen,
                    CANTIDAD = data.cantidad,
                    PVP_BASE = data.precioBase,
                    IMPUESTOS = data.impuestos,
                    PORCENTAJE = data.porcentaje,
                    TOTAL = data.precioNormal,
                    TOTAL_IVA = data.precioIva,
                }).ToList();
                DataList1.DataBind();

                foreach (Cart _infoCart in _listCart)
                {
                    total = _infoCart.precioNormal + total;
                    total_iva = _infoCart.precioIva + total_iva;
                }
            }

            lblTotal.Text = Convert.ToString(total_iva);
        }

        public void cargarRadio()
        {
            try
            {
                Task<List<TBL_FORMA_PAGO>> _taskCat = Task.Run(() => LogicaPagos.getAllPagos());
                _taskCat.Wait();
                var _listCat = _taskCat.Result;
                if (_listCat != null && _listCat.Count > 0)
                {
                    var data = _listCat.OrderBy(lista => lista.FPA_CODIGOSRI).ToList();
                    raPagos.DataSource = data;
                    raPagos.DataTextField = "FPA_DESCRIPCION";
                    raPagos.DataValueField = "FPA_ID";

                    raPagos.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error" + ex.Message);
            }
        }


    }
}