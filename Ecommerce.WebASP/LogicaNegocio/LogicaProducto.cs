using Ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ecommerce.WebASP.LogicaNegocio
{
    public class LogicaProducto
    {
        private static BDD_ECOMMERCEEntities db = new BDD_ECOMMERCEEntities();

        public static async Task<List<TBL_PRODUCTO>> getAllProduct()
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_ESTADO == "A").ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al consultar producto");
            }
        }

        public static async Task<TBL_PRODUCTO> getAllProductxId(int codigo)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_ESTADO == "A"
                && data.PRO_ID.Equals(codigo)).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al consultar producto");
            }
        }

        public static async Task<TBL_PRODUCTO> getAllProductxCod(string codigo)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_ESTADO == "A"
                && data.PRO_CODIGO.Equals(codigo)).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al consultar producto");
            }
        }

        public static async Task<bool> saveProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_ESTADO = "A";
                _infoProducto.PRO_ADD = DateTime.Now;
                db.TBL_PRODUCTO.Add(_infoProducto);

                //Actualizar Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar producto");
            }
        }

        public static async Task<bool> updateProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_ADD = DateTime.Now;
                               
                //Actualizar Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al modificar producto");
            }
        }
        public static async Task<bool> deleteProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_ADD = DateTime.Now;
                _infoProducto.PRO_ESTADO = "I";

                //Actualizar Datos

                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al eliminar producto");
            }
        }

    }
}