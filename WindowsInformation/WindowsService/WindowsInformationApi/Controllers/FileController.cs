using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using WindowsInformation.Files;
using WindowsInformation.Files.Models;

namespace OpenFilesRestApi.Controllers {
    public class FileController : ApiController {

        public const string PathHeader = "Path";
        public const string FileNameHeader = "FileName";

        private readonly FileLockFilter _filter = new FileLockFilter();

        private readonly IOpenFiles _openFiles;

        public FileController(IOpenFiles openFiles) {
            _openFiles = openFiles;
        }

        public FileController() {
            _openFiles = new OpenFiles();
        }

        public FileLock[] GetFiles() {

            var fileLocks = _openFiles.GetFileLocks().ToArray();
            var headers = this.Request.Headers;

            if (headers.TryGetValues(PathHeader, out var pathValues))
            {
                foreach (var element in pathValues) {
                    fileLocks = _filter.FilterPath(fileLocks, element).ToArray();
                }
            }

            if (headers.TryGetValues(FileNameHeader, out var fileNameValues)) {
                foreach (var element in fileNameValues) {
                    fileLocks = _filter.FilterFileName(fileLocks, element).ToArray();
                }
            }
            
            return fileLocks;
        }

    }
}
