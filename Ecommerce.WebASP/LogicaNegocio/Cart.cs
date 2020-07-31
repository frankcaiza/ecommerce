using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Ecommerce.WebASP.Models;
using Microsoft.Ajax.Utilities;
using System.Threading.Tasks;

namespace Ecommerce.WebASP.LogicaNegocio
{
    public class Cart
    {
        private static EcommerceEntities db = new EcommerceEntities();
        public int id { get; set; }
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }
        public decimal precioBase { get; set; }
        public decimal precioNormal { get; set; }
        public decimal precioIva { get; set; }
        public string impuestos { get; set; }
        public decimal porcentaje { get; set; }

        public static Cart intanciaCartXProducto(TBL_PRODUCTO _infoPro, string cantidad)
        {
            Cart _addCart = new Cart();
            _addCart.id = _infoPro.PRO_ID;
            _addCart.nombre = _infoPro.PRO_NOMBRE;
            _addCart.imagen = _infoPro.PRO_IMAGEN;
            _addCart.precioNormal = Convert.ToDecimal(_infoPro.PRO_PRECIO_VENTA) * Convert.ToDecimal(cantidad);
            _addCart.precioBase = Convert.ToDecimal(_infoPro.PRO_PRECIO_VENTA);
            _addCart.cantidad = Convert.ToInt16(cantidad);
            _addCart.CartLoad();
            return _addCart;
        }

        public static List<Cart> addCart(List<Cart> _listCart, Cart _addCart)
        {
            int contador = 0;
            if (_listCart.Count > 0 && _listCart != null)
            {
                foreach (Cart _infoCart in _listCart)
                {
                    if (_infoCart.id == _addCart.id)
                    {
                        _infoCart.cantidad = _infoCart.cantidad + _addCart.cantidad;
                        _infoCart.precioNormal = _infoCart.precioNormal + _addCart.precioNormal;
                        _infoCart.precioIva = _infoCart.precioIva + _addCart.precioIva;
                    }
                    else
                    {
                        contador++;
                    }
                }
                if (_listCart.Count == contador)
                {
                    _listCart.Add(_addCart);
                }
            }
            else
            {
                _listCart.Add(_addCart);
            }

            return _listCart;
        }

        public void CartLoad()
        {
            if (this.id > 0 && this.precioNormal > 0)
            {
                var task = Task.Run(() => verificarImpuestos(this.id));
                task.Wait();
                bool existeImpuestos = task.Result;
                decimal porcentaje = 0;
                string impuestos = "";
                if (existeImpuestos)
                {
                    var task2 = Task.Run(() => getAllImpuestosXProducto(this.id));
                    task2.Wait();
                    List<TBL_DETALLE_IMPUESTOS> _infoImpuestos = task2.Result;
                    if (_infoImpuestos.Count > 0 && _infoImpuestos != null)
                    {
                        foreach (TBL_DETALLE_IMPUESTOS _infoImpuesto in _infoImpuestos)
                        {
                            porcentaje = Convert.ToDecimal(_infoImpuesto.TBL_IMPUESTOS.IMP_PORCENTAJE) + porcentaje;
                            impuestos += _infoImpuesto.TBL_IMPUESTOS.IMP_CODIGO_SRI + "<br>";
                        }
                    }
                }
                this.porcentaje = porcentaje;
                this.impuestos = impuestos;
                this.precioIva = (this.precioNormal * this.porcentaje) / 100 + this.precioNormal;
            }

        }

        public static async Task<bool> verificarImpuestos(int idProducto)
        {
            try
            {
                var userData = await db.TBL_DETALLE_IMPUESTOS.FirstOrDefaultAsync(
                    data => data.DIM_ESTADO == "A" && data.PRO_ID == idProducto);
                if (userData != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Error : " + e.Message);
            }
        }

        public static async Task<List<TBL_DETALLE_IMPUESTOS>> getAllImpuestosXProducto(int idProducto)
        {
            try
            {
                return await db.TBL_DETALLE_IMPUESTOS.Where(data => data.DIM_ESTADO == "A" && data.PRO_ID == idProducto).ToListAsync();

            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error : " + ex.Message);
            }
        }
    }
}