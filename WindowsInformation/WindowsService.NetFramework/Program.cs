using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace WindowsService.NetFramework {


    class Program {

        private const string ServiceName = "WindowsInformationRestApi";

        static void Main(string[] args) {

            HostFactory.Run(x => {
                x.Service<RestService>(s => {
                    s.ConstructUsing(() => new RestService());
                    s.WhenStarted(rs => rs.Start());
                    s.WhenStopped(rs => rs.Stop());
                    s.WhenShutdown(rs => rs.Stop());
                });

                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.SetServiceName(ServiceName);
                x.SetDisplayName(ServiceName);
                x.SetDescription("This service will make file-lock information available to consumers.");
            });
        }
    }
}
