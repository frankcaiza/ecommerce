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
    public partial class Producto : System.Web.UI.Page
    {
        public TBL_PRODUCTO _infoPro = new TBL_PRODUCTO();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["cod"] != null)
            {
                int idProducto = Convert.ToInt32(Request["cod"].ToString());
                loadProducto(idProducto);
            }
            else
            {
                Response.Redirect("Principal.aspx", true);
            }
        }

        private void loadProducto(int idProducto)
        {
            var task = Task.Run(() => LogicaProducto.getAllProductxId(idProducto));
            task.Wait();
            _infoPro = task.Result;
        }
    }
}