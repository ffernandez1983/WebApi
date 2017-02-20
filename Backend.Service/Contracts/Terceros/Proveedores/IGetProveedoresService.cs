using Backend.Entities;
using Backend.Entities.DatosCliente;
using Backend.Entities.DatosProveedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Service.Contracts
{
    public interface IGetProveedoresService
    {
        Task<List<Proveedor>> GetTodosProveedores();
    }
}
