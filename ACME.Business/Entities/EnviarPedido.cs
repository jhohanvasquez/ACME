using System;
using System.Collections.Generic;
using System.Text;

namespace ACME.Business.Entities
{
    public class EnviarPedido
    {
        public string numPedido { get; set; }
        public string cantidadPedido { get; set; }
        public string codigoEAN { get; set; }
        public string nombreProducto { get; set; }
        public string numDocumento { get; set; }
        public string direccion { get; set; }

        public class Root
        {
            public EnviarPedido enviarPedido { get; set; }
        }


    }
}
