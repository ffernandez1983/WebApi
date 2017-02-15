using System;

namespace RestTest.Controllers.v1
{
    public class VMLineaFactura
    {

        public int FacturaId { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroFactura { get; set; }

        public decimal ImporteSubtotal { get; set; }

    }
}