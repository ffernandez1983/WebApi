using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities.Facturacion
{
    [Table("LineaFactura")]
    public class LineaFactura
    {
        [Key]
        public int IDLineaFactura { get; set; }

        [ForeignKey("Factura")]
        [Required]
        public int FacturaId { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroFactura { get; set; }

        public decimal ImporteSubtotal { get; set; }
        public Factura Factura { get; set; }
    }
}
