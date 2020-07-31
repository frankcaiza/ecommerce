using Ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ecommerce.WebASP.LogicaNegocio
{
    public class LogicaPagos
    {

        private static EcommerceEntities db = new EcommerceEntities();

        public static async Task<List<TBL_FORMA_PAGO>> getAllPagos()
        {
            try
            {
                return await db.TBL_FORMA_PAGO.Where(data => data.FPA_ESTADO == "A").ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al consultar Categoria");
            }
        }

    }
}