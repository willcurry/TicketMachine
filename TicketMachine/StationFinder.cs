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
                .SelectMany(station => station)
                .Select(station => station.Trim())
                .OrderBy(station => station);
        }

        private char FindNextCharacter(string input, string station)
        {
            return station[input.Length];
        }

        private bool HasMoreCharacters(string input, string station)
        {
            return input.Length < station.Length;
        }

        public Suggestions GetSuggestions(string userInput)
        {
            IEnumerable<string> matchingStations = Stations.Where(station => station.StartsWith(userInput, StringComparison.InvariantCultureIgnoreCase));
            List<char> nextLetters = matchingStations
                .Where(station => HasMoreCharacters(userInput, station))
                .Select(station => FindNextCharacter(userInput, station))
                .ToList();
            return new Suggestions(matchingStations, nextLetters);
        }
    }
}
