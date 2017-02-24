using System.Web.Http;
using WebActivatorEx;
using RestTest;
using Swashbuckle.Application;
using System.Reflection;
using System;
using System.Net.Http;
using System.Linq;

namespace RestTest
{
    public class SwaggerConfig
    {
        public static void ConfigureSwagger(HttpConfiguration httpConfiguration)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            var myAssembly = Assembly.GetAssembly(typeof(Startup));


            httpConfiguration
                   .EnableSwagger(c =>
                    {
                        c.RootUrl(req => SwaggerConfig.GetRootUrlFromRequest(req));
                        c.SingleApiVersion("v1", "WebApi de RestTest")
                         .Description("Ayuda de la API de RestTest");

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DisableValidator();
                    });
        }
         private static string GetRootUrlFromRequest(HttpRequestMessage req)
        {
            return String.Format(@"{0}/{1}", req.RequestUri.GetLeftPart(UriPartial.Authority), req.RequestUri.Segments.First(a => a != "/").Trim('/'));
        }
    }
}
