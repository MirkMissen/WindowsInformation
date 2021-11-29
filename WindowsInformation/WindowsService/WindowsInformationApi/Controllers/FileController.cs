using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WindowsInformation;
using WindowsInformation.Files;
using WindowsInformation.Files.Models;

namespace WindowsService.NetFramework.Controllers {
    public class FileController : ApiController {

        public IEnumerable<FileLock> GetFiles() {
            return new OpenFiles().GetFileLocks();
        }

        public FileLock GetFileLock([FromUriAttribute] string path) {
            return GetFiles().FirstOrDefault(x => x.Path.Equals(path));
        }

    }
}
