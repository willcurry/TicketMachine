using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Suggestions GetSuggestions(string userInput)
        {
            IEnumerable<string> matchingStations = Stations.Where(station => station.Contains(userInput));
            Suggestions suggestions = new Suggestions(matchingStations);
            return suggestions;
        }
    }
}
