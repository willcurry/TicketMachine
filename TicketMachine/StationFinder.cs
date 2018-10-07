using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicketMachine
{
    public class StationFinder
    {
        private IEnumerable<string> Stations;
        public StationFinder()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "stations.txt");
            Stations = File.ReadLines(path)
                .Select(station => station.Split(','))
                .SelectMany(i => i)
                .Select(station => station.Trim());
        }

        private char FindCharAfterInput(string input, string station)
        {
            return station[input.Length];
        }

        public Suggestions GetSuggestions(string userInput)
        {
            IEnumerable<string> matchingStations = Stations.Where(station => station.Contains(userInput));
            List<char> nextLetters = matchingStations
                .Where(station => userInput.Length < station.Length)
                .Select(station => FindCharAfterInput(userInput, station))
                .ToList();
            return new Suggestions(matchingStations, nextLetters);
        }
    }
}
