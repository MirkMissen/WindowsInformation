using WindowsService.NetFramework;
using Topshelf;

namespace WindowsInformationApi {

    class Program {

        private const string ServiceName = "OpenFilesRestApi";

        static void Main(string[] args) {

            var port = 8085;

            HostFactory.Run(x => {

                x.AddCommandLineDefinition("port", value => port = int.Parse(value));

                x.Service<RestService>(s => {
                    s.ConstructUsing(() => new RestService(port));
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
