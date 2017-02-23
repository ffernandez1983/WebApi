using Backend.Common.AutoMapperCustomConfiguration;
using Backend.Context;
using Backend.Service;
using Backend.Service.Contracts;
using Backend.WebAPI.Web.Unity;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Web;
using System.Web.Http;
using Unity.WebApi;

namespace RestTest
{
    public static class UnityConfig
    {
        private static UnityContainer container = null;

        /// <summary>
        /// Registra todas las dependencias (Composition Root)
        /// </summary>
        /// 
        public static void RegisterComponents()
        {
            UnityContainer container = new UnityContainer();
            UnityConfig.container = container;
            RegisterTypes();
        }
        private static void RegisterTypes()
        {
            

            //Comunes
            UnityConfig.container.RegisterType<IUnitOfWork, UnitOfWork>(
                new PerRequestLifetimeManager()
            );
          
            container.RegisterType<IOwinContext>(
                new InjectionFactory(c => HttpContext.Current != null ? HttpContext.Current.GetOwinContext() : new OwinContext())
            );


            //Servicios
            //Utilidades
            UnityConfig.container.RegisterType<IAutoMapperCustom, AutoMapperCustom>(
               new PerRequestLifetimeManager()
           );

            //Empresa
            UnityConfig.container.RegisterType<IGetEmpresaService, GetEmpresaService>(
                new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IPostEmpresaService, PostEmpresasService>(
               new PerRequestLifetimeManager()
           );
            UnityConfig.container.RegisterType<IPutEmpresaService, PutEmpresaService>(
              new PerRequestLifetimeManager()
          );

            //Usuario
            UnityConfig.container.RegisterType<IGetUsuarioService, GetUsuarioService>(
                new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IPostUsuarioService, PostUsuarioService>(
               new PerRequestLifetimeManager()
           );
            UnityConfig.container.RegisterType<IPutUsuarioService, PutUsuarioService>(
              new PerRequestLifetimeManager()
          );

            //Clientes
            UnityConfig.container.RegisterType<IGetClientesService, GetClientesService>(
                new PerRequestLifetimeManager()
            );          

            UnityConfig.container.RegisterType<IPostClientesService, PostClientesService>(
               new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IPutClientesService, PutClientesService>(
              new PerRequestLifetimeManager()
           );

            UnityConfig.container.RegisterType<IDeleteClientesService, DeleteClientesService>(
            new PerRequestLifetimeManager()
         );

            //Proveedores
            UnityConfig.container.RegisterType<IGetProveedoresService, GetProveedoresService>(
               new PerRequestLifetimeManager()
           );

            UnityConfig.container.RegisterType<IPostProveedoresService, PostProveedoresService>(
               new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IPutProveedoresService, PutProveedoresService>(
              new PerRequestLifetimeManager()
            );
            UnityConfig.container.RegisterType<IDeleteProveedoresService, DeleteProveedoresService>(
           new PerRequestLifetimeManager()
            );


            //Facturas
            UnityConfig.container.RegisterType<IPostFacturasService, PostFacturasService>(
               new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IGetFacturasService, GetFacturasService>(
              new PerRequestLifetimeManager()
           );

            //Productos
            UnityConfig.container.RegisterType<IPostProductosService, PostProductosService>(
             new PerRequestLifetimeManager()
             );

            UnityConfig.container.RegisterType<IGetProductosService, GetProductosService>(
            new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IPutProductosService, PutProductosService>(
           new PerRequestLifetimeManager()
           );


            UnityConfig.container.RegisterType<IDeleteProductosService, DeleteProductosService>(
             new PerRequestLifetimeManager()
            );

            //Presupuestos
            UnityConfig.container.RegisterType<IPostPresupuestosService, PostPresupuestosService>(
               new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IGetPresupuestosService, GetPresupuestosService>(
               new PerRequestLifetimeManager()
            );

            //Pedidos
            UnityConfig.container.RegisterType<IPostPedidosService, PostPedidosService>(
               new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IGetPedidosService, GetPedidosService>(
              new PerRequestLifetimeManager()
           );

            //Albaranes
            UnityConfig.container.RegisterType<IPostAlbaranesService, PostAlbaranesService>(
               new PerRequestLifetimeManager()
            );

            UnityConfig.container.RegisterType<IGetAlbaranesService, GetAlbaranesService>(
              new PerRequestLifetimeManager()
           );


        }
        /// <summary>
        /// Obtiene el container configurado
        /// </summary>
        /// <returns></returns>
        public static UnityContainer GetContainer()
        {
            if (UnityConfig.container == null)
            {
                throw new ArgumentNullException("Debe registrar antes todas las dependencias mediante RegisterComponents");
            }
            else
            {
                return UnityConfig.container;
            }
        }

    }
}