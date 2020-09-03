using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Policy;
using WindowsInformation.Files.Models;

namespace WindowsInformation.Files {
    
    public class OpenFiles {

        /// <summary>
        /// Defines the path of the 'OpenFile' executable.
        /// </summary>
        private readonly string Executable = @"C:\Windows\SysNative\OpenFiles.exe"; 

        /// <summary>
        /// Defines the argument to query.
        /// 
        /// Parameter List:
        /// /S      system         Specifies the remote system to connect to.
        /// 
        /// /U      [domain\]user  Specifies the user context under which the command should execute.
        /// 
        /// /P      [password]     Specifies the password for the given user context.
        /// 
        /// /FO     format         Specifies the format in which the output is to be displayed.
        ///                         Valid values: "TABLE","LIST","CSV".
        /// 
        /// /NH                    Specifies that the "Column Header" should not be displayed.
        ///                         Valid only for "TABLE" and "CSV" formats.
        /// 
        /// /V                     Specifies that verbose output is displayed
        /// 
        /// /?                     Displays this help message.
        /// 
        /// </summary>
        private const string ARGUMENTS = @"/query /FO CSV /v";

        /// <summary>
        /// New line constant.
        /// </summary>
        private const char NEW_LINE = '\n';

        /// <summary>
        /// Defines the header row of the output.
        /// </summary>
        private const string HEADER = "\"Hostname\",\"ID\",\"Accessed By\",\"Type\",\"#Locks\",\"Open Mode\",\"Open File (Path\\executable)\"";

        /// <summary>
        /// Defines the indices for the data entries.
        /// </summary>
        private enum DataEntries {
            Hostname = 0,
            Id = 1,
            AccessedBy = 2,
            Type = 3,
            Locks = 4,
            OpenMode = 5,
            Path = 6
        }

        public OpenFiles() { }

        public OpenFiles(string openfilesExePath) {
            this.Executable = openfilesExePath;
        }

        /// <summary>
        /// Retrieves a collection of all locks on this machine.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileLock> GetFileLocks() {
            var process = this.GetProcess();
            var rows = GetProcessOutput(process);
            var output = DeMarshalFileLocks(rows.ToList());
            return output;
        }
        
        /// <summary>
        /// Attempts to de-marshal the given data.
        /// </summary>
        /// <param name="data">Defines the data rows of the console.</param>
        /// <returns></returns>
        public IEnumerable<FileLock> DeMarshalFileLocks(List<string> data) {

            // attempts to find the start of the data entries.
            var headerIndex = data.FindIndex((x) => x.Contains(HEADER));

            // Data is right after the header.
            var dataStartIndex = headerIndex + 1;
            
            var output = new List<FileLock>();

            // If the index is 0, there is no header match.
            // Usually, it is when no shared files are available.
            if (dataStartIndex == 0) return output;

            for (int i = dataStartIndex; i < data.Count - 1; i++) {

                var row = data[i];
                row = row.Replace("\"", string.Empty);
                row = row.Replace("\r", string.Empty);

                var entries = row.Split(',');

                var accessedBy = entries[(int) DataEntries.AccessedBy];
                var hostName = entries[(int) DataEntries.Hostname];
                var id = entries[(int)(DataEntries.Id)];
                var type = entries[(int) DataEntries.Type];
                var locks = Convert.ToInt32(entries[(int) DataEntries.Locks]);
                var openMode = entries[(int) DataEntries.OpenMode];
                var path = Path.GetFullPath(entries[(int) DataEntries.Path]);

                Debug.WriteLine(path);

                var fileLock = new FileLock() {
                    AccessedBy = accessedBy,
                    Hostname = hostName,
                    Id = id,
                    Type = type,
                    Locks = locks,
                    OpenMode = openMode,
                    Path = path
                };
                output.Add(fileLock);
            }

            return output;
        }

        /// <summary>
        /// Retrieves the output from the process as rows.
        /// </summary>
        /// <param name="process">Defines the process to retrieve output from.</param>
        /// <returns></returns>
        private string[] GetProcessOutput(Process process) {
            

            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();

            var rows = output.Split(NEW_LINE);
            return rows;
        }

        /// <summary>
        /// Retrieves the process to fetch data from.
        /// </summary>
        /// <returns></returns>
        private Process GetProcess() {
            var process = new Process {
                StartInfo = {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = Executable,
                    Arguments = ARGUMENTS
                }
            };

            process.Start();
            return process;
        }




    }
}
