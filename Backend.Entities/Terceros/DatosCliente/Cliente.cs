using Backend.Entities.Facturacion;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.DatosCliente
{
    public class Cliente
    {
        [Key]
        public int IDCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
