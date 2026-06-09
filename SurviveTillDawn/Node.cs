using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurviveTillDawn
{
    internal class Node
    {
        public int X { get; }
        public int Y { get; }
        public bool Walkable { get; set; }
        public Node Parent { get; set; }
        public int GCost { get; set; } // Cost from start node
        public int HCost { get; set; } // Heuristic cost to target node
        public int FCost => GCost + HCost; // Total cost

        public Node(int x, int y, bool walkable)
        {
            X = x;
            Y = y;
            Walkable = walkable;
        }

    }
}
