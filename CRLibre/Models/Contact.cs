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
        public string tipo_identificacion { get; set; }
        public string numero_identificacion { get; set; }
    }
}