using Backend.Entities.DatosCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entities.Facturacion
{
    [Table("Albaran")]
    public class Albaran
    {
        public Albaran()
        {
            Presupuestos = new HashSet<Presupuesto>();
            Facturas = new HashSet<Factura>();
        }

        [Key]
        public int IDAlbaran { get; set; }

        [Required]
        public int NumeroAlbaran { get; set; }

        public DateTime Fecha { get; set; }

        [ForeignKey("Cliente")]        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Proveedor")]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        //Importes
        public decimal ImporteSubtotal { get; set; }

        public decimal Impuesto { get; set; }
        

        //Otros Documentos        
        public virtual ICollection<Presupuesto> Presupuestos { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }

        //Lineas Albaran

        public virtual ICollection<LineaAlbaran> LineasAlbaran { get; set; }
       
    }
}
