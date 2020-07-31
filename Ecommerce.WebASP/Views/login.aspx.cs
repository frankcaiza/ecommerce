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

namespace Ecommerce.WebASP.Views
{
    public partial class login : System.Web.UI.Page
    {
        public string error;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.error = "";
        }
        protected void btn_ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                bool _UserExiste = LogicaSeguridad.verificarUsuarioExistente(txt_user.Text);
                if (_UserExiste)
                {
                    TBL_USUARIO _UserLogin = new TBL_USUARIO();
                    _UserLogin = LogicaSeguridad.obtenerUsuarioLogin(txt_user.Text, txt_password.Text);

                    if (_UserLogin != null)
                    {
                        Task<bool> task2 = Task.Run(() => LogicaSeguridad.resetIntentosUsuario(_UserLogin));
                        task2.Wait();
                        bool reset = task2.Result;
                        if (reset)
                        {
                            Session["Usuario"] = _UserLogin;
                            if (_UserLogin.ROL_ID == 1)
                            {
                                Response.Redirect("~/Views/Admin/Producto/WfmProductoLista.aspx", true);
                            }
                            else
                            {
                                Response.Redirect("~/Views/Public/Principal.aspx", true);
                            }
                        }
                    }
                    else
                    {
                        _UserLogin = LogicaSeguridad.obtenerUsuarioLoginUser(txt_user.Text);

                        Task<int> task4 = Task.Run(() => LogicaSeguridad.falloClaveUsuario(_UserLogin));
                        task4.Wait();
                        int datoIntentos = task4.Result;

                        int Intentos = 3 - datoIntentos;
                        if (Intentos == 0)
                        {
                            this.error = "EL usuario se a bloqueado";
                        }
                        else
                        {
                            this.error = "Contraseña Incorrecta le quedan " + Intentos + " Interntos";
                        }

                    }
                }
                else
                {
                    this.error = "Usuario no existe en el sistema";
                }
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }
    }
}