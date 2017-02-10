using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities.Facturacion
{
    [Table("LineaPresupuesto")]
    public class LineaPresupuesto
    {
        [Key]
        public int IDLineaPresupuesto { get; set; }

        [ForeignKey("Presupuesto")]
        [Required]
        public int PresupuestoId { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroPresupuesto { get; set; }

        public decimal ImporteSubtotal { get; set; }
        public Presupuesto Presupuesto { get; set; }
    }
}
