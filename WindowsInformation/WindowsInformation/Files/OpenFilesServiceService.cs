using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Policy;
using WindowsInformation.Files.Filter;
using WindowsInformation.Files.Models;
using WindowsInformation.Files.Repository;

namespace WindowsInformation.Files {
    
    public class OpenFilesServiceService : IOpenFilesService {

        private readonly IFileLockRepository _repository;

        public OpenFilesServiceService(IFileLockRepository repository) {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves a collection of all file locks on this machine, which satisfies the filters.
        /// </summary>
        /// <param name="filters">Filters the output.</param>
        /// <returns></returns>
        public FileLock[] GetFileLocks(IFileFilter[] filters) {
            var fileLocks = this._repository.GetFileLocks();

            foreach (var fileLockFilter in filters) {
                fileLocks = fileLockFilter.Filter(fileLocks);
            }

            return fileLocks;
        }
    }
}
