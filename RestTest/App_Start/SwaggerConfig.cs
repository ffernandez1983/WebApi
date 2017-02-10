using System.Web.Http;
using WebActivatorEx;
using RestTest;
using Swashbuckle.Application;
using System.Reflection;

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
                      
                        c.SingleApiVersion("v1", "WebApi de RestTest")
                         .Description("Ayuda de la API de RestTest");

                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DisableValidator();
                    });
        }
    }
}
