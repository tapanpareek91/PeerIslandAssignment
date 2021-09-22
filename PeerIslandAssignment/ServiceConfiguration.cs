using Microsoft.Extensions.DependencyInjection;
using PeerIslandAssignment.Interface;
using PeerIslandAssignment.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeerIslandAssignment
{
    /// <summary>The Service Configuration class.</summary>
    public static class ServiceConfiguration
    {
        public static IServiceProvider RegisterServices()
        {
            var services = new ServiceCollection();

            // services
            services.AddScoped<IUserInterface, UserInterface>();
            services.AddScoped<IXmlHelper, XmlHelper>();
            services.AddScoped<Program>();

            return services.BuildServiceProvider();
        }

        public static void DisposeServices(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                return;
            }

            if (serviceProvider is IDisposable sp)
            {
                sp.Dispose();
            }
        }
    }
}
