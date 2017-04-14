using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public static  class ExtensionsNode
    {
        public static IEnumerable<Node> DepthSearch(this Node startNode)
        {
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();
            stack.Push(startNode);
            while(stack.Count != 0)
            {
                var node = stack.Pop();
                if (visited.Contains(node)) continue;
                visited.Add(node);
                yield return node;
                foreach (var incidentNode in node.IncidentNodes)
                    stack.Push(incidentNode);
            }
        }

        public static IEnumerable<Node> BreadthSearch(this Node startNode)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            queue.Enqueue(startNode);
            while(queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (visited.Contains(node)) continue;
                visited.Add(node);
                yield return node;
                foreach (var incidentNode in node.IncidentNodes)
                    queue.Enqueue(incidentNode);
            }
        }

    }

}
