using System;

namespace RestTest.Controllers.v1
{
    public class VMLineaAlbaran
    {
      
        public int AlbaranId { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroAlbaran { get; set; }

        public decimal ImporteSubtotal { get; set; }

        public int ProductoId { get; set; }

    }
}