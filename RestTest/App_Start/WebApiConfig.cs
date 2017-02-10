using Backend.WebAPI.Common.Routing;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using Unity.WebApi;

namespace RestTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Constraints HTTP para versionado de la API
            var constraintsResolver = new DefaultInlineConstraintResolver();
            constraintsResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
         
            config.MapHttpAttributeRoutes(constraintsResolver);

            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //Sets dependency injection for Unity
            UnityConfig.RegisterComponents();
            var container = UnityConfig.GetContainer();
            config.DependencyResolver = new UnityDependencyResolver(container);

            SwaggerConfig.ConfigureSwagger(config);
        }

        /// <summary>
        /// Configura el tipo de respuesta como JSON
        /// </summary>
        /// <param name="config"></param>
        public static void configureJSONResponse(HttpConfiguration config)
        {
            config.Formatters.Add(new JsonMediaTypeFormatter());

            //Sets default JSON response format
            JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Formatting = WebConfigurationManager.AppSettings["entorno"] == "Desarrollo" ? Formatting.Indented : Formatting.None,
                DateFormatString = "dd-MM-yyyy HH:mm:ss",

                //Evitamos referencias cíclicas al serializar a JSON
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            config.Formatters.JsonFormatter.SerializerSettings = jSettings;
        }      
    }
}
