using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files.Repository {

    /// <summary>
    /// Defines the repository that can fetch file locks.
    /// </summary>
    public interface IFileLockRepository {

        /// <summary>
        /// Retrieves all file locks.
        /// </summary>
        /// <returns></returns>
        FileLock[] GetFileLocks();

    }
}
