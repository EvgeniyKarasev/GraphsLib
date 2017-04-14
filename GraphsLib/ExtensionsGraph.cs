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
            while(true)
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
    }
}
