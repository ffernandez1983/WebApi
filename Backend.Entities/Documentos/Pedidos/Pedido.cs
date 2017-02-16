using Backend.Entities.DatosCliente;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities.Facturacion
{
    [Table("Pedidos")]
    public class Pedido
    {
        public Pedido()
        {
            Presupuestos = new HashSet<Presupuesto>();

            LineasPedido = new HashSet<LineaPedido>();

            Albaranes = new HashSet<Albaran>();
        }

        [Key]
        public int IDPedido { get; set; }

        public int NumeroPedido { get; set; }

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

        //Importes
        public decimal ImporteSubtotal { get; set; }

        public decimal Impuesto { get; set; }


        //Documentos
        public virtual ICollection<Presupuesto> Presupuestos { get; set; }

        public virtual ICollection<Albaran> Albaranes { get; set; }

        //Lineas de Pedido
        public virtual ICollection<LineaPedido> LineasPedido { get; set; }
       
    }
}
