using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using WindowsInformation.Files;
using WindowsInformation.Files.Models;

namespace OpenFilesRestApi.Controllers {
    public class FileController : ApiController {

        private const string PathHeader = "Path";
        private const string FileNameHeader = "FileName";

        private readonly FileLockFilter _filter = new FileLockFilter();

        public FileLock[] GetFiles() {

            var files = new OpenFiles().GetFileLocks().ToArray();

            var headers = this.Request.Headers;

            if (headers.TryGetValues(PathHeader, out var pathValues))
            {
                foreach (var element in pathValues) {
                    files.Select(x => _filter.FilterPath(files, element)).ToArray();
                }
            }

            if (headers.TryGetValues(FileNameHeader, out var fileNameValues)) {
                foreach (var element in fileNameValues) {
                    files = files.Where(x => Path.GetFileName(x.Path).Equals(element)).ToArray();
                }
            }

            return files;
        }

    }
}
