using System;
namespace RestTest.Controllers.v1
{
    public class VMLineaPresupuesto
    {

        public int PresupuestoId { get; set; }

        public DateTime Fecha { get; set; }

        public int NumeroPresupuesto { get; set; }

        public decimal ImporteSubtotal { get; set; }

        public int ProductoId { get; set; }

    }
}