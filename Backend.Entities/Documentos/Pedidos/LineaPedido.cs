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
    [Table("LineaPedido")]
    public class LineaPedido
    {
        [Key]
        public int IDLineaPedido { get; set; }

        [ForeignKey("Pedido")]
        [Required]
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroPedido { get; set; }

        public decimal ImporteSubtotal { get; set; }

        //Productos
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
