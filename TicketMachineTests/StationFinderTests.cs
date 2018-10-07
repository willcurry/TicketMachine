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
        StationFinder stationFinder; 

        [SetUp]
        public void SetupBeforeEachTest()
        {
            stationFinder = new StationFinder();
        }

        [Test]
        public void SuggestsDartford()
        {
            Suggestions suggestions = stationFinder.GetSuggestions("Dartford");
            IEnumerable<string> stations = suggestions.Stations;
            Assert.AreEqual(1, stations.Count());
            Assert.AreEqual("Dartford", stations.First());
        }

        [Test]
        public void SuggestsNextLettersForDartford()
        {
            Suggestions suggestions = stationFinder.GetSuggestions("Dartfo");
            List<char> nextLetters = suggestions.NextLetters;
            Assert.AreEqual(1, nextLetters.Count());
            Assert.AreEqual('r', nextLetters.First());
        }

        [Test]
        public void SuggestsNextLettersAndStationsForDart()
        {
            List<string> expectedStations = new List<string>();
            expectedStations.Add("Dartford");
            expectedStations.Add("Darton");
            List<char> expectedLetters = new List<char>();
            expectedLetters.Add('f');
            expectedLetters.Add('o');
            Suggestions suggestions = stationFinder.GetSuggestions("Dart");
            CollectionAssert.AreEqual(expectedStations, suggestions.Stations);
            CollectionAssert.AreEqual(expectedLetters, suggestions.NextLetters);
        }

        [Test]
        public void ReturnsSuggestionsInAlphabeticalOrder()
        {
            List<string> expectedStations = new List<string>();
            expectedStations.Add("Dumbarton Central");
            expectedStations.Add("Dumbarton East");
            expectedStations.Add("Dumbreck");
            expectedStations.Add("Dumfries");
            expectedStations.Add("Dumpton Park");
            Suggestions suggestions = stationFinder.GetSuggestions("Dum");
            CollectionAssert.AreEqual(expectedStations, suggestions.Stations);
        }
    }
}
