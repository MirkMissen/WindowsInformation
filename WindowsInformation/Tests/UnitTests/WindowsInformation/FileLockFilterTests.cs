using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files;
using WindowsInformation.Files.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tests.UnitTests.WindowsInformation {

    [TestFixture]
    class FileLockFilterTests {

        private readonly FileLockFilter _sut = new FileLockFilter();

        [Test]
        public void FilterPathsWithMatch() {
            var path = @"c:/test/something.pdf";
            
            var l = new FileLock() {
                Path = path
            };

            var array = new FileLock[] {l};

            Assert.IsTrue(_sut.FilterPath(array, path).Length == 1);
        }

        [Test]
        public void FilterPathsWithNoMatch() {
            var path = @"c:/test/something.pdf";

            var l = new FileLock() {
                Path = @"c:/test/somethingElse.pdf"
            };

            var array = new FileLock[] {l};

            Assert.IsTrue(_sut.FilterPath(array, path).Length == 0);
        }

        [Test]
        public void FilterNameWithExactMatch() {
            var path1 = @"c:/test/something.pdf";
            var path2 = @"\\networkDrive/something.pdf";

            var l1 = new FileLock() {Path = path1};
            var l2 = new FileLock() {Path = path2};

            var array = new FileLock[] {l1, l2};

            Assert.IsTrue(_sut.FilterFileName(array, "something.pdf").Length == array.Length);
        }
        
        [Test]
        public void FilterNameWithNoMatch() {
            var path = @"c:/test/something.pdf";

            var l = new FileLock() {
                Path = path
            };

            var array = new FileLock[] {l};

            Assert.IsTrue(_sut.FilterFileName(array, "somethingElse.pdf").Length == 0);
        }



    }
}
