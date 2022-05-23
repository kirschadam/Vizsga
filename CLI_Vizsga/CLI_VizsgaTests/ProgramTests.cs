using Microsoft.VisualStudio.TestTools.UnitTesting;
using CLI_Vizsga;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI_Vizsga.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AtloTest()
        {
            Assert.Equals(Math.Sqrt(2*2 + 5*5), Program.Atlo(2,5));
        }

        [TestMethod()]
        public void TeruletTest()
        {
            Assert.Equals(2 * 5, Program.Terulet(2, 5));
        }

        [TestMethod()]
        public void KeruletTest()
        {
            Assert.Equals(2*(2 + 5), Program.Kerulet(2, 5));
        }
    }
}