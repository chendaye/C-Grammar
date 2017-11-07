using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Grammar
{
    public class Chiken : Animal
    {
        public void LayEgg() => WriteLine($"{name} has been agg");

        public Chiken(string newName) : base(newName) { }
    }
}
