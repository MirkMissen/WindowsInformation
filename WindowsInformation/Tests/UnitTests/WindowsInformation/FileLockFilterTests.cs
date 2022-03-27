using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WindowsInformation.Files;
using WindowsInformation.Files.Filter;
using WindowsInformation.Files.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Tests.UnitTests.WindowsInformation {

    [TestFixture]
    class FileLockFilterTests {

        private readonly StringComparison defaultStringComparison = StringComparison.InvariantCultureIgnoreCase;

        [Test]
        public void FilterPathsWithMatch() {
            var path = @"c:/test/something.pdf";
            var pathFilter = new FilePathFilter(path, defaultStringComparison);
            
            var l = new FileLock() {
                Path = path
            };

            var array = new FileLock[] {l};

            Assert.IsTrue(pathFilter.Filter(array).Length == 1);
        }

        [Test]
        public void FilterPathsWithNoMatch() {
            var path = @"c:/test/something.pdf";
            var pathFilter = new FilePathFilter(path, defaultStringComparison);

            var l = new FileLock() {
                Path = @"c:/test/somethingElse.pdf"
            };

            var array = new FileLock[] {l};

            Assert.IsTrue(pathFilter.Filter(array).Length == 0);
        }

        [Test]
        public void FilterNameWithExactMatch() {

            var filter = new FileNameFilter("something.pdf", defaultStringComparison);
            var path1 = @"c:/test/something.pdf";
            var path2 = @"\\networkDrive/something.pdf";

            var l1 = new FileLock() {Path = path1};
            var l2 = new FileLock() {Path = path2};

            var array = new FileLock[] {l1, l2};


            Assert.IsTrue(filter.Filter(array).Length == array.Length);
        }
        
        [Test]
        public void FilterNameWithNoMatch() {
            var path = @"c:/test/something.pdf";
            var filter = new FileNameFilter("somethingElse.pdf", defaultStringComparison);

            var l = new FileLock() {
                Path = path
            };

            var array = new FileLock[] {l};

            Assert.IsTrue(filter.Filter(array).Length == 0);
        }

        [TestCase("SoMeThInG.pDf")]
        [TestCase("something.pdf")]
        [TestCase("SOMETHING.PDF")]
        public void IgnoreCase(string fileName) {
            var path1 = @"C:/TEST/SOMETHING.PDF";
            var path2 = @"c:/test/something.pdf";

            var l1 = new FileLock() {Path = path1};
            var l2 = new FileLock() {Path = path2};
            var array = new FileLock[] {l1, l2};
            
            var filter = new FileNameFilter(fileName, StringComparison.CurrentCultureIgnoreCase);

            Assert.IsTrue(filter.Filter(array).Length == array.Length);
        }
        
        [TestCase("something.pdf", true)]
        [TestCase("SoMeThInG.pDf", false)]
        [TestCase("SOMETHING.PDF", false)]
        public void ConsiderCase(string fileName, bool match) {
            var path1 = @"c:/test/something.pdf";
            var l1 = new FileLock() {Path = path1};
            var array = new FileLock[] {l1};
            
            var filter = new FileNameFilter(fileName, StringComparison.InvariantCulture);

            var arrayLength = (match ? 1 : 0);
            Assert.IsTrue(filter.Filter(array).Length == arrayLength);
        }

    }
}
