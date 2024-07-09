using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class ProductoTienda
    {
        public int IdProductoTienda { get; set; }
        public Producto oProducto { get; set; }
        public Tienda oTienda { get; set; }
        public int Stock { get; set; }
        public decimal PrecioUnidadCompra { get; set; }
        public decimal PrecioUnidadVenta { get; set; }
        public bool Iniciado { get; set; }
    }
}
