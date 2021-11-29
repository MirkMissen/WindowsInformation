using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace WindowsService.NetFramework {
    public class RestService {
        
        private readonly string _address;

        private IDisposable _app;

        public void Start() => this._app = WebApp.Start<Startup>(new StartOptions(_address));

        public void Stop() => _app?.Dispose();


        public RestService(int port) {
            _address = $"http://*:{port}";
        }

    }
}
