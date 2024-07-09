using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class DetalleVenta
    {
        public int Cantidad { get; set; }
        public string NombreProducto { get; set; }
        public float PrecioUnidad { get; set; }
        public string TextoPrecioUnidad { get; set; }
        public float ImporteTotal { get; set; }
        public string TextoImporteTotal { get; set; }
    }
}
