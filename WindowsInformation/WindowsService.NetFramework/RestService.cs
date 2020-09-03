using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace WindowsService.NetFramework {
    public class RestService {

        private IDisposable _app;

        public void Start() => this._app = WebApp.Start<Startup>("http://*:8085");

        public void Stop() => _app?.Dispose();

    }
}
