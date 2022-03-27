using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files.Repository {

    /// <summary>
    /// Defines a faked file repository.
    /// </summary>
    public class FakedFileRepository : IFileLockRepository {

        /// <summary>
        /// Defines the faked file locks.
        /// </summary>
        private readonly FileLock[] _fileLocks;

        /// <summary>
        /// Configures this repository.
        /// </summary>
        /// <param name="fileLocks"></param>
        public FakedFileRepository(params FileLock[] fileLocks) {
            _fileLocks = fileLocks;
        }

        /// <summary>
        /// Retrieves the faked file locks.
        /// </summary>
        /// <returns></returns>
        public FileLock[] GetFileLocks() {
            return this._fileLocks;
        }
    }
}
