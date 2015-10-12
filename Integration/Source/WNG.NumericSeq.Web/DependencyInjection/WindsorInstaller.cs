using System.Configuration;
using System.Web.Mvc;
using CT.DependencyInjection.Installers;
using CT.Utility.Helpers;
using Castle.MicroKernel.Registration;
using WNG.ApplicationService.NumericSeq.Interfaces;

namespace WNG.NumericSeq.Web.DependencyInjection
{
    public class WindsorInstaller : DefaultWindsorInstaller
    {
        protected override string LoggerConfigurationFilePath
        {
            get
            {
                string log4NetConfigFile = ConfigurationManager.AppSettings["Log4NetConfigFile"];
                return FileHelper.GetFileApplicationPhysicalPath(log4NetConfigFile);
            }
        }
        protected override void RegisterSession(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {

        }

        protected override void RegisterRepositories(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {

        }

        protected override void RegisterApplicationServices(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                AllTypes
                    .FromAssemblyContaining<INoSeqCalculatorService>()
                    .Pick()
                    .WithServiceAllInterfaces()
                    .LifestyleTransient());

        }

        protected override void AddApplicationSpecificRegistrations(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly().BasedOn<IController>().LifestylePerWebRequest());
        }
    }
}