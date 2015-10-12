using CT.Utility.Interfaces;
using CT.Utility.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace CT.DependencyInjection.Installers
{
    public abstract class DefaultWindsorInstaller : IWindsorInstaller
    {
        protected virtual string LoggerConfigurationFilePath
        {
            get { return ""; }
        }

        protected virtual string LoggerName
        {
            get { return ""; }
        }
        
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterLogger(container, store);
            RegisterSession(container, store);
            RegisterRepositories(container, store);
            RegisterApplicationServices(container, store);
            AddApplicationSpecificRegistrations(container, store);
        }

        protected virtual void RegisterLogger(IWindsorContainer container, IConfigurationStore store)
        {
            if (string.IsNullOrEmpty(LoggerConfigurationFilePath))
                return;

            container.Register(
                Component
                    .For<ICTLogger>()
                    .UsingFactoryMethod(() => new CTLog4NetLogger(LoggerConfigurationFilePath, LoggerName)));
        }

        protected abstract void RegisterSession(IWindsorContainer container, IConfigurationStore store);

        protected abstract void RegisterRepositories(IWindsorContainer container, IConfigurationStore store);

       

        protected abstract void RegisterApplicationServices(IWindsorContainer container, IConfigurationStore store);

        protected abstract void AddApplicationSpecificRegistrations(IWindsorContainer container, IConfigurationStore store);    
    }
}