using Backend.Entities.Facturacion;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Entities.Productos
{
    public class Producto
    {
        [Key]
        public int IDProducto { get; set; }

        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }

        public string Precio { get; set; }
       
        public virtual ICollection<LineaPresupuesto> LineasPresupuesto { get; set; }
        public virtual ICollection<LineaPedido> LineasPedido { get; set; }
        public virtual ICollection<LineaAlbaran> LineasAlbaran { get; set; }
    }
}
