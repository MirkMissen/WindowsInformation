using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files;
using WindowsInformation.Files.Models;
using NUnit.Framework;
using OpenFilesRestApi.Controllers;

namespace Tests.UnitTests.Controller {
    
    [TestFixture]
    class FileControllerTests {

        private readonly OpenFilesFaked _openFiles;

        private readonly FileController _sut;

        public FileControllerTests() {
            this._openFiles = new OpenFilesFaked();
            this._sut = new FileController(_openFiles);
        }

        [Test]
        public void GetFiles_NoHeaders() {

            this._sut.Request = new HttpRequestMessage();
            //this._sut.Request.Headers.Add();

            var files = _sut.GetFiles();

            Assert.Contains(_openFiles.FileLock01, files);
            Assert.Contains(_openFiles.FileLock02, files);
            Assert.AreEqual(files.Length, 2);
        }

        [Test]
        public void GetFiles_PdfFileHeader() {

            this._sut.Request = new HttpRequestMessage();
            this._sut.Request.Headers.Add(FileController.FileNameHeader, "file.pdf");

            var files = _sut.GetFiles();

            Assert.Contains(_openFiles.FileLock01, files);
            Assert.AreEqual(files.Length, 1);
        }

        [Test]
        public void GetFiles_ExcelFileHeader() {

            this._sut.Request = new HttpRequestMessage();
            this._sut.Request.Headers.Add(FileController.FileNameHeader, "file.xls");

            var files = _sut.GetFiles();

            Assert.Contains(_openFiles.FileLock02, files);
            Assert.AreEqual(files.Length, 1);
        }

        [Test]
        public void GetFiles_PdfPathHeader() {

            this._sut.Request = new HttpRequestMessage();
            this._sut.Request.Headers.Add(FileController.PathHeader, _openFiles.FileLock01.Path);

            var files = _sut.GetFiles();

            Assert.Contains(_openFiles.FileLock01, files);
            Assert.AreEqual(files.Length, 1);

        }

        [Test]
        public void GetFiles_ExcelPathHeader() {

            this._sut.Request = new HttpRequestMessage();
            this._sut.Request.Headers.Add(FileController.PathHeader, _openFiles.FileLock02.Path);

            var files = _sut.GetFiles();

            Assert.Contains(_openFiles.FileLock02, files);
            Assert.AreEqual(files.Length, 1);
        }

        private class OpenFilesFaked : IOpenFiles {

            public readonly FileLock FileLock01;
            public readonly FileLock FileLock02;

            public OpenFilesFaked() {

                FileLock01 = new FileLock() {
                    AccessedBy = "Tester01",
                    Hostname = "Server01",
                    Id = "1",
                    Locks = 1,
                    OpenMode = "Write",
                    Path = "C:/TEST/FILE.PDF",
                    Type = "Unknown"
                };

                FileLock02 = new FileLock() {
                    AccessedBy = "Tester01",
                    Hostname = "Server01",
                    Id = "1",
                    Locks = 1,
                    OpenMode = "Write",
                    Path = "C:/test2/file.xls",
                    Type = "Unknown"
                };
            }

            public IEnumerable<FileLock> GetFileLocks() {
                return new[] {FileLock01, FileLock02};
            }

        }

    }
}
