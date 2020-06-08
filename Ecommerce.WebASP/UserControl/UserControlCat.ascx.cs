using Ecommerce.WebASP.LogicaNegocio;
using Ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.WebASP.UserControl
{
    public partial class UserControlCat : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UC_Cargar();
            }
        }

        public int SelectedIndex
        {
            get
            {
                return DropDownList1.SelectedIndex;
            }
            set
            {
                DropDownList1.SelectedIndex = value;
            }
        }

        public DropDownList DropDownList
        {
            get
            {
                return DropDownList1;
            }
            set
            {
                DropDownList1 = value;
            }
        }

        public void UC_Cargar()
        {
            try
            {
                Task<List<TBL_CATEGORIA>> _taskCat = Task.Run(() => LogicaCategoria.getAllCat());
                _taskCat.Wait();
                var _listCat = _taskCat.Result;
                if (_listCat != null && _listCat.Count > 0)
                {
                    //Ordenar linq
                    var data = _listCat.OrderBy(lista => lista.CATP_NOMBRE).ToList();
                   //Insertar dregistro en la lista de categoria en el indice 0
                    data.Insert(0, new TBL_CATEGORIA { CATP_NOMBRE = "Seleccione una Categoria", CATP_ID = 0 });
                    DropDownList1.DataSource = data;
                    DropDownList1.DataTextField = "CATP_NOMBRE";
                    DropDownList1.DataValueField = "CATP_ID";
                    
                    DropDownList1.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw new ArgumentException( "Error" + ex.Message);
            }
        }


    }
}