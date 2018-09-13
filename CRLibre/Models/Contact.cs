using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRLibre.Models
{
    public class Contact
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int tipo_identificacion { get; set; }
        public int numero_identificacion { get; set; }
    }
}