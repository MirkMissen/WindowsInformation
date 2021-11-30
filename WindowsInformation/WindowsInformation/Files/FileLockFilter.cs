﻿using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files {

    /// <summary>
    /// Defines common filters for <see cref="FileLock"/>
    /// </summary>
    public class FileLockFilter {
        
        /// <summary>
        /// Ensures the output locks are equal to the path.
        /// </summary>
        /// <returns></returns>
        public FileLock[] FilterPath(FileLock[] locks, string path) {
            return locks.Where(x => x.Path.Equals(path)).ToArray();
        }

        /// <summary>
        /// Ensures the output locks are of all equal to the given file name.
        /// </summary>
        /// <returns></returns>
        public FileLock[] FilterFileName(FileLock[] locks, string name) {
            return locks.Where(x => Path.GetFileName(x.Path).Equals(name)).ToArray();
        }

    }
}