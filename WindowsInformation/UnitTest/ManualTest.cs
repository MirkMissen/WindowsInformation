
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests {


    [TestClass]
    [Ignore("Requires a windows machine with opened shared files.")]
    public class ManualTest {

        [TestMethod]
        public void GetFileLocks() {

            var locks = new WindowsInformation.Files.OpenFiles().GetFileLocks();
            
            Assert.IsTrue(locks.Any());

        }
    }
}
