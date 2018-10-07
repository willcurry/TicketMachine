﻿using NUnit.Framework;
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
            Suggestions suggestions = stationFinder.GetSuggestions("Dartford");
            IEnumerable<string> stations = suggestions.Stations;
            Assert.AreEqual(1, stations.Count());
            Assert.AreEqual("Dartford", stations.First());
        }

        [Test]
        public void FindsNextLettersForDartford()
        {
            StationFinder stationFinder = new StationFinder();
            Suggestions suggestions = stationFinder.GetSuggestions("Dartfo");
            var nextLetters = suggestions.NextLetters;
            Assert.AreEqual(1, nextLetters.Count());
            Assert.AreEqual('r', nextLetters.First());
        }

    }
}
