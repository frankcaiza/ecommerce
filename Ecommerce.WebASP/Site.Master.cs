using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.WebASP.LogicaNegocio;
using Ecommerce.WebASP.Models;

namespace Ecommerce.WebASP
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Cart"] != null)
                {
                    List<Cart> _listCart = new List<Cart>();
                    _listCart = (List<Cart>)Session["Cart"];
                    if (_listCart.Count > 0 && _listCart != null)
                    {
                        loadDetalle(_listCart);
                    }
                }
                else
                {
                    List<Cart> _listCart = new List<Cart>();
                    Session["Cart"] = _listCart;
                }
                    /*
                    if (Session["Usuario"] != null)
                    {
                        TBL_USUARIO _UserLogin = new TBL_USUARIO();
                        _UserLogin = (TBL_USUARIO)Session["Usuario"];
                        if (_UserLogin != null)
                        {
                            lbl_username.Text = _UserLogin.USU_NOMBRES;
                            lbl_username2.Text = _UserLogin.USU_NOMBRES;
                            lbl_rol.Text = _UserLogin.TBL_ROL.ROL_DESCRIPCION;
                        }
                        else
                        {
                           Response.Redirect("~/Views/login.aspx", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Views/login.aspx", true);
                    }
                    */
                }
        }

        protected void link_cerrar_session_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("~/Views/login.aspx", true);
        }

        protected void btnViewCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Public/DetalleCompra.aspx", true);
        }
        protected void btnPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Public/Principal.aspx", true);
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

            totalCart.Text = Convert.ToString(total_iva);
            cantidadCart.Text = _listCart.Count.ToString();
            cantidadCart2.Text = _listCart.Count.ToString();
        }
    }
}