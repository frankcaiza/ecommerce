using Ecommerce.WebASP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ecommerce.WebASP.LogicaNegocio
{
    public class LogicaCliente
    {
        private static EcommerceEntities db = new EcommerceEntities();



        public static async Task<bool> saveCliente(TBL_CLIENTE _infoCliente, EcommerceEntities dbEstatica)
        {
            try
            {
                bool resultado = false;
                _infoCliente.CLI_ESTADO = "A";
                _infoCliente.CLI_FECHA_CREACION = DateTime.Now;
                dbEstatica.TBL_CLIENTE.Add(_infoCliente);

                //Actualizar Datos
                await dbEstatica.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static async Task<bool> savePedido(TBL_PEDIDO _infoPedido, EcommerceEntities dbEstatica)
        {
            try
            {
                bool resultado = false;
                _infoPedido.PED_ESTADO = "A";
                _infoPedido.PED_FECHA_CREACION = DateTime.Now;
                _infoPedido.PED_FECHA = DateTime.Now;
                _infoPedido.PED_NUMERO = _infoPedido.CLI_ID;
                dbEstatica.TBL_PEDIDO.Add(_infoPedido);

                //Actualizar Datos
                await dbEstatica.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static async Task<bool> savePedidoDetalle(TBL_DETALLE_PEDIDO _infoPedidoDetalle, EcommerceEntities dbEstatica)
        {
            try
            {
                bool resultado = false;
                _infoPedidoDetalle.DEP_ESTADO = "A";
                _infoPedidoDetalle.PED_FECHA = DateTime.Now;
                dbEstatica.TBL_DETALLE_PEDIDO.Add(_infoPedidoDetalle);

                //Actualizar Datos
                await dbEstatica.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static async Task<bool> savePago(TBL_PAGOS _infoPago, EcommerceEntities dbEstatica)
        {
            try
            {
                bool resultado = false;
                _infoPago.PAG_ESTADO = "A";
                _infoPago.PAG_FECHA_CREACION = DateTime.Now;
                _infoPago.PAG_FECHA = DateTime.Now;
                _infoPago.PED_FECHA = DateTime.Now;
                dbEstatica.TBL_PAGOS.Add(_infoPago);

                //Actualizar Datos
                await dbEstatica.SaveChangesAsync();
                resultado = true;
                return resultado;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }

        public static async Task<bool> updateCliente(TBL_CLIENTE _infoCliente)
        {
            try
            {
                bool resultado = false;
                _infoCliente.CLI_FECHA_CREACION = DateTime.Now;

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
        public static async Task<bool> deleteCliente(TBL_CLIENTE _infoCliente)
        {
            try
            {
                bool resultado = false;
                _infoCliente.CLI_FECHA_CREACION = DateTime.Now;
                _infoCliente.CLI_ESTADO = "I";

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