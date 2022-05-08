using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoFlow.NodeTraversal
{
    public class NodeHandler
    {
        Dictionary<string,HashSet<string>> adjList = new Dictionary<string, HashSet<string>>();
       
        public  NodeHandler(List<Node> nodes)
        {
            foreach (var node in nodes)
            {
                if (!adjList.ContainsKey(node.id))
                    adjList.Add(node.id, new HashSet<string>());
                foreach (var child in node.child_node_ids)
                {
                    if (!adjList[node.id].Contains(child))
                        adjList[node.id].Add(child);
                }
            }
        }
        public int GetTotalNodeCount()
        {
            return adjList.Count;
        }

        public string GetNodeWithMostConnections()
        {
            int maxConnections = Int32.MinValue;
            string resultNode = "";

            foreach(var node in adjList)
            {
                int currentCount = node.Value.Count;
                if (currentCount > maxConnections)
                {
                    maxConnections = currentCount;
                    resultNode = node.Key;
                }
            }
            return resultNode;
        }

    }
}
