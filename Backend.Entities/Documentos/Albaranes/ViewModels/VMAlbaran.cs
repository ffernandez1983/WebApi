using System;

namespace RestTest.Controllers.v1
{
    public class VMAlbaran
    {

        public int NumeroAlbaran { get; set; }

        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }

        public int ProveedorId { get; set; }

        public int EmpresaId { get; set; }

        public decimal ImporteSubtotal { get; set; }

        public decimal Impuesto { get; set; }

    }
}