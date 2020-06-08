using Ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ecommerce.WebASP.LogicaNegocio
{
    public class LogicaCategoria
    {
        private static BDD_ECOMMERCEEntities db = new BDD_ECOMMERCEEntities();

        public static async Task<List<TBL_CATEGORIA>> getAllCat()
        {
            try
            {
                return await db.TBL_CATEGORIA.Where(data => data.CATP_ESTADO == "A").ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al consultar Categoria");
            }
        }

        public static async Task<TBL_CATEGORIA> getAllCatxId(int codigo)
        {
            try
            {
                return await db.TBL_CATEGORIA.Where(data => data.CATP_ESTADO == "A"
                && data.CATP_ID.Equals(codigo)).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al consultar Categoria");
            }
        }

        public static async Task<bool> saveCat(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                bool resultado = false;
                _infoCategoria.CATP_ESTADO = "A";
                _infoCategoria.CAPT_ADD = DateTime.Now;
                db.TBL_CATEGORIA.Add(_infoCategoria);

                //Actualizar Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar Categoria");
            }
        }

        public static async Task<bool> updateCat(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                bool resultado = false;
                _infoCategoria.CAPT_ADD = DateTime.Now;

                //Actualizar Datos
                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al modificar Categoria");
            }
        }
        public static async Task<bool> deleteCat(TBL_CATEGORIA _infoCategoria)
        {
            try
            {
                bool resultado = false;
                _infoCategoria.CAPT_ADD = DateTime.Now;
                _infoCategoria.CATP_ESTADO = "I";

                //Actualizar Datos

                await db.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al eliminar Categoria");
            }
        }

    }
}