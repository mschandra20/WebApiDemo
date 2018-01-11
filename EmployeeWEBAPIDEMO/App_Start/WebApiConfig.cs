using System.Web.Http;

namespace EmployeeWEBAPIDEMO
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;

            //config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = 
            //    new CamelCasePropertyNamesContractResolver();

            // config.Formatters.Remove(config.Formatters.XmlFormatter);

            //var jsonpFormatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0,jsonpFormatter);//At zero index we are inserting the above object

            //EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            //config.EnableCors(cors);

        }
    }
}
