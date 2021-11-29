using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WindowsInformation.Files;
using WindowsInformation.Files.Models;

namespace OpenFilesRestApi.Controllers {
    public class FileController : ApiController {

        public FileLock[] GetFiles() {
            return new OpenFiles().GetFileLocks().ToArray();
        }

        public FileLock[] GetFileLock([FromUri] string path) {
            return GetFiles().Where(x => x.Path.Equals(path)).ToArray();
        }

    }
}
