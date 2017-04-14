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
        private readonly bool Directed;

        public Edge (Node from, Node to, bool directed = true)
        {
            From = from;
            To = to;
            Directed = directed;
        }

        public bool IsDirected { get { return Directed; } }
        
        public bool IsIncidentNode(Node node)
        {
            return node == From || node == To;
        }

        public Node OtherNode(Node node)
        {
            if (!IsIncidentNode(node)) throw new ArgumentException();
            if (node == From) return To;
            if (!IsDirected) return From;
            return null;
        }

        public override string ToString()
        {
            return String.Format("({0}, {1})", From.ToString(), To.ToString());
        }
    }
}
