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
    public partial class DetalleCompra : System.Web.UI.Page
    {
        private static List<Cart> _listCart = new List<Cart>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_total.Text = "0"; txt_total.Enabled = false;
                txt_subtotal.Text = "0"; txt_subtotal.Enabled = false;
                if (Session["Cart"] != null)
                {
                    _listCart = (List<Cart>)Session["Cart"];
                    loadDetalle(_listCart);
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

            txt_subtotal.Text = Convert.ToString(total);
            txt_total.Text = Convert.ToString(total_iva);
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            saveCliente();
            limpiar();
            Session.Clear();
            Session.Remove("Cart");
            Response.Redirect("Principal.aspx", true);

        }
        private void saveCliente()
        {
            EcommerceEntities dbEstatica = new EcommerceEntities();
            var dbContextTransaction = dbEstatica.Database.BeginTransaction();
            try
            {
                TBL_CLIENTE _infoCliente = new TBL_CLIENTE();
                _infoCliente.CLI_NOMBRES = txt_nombres.Text;
                _infoCliente.CLI_APELLIDOS = txt_apellidos.Text;
                _infoCliente.CLI_FECHA_NACIMIENTO = Convert.ToDateTime(txt_fecha_nacimiento.Text);
                _infoCliente.CLI_IDENTIFICACION = txt_identificacion.Text;
                _infoCliente.CLI_CORREO = txt_correo.Text;
                _infoCliente.CLI_TELEFONO = txt_telefono.Text;
                _infoCliente.CLI_DIRECCION = txt_direccion.Text;
                string select = raPagos.SelectedValue;
                Task<bool> _taskSave = Task.Run(() => LogicaCliente.saveCliente(_infoCliente, dbEstatica));
                _taskSave.Wait();
                var resultado = _taskSave.Result;
                if (!resultado)
                {
                    throw new ArgumentException("No se guardado Cliente");
                }
                TBL_PEDIDO pedidoSave = savePedido(_infoCliente, txt_subtotal.Text, txt_total.Text, dbEstatica);
                if (pedidoSave != null)
                {
                    saveDetallePedido(pedidoSave, _listCart, dbEstatica);
                    savePago(pedidoSave, txt_total.Text, select, dbEstatica);
                    dbContextTransaction.Commit();
                    lblMessage.Text = "Exito en el guardado";
                }
            }
            catch (Exception ex)
            {
                dbContextTransaction.Rollback();
                lblMessage.Text = ex.Message + "linea: " + ex.Source;
            }
        }

        private void saveDetallePedido(TBL_PEDIDO _infoPedido, List<Cart> _listCart, EcommerceEntities dbEstatica)
        {
            try
            {
                if (_listCart.Count > 0 && _listCart != null)
                {
                    foreach (Cart cartInfo in _listCart)
                    {
                        TBL_DETALLE_PEDIDO _infoPedidoDetalle = new TBL_DETALLE_PEDIDO();
                        _infoPedidoDetalle.PED_ID = _infoPedido.PED_ID;
                        _infoPedidoDetalle.PRO_ID = cartInfo.id;
                        _infoPedidoDetalle.DEP_CANTIDAD = cartInfo.cantidad;
                        _infoPedidoDetalle.DEP_DESCRIPCION = cartInfo.nombre;
                        _infoPedidoDetalle.DEP_PRECIOUNITARIO = cartInfo.precioBase;
                        _infoPedidoDetalle.DEP_PRECIOTOTAL = cartInfo.precioIva;

                        Task<bool> _taskSave = Task.Run(() => LogicaCliente.savePedidoDetalle(_infoPedidoDetalle, dbEstatica));
                        _taskSave.Wait();
                        var resultado = _taskSave.Result;
                        if (!resultado)
                        {
                            throw new ArgumentException("No se guardado Detalle pedido");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("No se tiene productos en el carrito");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error: " + ex.Message);
            }
        }

        private void savePago(TBL_PEDIDO _infoPedido, string valorPago, string formaPago, EcommerceEntities dbEstatica)
        {
            try
            {
                TBL_PAGOS _infoPago = new TBL_PAGOS();
                _infoPago.PED_ID = _infoPedido.PED_ID;
                _infoPago.PAG_VALOR = Convert.ToDecimal(valorPago);
                _infoPago.FPA_ID = Convert.ToInt32(formaPago);

                Task<bool> _taskSave = Task.Run(() => LogicaCliente.savePago(_infoPago, dbEstatica));
                _taskSave.Wait();
                var resultado = _taskSave.Result;
                if (!resultado)
                {
                    throw new ArgumentException("No se guardado Pago");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error: " + ex.Message);
            }
        }

        private TBL_PEDIDO savePedido(TBL_CLIENTE _infoCliente, string subtotal, string total, EcommerceEntities dbEstatica)
        {
            try
            {
                TBL_PEDIDO _infoPedido = new TBL_PEDIDO();
                _infoPedido.PED_SUBTOTAL = Convert.ToDecimal(subtotal);
                _infoPedido.PED_TOTAL = Convert.ToDecimal(total);
                _infoPedido.CLI_ID = _infoCliente.CLI_ID;
                _infoPedido.CLI_IDENTIFICACION = _infoCliente.CLI_IDENTIFICACION;
                _infoPedido.PED_IDENTIFICACION = "172341516510001";
                _infoPedido.PED_CLIENTE = _infoCliente.CLI_NOMBRES + " " + _infoCliente.CLI_APELLIDOS;
                _infoPedido.PED_DIRECCION = _infoCliente.CLI_DIRECCION;
                _infoPedido.PED_TELEFONO = _infoCliente.CLI_TELEFONO;

                Task<bool> _taskSave2 = Task.Run(() => LogicaCliente.savePedido(_infoPedido, dbEstatica));
                _taskSave2.Wait();
                var resultado2 = _taskSave2.Result;
                if (!resultado2)
                {
                    throw new ArgumentException("No se guardado Pedido");
                }
                return _infoPedido;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error: " + ex.Message);
            }
        }
        private void limpiar()
        {
            txt_nombres.Text = "";
            txt_apellidos.Text = "";
            txt_fecha_nacimiento.Text = "";
            txt_identificacion.Text = "";
            txt_correo.Text = "";
            txt_telefono.Text = "";
            txt_direccion.Text = "";
        }
    }
}