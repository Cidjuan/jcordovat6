using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcordovat6.Models
{
    public class Estudiante
    {
        public int codigo { get; set; }
        public string Codigo { get; internal set; }
        public string nombre { get; set; }
        public string Nombre { get; internal set; }
        public string apellido { get; set; }
        public string Apellido { get; internal set; }
        public int edad { get; set; }
        public object Edad { get; internal set; }
    }
}
