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
        private static EcommerceEntities db = new EcommerceEntities();


        public static async Task<List<TBL_PRODUCTO>> getAllProduct()
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_ESTADO == "A").ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
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

                throw new ArgumentException("Error : " + ex.Message);
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
                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static async Task<List<TBL_PRODUCTO>> searchProductxCod(string codigo)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_ESTADO == "A"
                && data.PRO_CODIGO.StartsWith(codigo)).ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static async Task<List<TBL_PRODUCTO>> searchProductxNom(string nombre)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_ESTADO == "A"
                && data.PRO_NOMBRE.StartsWith(nombre)).ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static async Task<List<TBL_PRODUCTO>> searchProductxCat(string categoria)
        {
            try
            {
                return await db.TBL_PRODUCTO.Where(data => data.PRO_ESTADO == "A"
                && data.TBL_CATEGORIA.CAT_NOMBRE.StartsWith(categoria)
                ).ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static int getNextSequence()
        {
            try
            {
                var query = db.Database.SqlQuery<int>("SELECT NEXT VALUE FOR sq_ProductoId");
                var task = query.SingleAsync();
                int valorSequence = task.Result;

                return valorSequence;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);
            }
        }

        public static async Task<bool> saveProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_ID = getNextSequence();
                _infoProducto.PRO_ESTADO = "A";
                _infoProducto.PRO_FECHA_CREACION = DateTime.Now;
                db.TBL_PRODUCTO.Add(_infoProducto);

                //Actualizar Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static async Task<bool> updateProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_FECHA_CREACION = DateTime.Now;

                //Actualizar Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }
        public static async Task<bool> deleteProduct(TBL_PRODUCTO _infoProducto)
        {
            try
            {
                bool resultado = false;
                _infoProducto.PRO_FECHA_CREACION = DateTime.Now;
                _infoProducto.PRO_ESTADO = "I";

                //Actualizar Datos

                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }


    }
}