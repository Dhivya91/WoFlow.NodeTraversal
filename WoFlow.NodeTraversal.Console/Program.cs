using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoFlow.NodeTraversal
{
    public class Program
    {
        public static List<Node> nodes = new List<Node>();
        static async Task MainAsync(string[] args)
        {
            //API_Request request = new API_Request();

            //nodes =  request.GetNodes();
            //foreach (var node in nodes)
            //{
            //    Console.WriteLine(node.id);
            //}
        }

        static void Main(string[] args)
        {
            API_Request request = new API_Request();
           

            nodes = request.GetNodes().Result;
           

            NodeHandler handler = new NodeHandler(nodes);

            var totalCount = handler.GetTotalNodeCount();
            var nodeWithMostConnections = handler.GetNodeWithMostConnections();

            
           Console.WriteLine("Total Count : " + totalCount);
           Console.WriteLine("Node(Id) with most connections : " + nodeWithMostConnections);
            Console.ReadLine();
            
        }
    }
}
