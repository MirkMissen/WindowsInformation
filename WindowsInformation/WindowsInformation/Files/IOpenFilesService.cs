using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files.Filter;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files {
    
    /// <summary>
    /// Defines the contract for retrieving open files.
    /// </summary>
    public interface IOpenFilesService {
        
        /// <summary>
        /// Retrieves a collection of all file locks on this machine, which satisfies the filters.
        /// </summary>
        /// <param name="filters">Defines of the filter the output.</param>
        /// <returns></returns>
        FileLock[] GetFileLocks(IFileFilter[] filters);

    }
}
