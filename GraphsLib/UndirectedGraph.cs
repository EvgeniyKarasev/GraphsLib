using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    class UndirectedGraph : Graph
    {
        public UndirectedGraph(int nodesCount) : base(nodesCount)
        {
        }

        public override Edge Connect(int fromIndex, int toIndex)
        {
            var edge = new Edge(this[fromIndex], this[toIndex], false);
            this[fromIndex].Connect(edge);
            this[toIndex].Connect(edge);
            return edge;
        }

        public static UndirectedGraph MakeGraph(params int[] numbers)
        {
            var graph = new UndirectedGraph(numbers.Max() + 1);
            for (int i = 0; i < numbers.Length; i += 2)
                graph.Connect(numbers[i], numbers[i + 1]);
            return graph;
        }
    }
}
