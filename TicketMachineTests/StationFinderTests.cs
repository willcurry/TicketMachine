using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketMachine;

namespace TicketMachineTests
{
    [TestFixture]
    public class StationFinderTests
    {
        [Test]
        public void FindsDartford()
        {
            StationFinder stationFinder = new StationFinder();
            Assert.AreEqual(stationFinder.GetSuggestions("D"), "Dartford");
        }
    }
}
