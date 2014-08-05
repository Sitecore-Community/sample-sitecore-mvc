namespace MVC.Web.App_Start
{
    public static class IocConfig
    {
        private static Castle.Windsor.IWindsorContainer _container;

        public static void SetupIoc()
        {
            _container = new Castle.Windsor.WindsorContainer().Install(Castle.Windsor.Installer.FromAssembly.This());

            var controllerFactory = new MVC.Web.IoC.WindsorControllerFactory(_container.Kernel);

            System.Web.Mvc.ControllerBuilder.Current.SetControllerFactory(controllerFactory);

            //_container.Install(new MVC.Web.IoC.Installers.DefaultInstallers());

        }

    }
}