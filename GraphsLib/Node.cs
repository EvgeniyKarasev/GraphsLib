using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public class Node
    {
        public readonly int NodeNumber;
        public Node(int number)
        {
            NodeNumber = number;
        }
        private readonly List<Edge> incidentEdges = new List<Edge>();

        public IEnumerable<Edge> IncidentEdges
        {
            get
            {
                foreach (var edge in incidentEdges)
                    yield return edge;
            }
        }

        public IEnumerable<Node> IncidentNodes
        {
            get
            {
                foreach (var edge in incidentEdges)
                    yield return edge.To;
            }
        }

        public override string ToString()
        {
            return NodeNumber.ToString();
        }
    }
}
