using AppCore.IServices;
using AppCore.Services;
using Autofac;
using Domain.Entities;
using Domain.Interfaces;
using Repository.Repository;
using System;
using System.Windows.Forms;

namespace AppAPI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var builder = new ContainerBuilder();
            builder.RegisterType<ApiGetRepository>().As<IModel<API.Root>>();
            builder.RegisterType<WeatherServices>().As<IServices<API.Root>>();
            var container = builder.Build();
            Application.Run(new Form1(container.Resolve<IServices<API.Root>>()));
        }
    }
}
