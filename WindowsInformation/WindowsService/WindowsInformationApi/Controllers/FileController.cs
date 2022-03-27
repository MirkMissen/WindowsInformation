using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;
using WindowsInformation.Files;
using WindowsInformation.Files.Filter;
using WindowsInformation.Files.Models;
using WindowsInformation.Files.Repository;

namespace OpenFilesRestApi.Controllers {
    public class FileController : ApiController {

        public const string PathHeader = "Path";
        public const string FileNameHeader = "FileName";

        /// <summary>
        /// Defines the method used to compare files.
        /// </summary>
        public readonly StringComparison StringComparison = StringComparison.InvariantCultureIgnoreCase;
        
        private readonly IOpenFilesService _openFilesService;

        public FileController(IOpenFilesService openFilesService) {
            _openFilesService = openFilesService;
        }

        public FileController() {
            var temp = @"C:\Windows\System32\openfiles.exe";
            this._openFilesService = new OpenFilesServiceService(new OpenFilesExeRepository(temp));
        }

        public FileLock[] GetFiles() {

            var headers = this.Request.Headers;
            var filters = new List<IFileFilter>();

            if (headers.TryGetValues(PathHeader, out var pathValues)) {
                foreach (var pathValue in pathValues) {
                    filters.Add(new FilePathFilter(pathValue, this.StringComparison));
                }
            }

            if (headers.TryGetValues(FileNameHeader, out var fileNameValues)) {
                foreach (var fileName in fileNameValues) {
                    filters.Add(new FileNameFilter(fileName, this.StringComparison));
                }
            }

            var fileLocks = _openFilesService.GetFileLocks(filters.ToArray());
            return fileLocks;
        }

    }
}
