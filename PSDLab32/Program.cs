using Autofac;
using DomainModel.Infrastructure;
using DomainModel.Service;
using Presenter.Presenters;
using View.Forms;
using View.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSDLab32
{
    static class Program
    {
        private static IContainer _container;
        
        [STAThread]
        static void Main()
        {
            RegisterTypes();

            var presenter = _container.Resolve<Pres>();
            //presenter.view = _container.Resolve<MainForm>();
            //presenter.model = _container.Resolve<Model>();
            try
            {
                presenter.Run();
            }
            catch (Exception e) {
                Application.Exit();
            }
        }

        private static void RegisterTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Model>().As<IModel>();
            builder.RegisterType<MainForm>().As<IView>();
            builder.RegisterType<Pres>();
            _container = builder.Build();
        }
    }
}
