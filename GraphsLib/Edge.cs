using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public class Edge
    {
        public readonly Node From;
        public readonly Node To;

        public Edge (Node from, Node to)
        {
            From = from;
            To = to;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", From.ToString(), To.ToString());
        }
    }
}
