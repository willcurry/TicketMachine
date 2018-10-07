using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketMachine
{
    public class Suggestions
    {
        List<char> NextLetters { get; set; }
        public IEnumerable<string> Stations { get; set; }
    }
}
