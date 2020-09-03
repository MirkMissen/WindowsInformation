using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsInformation.Files.Models {

    /// <summary>
    /// Defines a file lock definition.
    /// </summary>
    public class FileLock {

        /// <summary>
        /// Defines the Id of this file lock.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Defines the name of the host, where this lock exists, i.e. server.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Defines the user who is locking the file.
        /// </summary>
        public string AccessedBy { get; set; }

        /// <summary>
        /// Defines the type of lock.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Defines the number of locks.
        /// </summary>
        public int Locks { get; set; }

        /// <summary>
        /// Defines the permissions the files is opened with.
        /// </summary>
        public string OpenMode { get; set; }

        /// <summary>
        /// Defines the path of the file being locked.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Empty constructor for marshalling.
        /// </summary>
        public FileLock() {

        }
        
    }
}
