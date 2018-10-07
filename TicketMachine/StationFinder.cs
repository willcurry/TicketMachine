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
            int index = input.Length;
            return station.Substring(index, 1)[0];
        }

        public Suggestions GetSuggestions(string userInput)
        {
            IEnumerable<string> matchingStations = Stations.Where(station => station.Contains(userInput));
            List<char> nextLetters = matchingStations
                .Where(station => userInput.Length != station.Length)
                .Select(station => FindCharAfterInput(userInput, station))
                .ToList();
            Suggestions suggestions = new Suggestions(matchingStations, nextLetters);
            return suggestions;
        }
    }
}
