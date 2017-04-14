using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public class DirectedGraph : Graph
    {
        public DirectedGraph(int nodesCount) : base(nodesCount)
        { }

        public override Edge Connect(int fromIndex, int toIndex)
        {
            var edge = new Edge(this[fromIndex], this[toIndex]);
            this[fromIndex].Connect(edge);
            return edge;
        }

        public static DirectedGraph MakeGraph(params int[] numbers)
        {
            var graph = new DirectedGraph(numbers.Max() + 1);
            for (int i = 0; i < numbers.Length; i += 2)
                graph.Connect(numbers[i], numbers[i + 1]);
            return graph;
        }
    }
}
