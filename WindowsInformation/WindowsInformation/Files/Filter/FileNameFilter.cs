using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files.Filter {

    /// <summary>
    /// Filters arrays of <see cref="FileLock"/> by their name.
    /// </summary>
    public class FileNameFilter : IFileFilter {
        
        /// <summary>
        /// Defines the file name to filter by.
        /// </summary>
        public readonly string FileName;

        /// <summary>
        /// Defines the approach to compare strings.
        /// </summary>
        public readonly StringComparison StringComparison;

        public FileNameFilter(string fileName, StringComparison stringComparison) {
            FileName = fileName;
            StringComparison = stringComparison;
        }

        public FileLock[] Filter(FileLock[] fileLocks) {
            return fileLocks.Where(x => 
                Path.GetFileName(x.Path).Equals(this.FileName, StringComparison)).
                ToArray();
        }
    }
}
