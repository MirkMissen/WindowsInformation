using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files.Filter {

    /// <summary>
    /// Defines a file filter argument.
    /// </summary>
    public interface IFileFilter {
        
        /// <summary>
        /// Filters the given file locks.
        /// </summary>
        /// <param name="fileLocks">Defines the list of file locks to filter.</param>
        /// <returns></returns>
        FileLock[] Filter(FileLock[] fileLocks);
        
    }
}
