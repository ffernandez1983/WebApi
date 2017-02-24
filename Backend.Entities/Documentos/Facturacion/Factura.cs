using Backend.Entities.DatosCliente;
using Backend.Entities.DatosEmpresa;
using Backend.Entities.DatosProveedor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Facturacion
{   
    [Table("Facturas")]
    public class Factura
    {
        public Factura()
        {
            Albaranes = new HashSet<Albaran>();
            LineasFactura = new HashSet<LineaFactura>();
        }

        [Key]
        [ForeignKey("Albaran")]
        public int IDFactura { get; set; }
        public Albaran Albaran { get; set; }

        [Required]
        public int NumeroFactura { get; set; }

        public DateTime Fecha { get; set; }

        [ForeignKey("Cliente")]        
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [ForeignKey("Proveedor")]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        [ForeignKey("Empresa")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        // Importes
        public decimal ImporteSubtotal { get; set; }

        public decimal Impuesto { get; set; }


        //Otros Documentos      

        public virtual ICollection<Albaran> Albaranes { get; set; }

        //Lineas de Factura
        public virtual ICollection<LineaFactura> LineasFactura { get; set; }
       
    }
}
