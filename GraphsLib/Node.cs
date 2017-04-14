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
        private readonly List<Edge> edges = new List<Edge>();

        public IEnumerable<Edge> IncidentEdges
        {
            get
            {
                foreach (var edge in edges)
                    yield return edge;
            }
        }

        public IEnumerable<Node> IncidentNodes
        {
            get
            {
                return edges.Select(z => z.OtherNode(this)).Where(z => z != null);
            }
        }

        public void Connect(Edge edge)
        {
            edges.Add(edge);
        }

        public override string ToString()
        {
            return NodeNumber.ToString();
        }
    }
}
