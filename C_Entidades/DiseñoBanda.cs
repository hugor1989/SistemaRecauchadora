using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class DiseñoBanda
    {
        public int IdDiseñoBanda { get; set; }
        public string Descripcion { get; set; }
        public decimal AnchoBanda { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
