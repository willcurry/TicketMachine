using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMachine
{
    public class Suggestions
    {
        public List<char> NextLetters { get; private set; }
        public IEnumerable<string> Stations { get; private set; }

        public Suggestions(IEnumerable<string> stations, List<char> nextLetters)
        {
            Stations = stations;
            NextLetters = nextLetters;
        }
    }
}
