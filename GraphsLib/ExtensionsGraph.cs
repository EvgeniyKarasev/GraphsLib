using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsLib
{
    public static class ExtensionsGraph
    {
        public static List<List<Node>> FindConnectedComponents(this Graph graph)
        {
            var result = new List<List<Node>>();
            var markedNodes = new HashSet<Node>();
            while (true)
            {
                var nextNode = graph.Nodes.Where(node => !markedNodes.Contains(node)).FirstOrDefault();
                if (nextNode == null) break;
                var breadthSearch = nextNode.BreadthSearch().ToList();
                result.Add(breadthSearch);
                foreach (var node in breadthSearch)
                    markedNodes.Add(node);
            }
            return result;
        }


        public static List<Node> FindPath(this Graph graph, int start, int end)
        {
            if (start >= graph.Length || end >= graph.Length) throw new ArgumentException();
            var startNode = graph[start];
            var endNode = graph[end];
            var track = new Dictionary<Node, Node>();
            track[startNode] = null;
            var queue = new Queue<Node>();
            queue.Enqueue(startNode);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                foreach (var nextNode in node.IncidentNodes)
                {
                    if (track.ContainsKey(nextNode)) continue;
                    track[nextNode] = node;
                    queue.Enqueue(nextNode);
                }
                if (track.ContainsKey(endNode)) break;
            }
            if (!track.ContainsKey(endNode)) return null;
            var result = new List<Node>();
            
            var pathItem = endNode;
            while (pathItem != null)
            {
                result.Add(pathItem);
                pathItem = track[pathItem];
            }
            result.Reverse();
            return result;

        }
    }
}
