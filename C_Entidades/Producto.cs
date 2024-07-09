using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public int ValorCodigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public Categoria oCategoria { get; set; }
        public int IdMarcaProd { get; set; }
        public MarcaProd oMarcaProd { get; set; }
        public int IdMedida { get; set; }
        public Medida oMedida { get; set; }
        public bool Activo { get; set; }

    }
}
