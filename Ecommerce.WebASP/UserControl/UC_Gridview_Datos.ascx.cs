using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecommerce.WebASP.UserControl
{
    public partial class UC_Gridview_Datos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public GridView GridView
        {
            get
            {
                return GridView1;
            }
            set
            {
                GridView1 = value;
            }
        }

        public void loadData(dynamic _lista)
        {
            if (_lista != null && _lista.Count > 0)
            {
                GridView1.DataSource = _lista;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}