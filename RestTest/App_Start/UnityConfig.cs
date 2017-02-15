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

            //Facturas

            UnityConfig.container.RegisterType<IPostFacturasService, PostFacturasService>(
               new PerRequestLifetimeManager()
            );
            UnityConfig.container.RegisterType<IPutClientesService, PutClientesService>(
               new PerRequestLifetimeManager()
            );


            //Productos
            UnityConfig.container.RegisterType<IPostProductosService, PostProductosService>(
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