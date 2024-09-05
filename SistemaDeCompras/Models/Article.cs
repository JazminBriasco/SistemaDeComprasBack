using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeCompras.Models
{
    // Creamos un modelo al igual que en el front para mantener los tipos de datos alineados
    public class Article
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public float precio { get; set; }
        public int deposito { get; set; }
    }
}
