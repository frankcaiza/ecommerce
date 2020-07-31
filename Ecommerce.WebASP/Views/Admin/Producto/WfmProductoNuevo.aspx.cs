using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ecommerce.WebASP.Models;
using System.Threading.Tasks;
using Ecommerce.WebASP.LogicaNegocio;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Ajax.Utilities;
using System.Reflection;

namespace Ecommerce.WebASP.WebForm.Administrador.Prodcuto
{
    public partial class WfmProductoNuevo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int idProducto = Convert.ToInt32(Request["cod"].ToString());
                    loadProducto(idProducto);
                }
            }
        }

        private void loadProducto(int idProducto)
        {
            TBL_PRODUCTO _infoProducto = new TBL_PRODUCTO();
            var task = Task.Run(() => LogicaProducto.getAllProductxId(idProducto));
            task.Wait();
            _infoProducto = task.Result;
            if (_infoProducto != null)
            {
                lblId.Text = _infoProducto.PRO_ID.ToString();
                lblImg.Text = _infoProducto.PRO_IMAGEN.ToString();
                UC_CAT1.DropDownList.SelectedValue = _infoProducto.CAT_ID.ToString();
                txtNom.Text = _infoProducto.PRO_NOMBRE;
                txtDes.Text = _infoProducto.PRO_DESCRIPCION;
                txtPC.Text = _infoProducto.PRO_PRECIO_COMPRA.ToString();
                txtPV.Text = _infoProducto.PRO_PRECIO_VENTA.ToString();
                txtCod.Text = _infoProducto.PRO_CODIGO.ToString();
                txtSMin.Text = _infoProducto.PRO_STOCK_MINIMO.ToString();
                txtSMax.Text = _infoProducto.PRO_STOCK_MAXIMO.ToString();
               
            }
        }

        private void limpiar()
        {
            txtCod.Text = "";
            txtDes.Text = "";
            txtNom.Text = "";
            txtPC.Text = "";
            txtPV.Text = "";
            txtSMax.Text = "";
            txtSMin.Text = "";
            lblId.Text = "";
            lblImg.Text = "";
            lblMessage.Text = "";
            UC_CAT1.DropDownList.SelectedIndex = 0;


        }



        private void saveProduct()
        {
            try
            {
                TBL_PRODUCTO _infoPro = new TBL_PRODUCTO();

                _infoPro.CAT_ID = Convert.ToInt32(UC_CAT1.DropDownList.SelectedValue);
                _infoPro.PRO_CODIGO = txtCod.Text;
                _infoPro.PRO_DESCRIPCION = txtDes.Text;
                _infoPro.PRO_NOMBRE = txtNom.Text;
                var d = fuimagen;
                if (fuimagen.HasFile)
                {
                    fuimagen.SaveAs(Server.MapPath("~/img") + "//" + fuimagen.FileName);
                    _infoPro.PRO_IMAGEN = "~/img/" + fuimagen.FileName;
                }

                _infoPro.PRO_PRECIO_COMPRA = Convert.ToDecimal(txtPC.Text);
                _infoPro.PRO_PRECIO_VENTA = Convert.ToDecimal(txtPV.Text);
                _infoPro.PRO_STOCK_MINIMO = Convert.ToInt32(txtSMin.Text);
                _infoPro.PRO_STOCK_MAXIMO = Convert.ToInt32(txtSMax.Text);

                Task<bool> _taskSave = Task.Run(() => LogicaProducto.saveProduct(_infoPro));
                _taskSave.Wait();
                var resultado = _taskSave.Result;
                if (resultado)
                {
                    lblMessage.Text = "Registro guardado";
                    Response.Redirect("WfmProductoNuevo.aspx?cod=" + _infoPro.PRO_ID, true);
                }
                else
                {
                    lblMessage.Text = "No se guardado";
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.Message + "linea: " + ex.Source;
            }
        }

        private void updateProducto()
        {
            try
            {
                TBL_PRODUCTO _infoPro = new TBL_PRODUCTO();
                var task = Task.Run(() => LogicaProducto.getAllProductxId(int.Parse(lblId.Text)));
                task.Wait();
                _infoPro = task.Result;
                if (_infoPro != null)
                {
                    _infoPro.PRO_ID = int.Parse(lblId.Text);
                    _infoPro.CAT_ID = Convert.ToInt32(UC_CAT1.DropDownList.SelectedValue);
                    _infoPro.PRO_CODIGO = txtCod.Text;
                    _infoPro.PRO_DESCRIPCION = txtDes.Text;
                    _infoPro.PRO_NOMBRE = txtNom.Text;
                    var d = fuimagen;
                    if (fuimagen.HasFile)
                    {
                        fuimagen.SaveAs(Server.MapPath("~/img") + "//" + fuimagen.FileName);
                        _infoPro.PRO_IMAGEN = "~/img/" + fuimagen.FileName;
                    }

                    _infoPro.PRO_PRECIO_COMPRA = Convert.ToDecimal(txtPC.Text);
                    _infoPro.PRO_PRECIO_VENTA = Convert.ToDecimal(txtPV.Text);
                    _infoPro.PRO_STOCK_MINIMO = Convert.ToInt32(txtSMin.Text);
                    _infoPro.PRO_STOCK_MAXIMO = Convert.ToInt32(txtSMax.Text);

                    Task<bool> _taskSave = Task.Run(() => LogicaProducto.updateProduct(_infoPro));
                    _taskSave.Wait();
                    var resultado = _taskSave.Result;
                    if (resultado)
                    {
                        lblMessage.Text = "Registro guardado";
                        Response.Redirect("WfmProductoNuevo.aspx?cod=" + _infoPro.PRO_ID, true);
                    }
                    else
                    {
                        lblMessage.Text = "No se guardado";
                    }
                }
            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.Message + "linea: " + ex.Source;
            }
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            limpiar();
        }

        protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblId.Text))
            {
                updateProducto();
               // Response.Redirect("WfmProductoLista.aspx", true);
            }
            else
            {
                saveProduct();
               // limpiar();
                // Response.Redirect("WfmProductoLista.aspx", true);
            }
       
        }

        protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("WfmProductoLista.aspx", true);
        }


    }
}