using System;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CT.DependencyInjection.ControllerFactories;
using CT.Utility.Interfaces;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace WNG.NumericSeq.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer _container;
        private static ICTLogger _logger;


        private static void BootstrapContainer()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(_container));
            _logger = _container.Resolve<ICTLogger>();
        }

        protected void Application_Start()
        {
            BootstrapContainer();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError();

            var errorId = Guid.NewGuid().ToString();
            Application[errorId] = error;
            var code = (error is HttpException) ? (error as HttpException).GetHttpCode() : 500;

            Response.Clear();
            Server.ClearError();

            HttpContext.Current.Response.RedirectToRoute(new { controller = "Error", action = code != 404 ? "HttpError" : "Http404", errorId });
        }

        protected void Application_End()
        {
            _container.Dispose();
        }

        private static void LogApplicationException(string exceptionMsg)
        {
            _logger.LogError(exceptionMsg);
        }


    }
}