using Backend.Entities.DatosCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Facturacion
{
    [Table("Presupuestos")]

    public class Presupuesto
    {
        public Presupuesto()
        {
            Pedidos = new HashSet<Pedido>();
        }

        [Key]
        public int IDPresupuesto { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroPresupuesto { get; set; }

        //Terceros
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
        public virtual ICollection<Pedido> Pedidos { get; set; }        

        //Lineas
        public virtual ICollection<LineaPresupuesto> LineasPresupuesto { get; set; }
       
    }
}
