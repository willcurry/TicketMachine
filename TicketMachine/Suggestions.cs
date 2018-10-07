using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMachine
{
    public class Suggestions
    {
        public IEnumerable<char> NextLetters { get; private set; }
        public IEnumerable<string> Stations { get; private set; }

        public Suggestions(IEnumerable<string> stations, IEnumerable<char> nextLetters)
        {
            Stations = stations;
            NextLetters = nextLetters;
        }
    }
}
