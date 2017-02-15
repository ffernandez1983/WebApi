using System;

namespace RestTest.Controllers.v1
{
    public class VMPresupuesto
    {
       
        public DateTime Fecha { get; set; }

        public int NumeroPresupuesto { get; set; }

        public int ClienteId { get; set; }
     
        public int ProveedorId { get; set; }
      
        public decimal ImporteSubtotal { get; set; }
        public decimal Impuesto { get; set; }

    }
}