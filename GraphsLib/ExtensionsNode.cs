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
            visited.Add(startNode);
            while(stack.Count != 0)
            {
                var node = stack.Pop();
                yield return node;
                foreach (var nextNode in node.IncidentNodes.Where(z => !visited.Contains(z)))
                {
                    stack.Push(nextNode);
                    visited.Add(nextNode);
                }

            }
        }

        public static IEnumerable<Node> BreadthSearch(this Node startNode)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            queue.Enqueue(startNode);
            visited.Add(startNode);
            while(queue.Count != 0)
            {
                var node = queue.Dequeue();
                yield return node;
                foreach (var nextNode in node.IncidentNodes.Where(z => !visited.Contains(z)))
                {
                    queue.Enqueue(nextNode);
                    visited.Add(nextNode);
                }
            }
        }

    }

}
