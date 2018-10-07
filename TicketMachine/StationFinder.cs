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

        public IEnumerable<string> GetSuggestions(string userInput)
        {
            return Stations.Where(station => station.Contains(userInput));
        }
    }
}
