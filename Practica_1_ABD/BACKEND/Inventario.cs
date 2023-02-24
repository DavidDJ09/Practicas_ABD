using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND
{
    public class Inventario
    {
        public Inventario() { }

        public int Id { get; set; }
        public string NombreCorto { get; set; }
        public string Descripcion { get; set;}
        public string Serie { get; set; }
        public string Color { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public string TipoAdquisicion { get; set; }
        public string Observaciones { get; set; }
        public int AREAS_Id { get; set; }
    }
}
