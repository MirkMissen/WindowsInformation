using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files {
    
    /// <summary>
    /// Defines the contract for retrieving open files.
    /// </summary>
    public interface IOpenFiles {

        /// <summary>
        /// Retrieves a collection of all locks on this machine.
        /// </summary>
        /// <returns></returns>
        IEnumerable<FileLock> GetFileLocks();

    }
}
