using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files.Filter {

    /// <summary>
    /// Filters arrays of <see cref="FileLock"/> by their path.
    /// </summary>
    public class FilePathFilter : IFileFilter {

        /// <summary>
        /// Defines the path to filter by.
        /// </summary>
        public readonly string Path;

        /// <summary>
        /// Defines the approach to compare strings.
        /// </summary>
        public readonly StringComparison StringComparison;
        
        public FilePathFilter(string path, StringComparison stringComparison) {
            Path = path;
            StringComparison = stringComparison;
        }
        
        public FileLock[] Filter(FileLock[] locks) {
            return locks.Where(x => x.Path.Equals(this.Path, StringComparison)).ToArray();
        }
    }
}
