using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleSim
{
    public class PlaceInstructionArguments : InstructionArguments
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Facing Facing { get; set; }
    }
}
