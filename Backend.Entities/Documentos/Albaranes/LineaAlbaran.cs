using Backend.Entities.DatosCliente;
using Backend.Entities.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities.Facturacion
{
    [Table("LineaAlbaran")]
    public class LineaAlbaran
    {
        [Key]
        public int IDLineaAlbaran { get; set; }

        [ForeignKey("Albaran")]
        [Required]
        public int AlbaranId { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroAlbaran { get; set; }

        public decimal ImporteSubtotal { get; set; }
        public Albaran Albaran { get; set; }

        //Productos
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
    }
}
