using Evolent.Api.Context;
using Evolent.Api.Models;
using Newtonsoft.Json.Serialization;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApiContrib.IoC.Ninject;

namespace Evolent.Api
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    config.Routes.MapHttpRoute(
        //        name: "DefaultApi",
        //        routeTemplate: "api/{controller}/{id}",
        //        defaults: new { id = RouteParameter.Optional }
        //    );

        //    //By default Web API return XML data  
        //    //We can remove this by clearing the SupportedMediaTypes option as follows  
        //    config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

        //    //Now set the serializer setting for JsonFormatter to Indented to get Json Formatted data  
        //    config.Formatters.JsonFormatter.SerializerSettings.Formatting =
        //        Newtonsoft.Json.Formatting.Indented;

        //    //For converting data in Camel Case  
        //    config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
        //        new CamelCasePropertyNamesContractResolver();  

        //    // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
        //    // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
        //    // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
        //    //config.EnableQuerySupport();

        //    // To disable tracing in your application, please comment out or remove the following line of code
        //    // For more information, refer to: http://www.asp.net/web-api
        //    config.EnableSystemDiagnosticsTracing();
        //}

        public static void Register(HttpConfiguration config)
        {
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //By default Web API return XML data  
            //We can remove this by clearing the SupportedMediaTypes option as follows  
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //Now set the serializer setting for JsonFormatter to Indented to get Json Formatted data  
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;

            //For converting data in Camel Case  
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver();

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            var kernel = new StandardKernel();
            kernel.Bind<IContactRepository>().To<ContactRepository>();
            Register(config, kernel);
        }

        public static void Register(HttpConfiguration config, IKernel kernel)
        {
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("json", "application/json"));
         //   config.Formatters.XmlFormatter.MediaTypeMappings.Add(new UriPathExtensionMapping("xml", "application/xml"));

            

            config.DependencyResolver = new NinjectResolver(kernel);

            config.Routes.MapHttpRoute(
                name: "ControllerWithExt",
                routeTemplate: "api/{controller}.{ext}");
            config.Routes.MapHttpRoute(
                name: "IdWithExt",
                routeTemplate: "api/{controller}/{id}.{ext}");
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }







    }
}
