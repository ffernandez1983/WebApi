using Backend.Entities.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestTest.Controllers.v1
{
  
    public class VMLineaPedido
    {
        public int PedidoId { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroPedido { get; set; }

        public decimal ImporteSubtotal { get; set; }

        public int ProductoId { get; set; }

    }
}
