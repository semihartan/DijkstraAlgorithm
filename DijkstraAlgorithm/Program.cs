namespace DijkstraAlgorithm
{
    internal class Program
    {
        private static GraphPath Example0()
        {
            Graph graph = new Graph();
            GraphNode nodeA = new GraphNode("A");
            GraphNode nodeB = new GraphNode("B");
            GraphNode nodeC = new GraphNode("C");
            GraphNode nodeD = new GraphNode("D");
            GraphNode nodeE = new GraphNode("E");
            GraphNode nodeF = new GraphNode("F");
            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            graph.AddNode(nodeD);
            graph.AddNode(nodeE);
            graph.AddNode(nodeF);
            graph.AddEdge(new GraphEdge(nodeA, nodeB, 2));
            graph.AddEdge(new GraphEdge(nodeA, nodeD, 8));
            graph.AddEdge(new GraphEdge(nodeB, nodeE, 6));
            graph.AddEdge(new GraphEdge(nodeB, nodeD, 5));
            graph.AddEdge(new GraphEdge(nodeD, nodeE, 3));
            graph.AddEdge(new GraphEdge(nodeD, nodeF, 2));
            graph.AddEdge(new GraphEdge(nodeE, nodeF, 1));
            graph.AddEdge(new GraphEdge(nodeE, nodeC, 9));
            graph.AddEdge(new GraphEdge(nodeF, nodeC, 3));
             
            return graph.FindShortestPathFromTo(nodeA, nodeC);
        }
        private static GraphPath Example1()
        {
            Graph graph = new Graph();
            GraphNode node1 = new GraphNode("1");
            GraphNode node2 = new GraphNode("2");
            GraphNode node3 = new GraphNode("3");
            GraphNode node4 = new GraphNode("4");
            GraphNode node5 = new GraphNode("5"); 
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddEdge(new GraphEdge(node1, node2, 100, true));
            graph.AddEdge(new GraphEdge(node1, node3, 30, true));
            graph.AddEdge(new GraphEdge(node2, node3, 20, true));
            graph.AddEdge(new GraphEdge(node3, node4, 10, true));
            graph.AddEdge(new GraphEdge(node3, node5, 60, true));
            graph.AddEdge(new GraphEdge(node4, node2, 15, true));
            graph.AddEdge(new GraphEdge(node4, node5, 50, true));
            
            return graph.FindShortestPathFromTo(node1, node2);
        }
        private static GraphPath Example2()
        {
            Graph graph = new Graph();
            GraphNode node1 = new GraphNode("1");
            GraphNode node2 = new GraphNode("2");
            GraphNode node3 = new GraphNode("3");
            GraphNode node4 = new GraphNode("4");
            GraphNode node5 = new GraphNode("5");
            GraphNode node6 = new GraphNode("6");
            graph.AddNode(node1);
            graph.AddNode(node2);
            graph.AddNode(node3);
            graph.AddNode(node4);
            graph.AddNode(node5);
            graph.AddNode(node6);
            graph.AddEdge(new GraphEdge(node1, node2, 3));
            graph.AddEdge(new GraphEdge(node1, node3, 5));
            graph.AddEdge(new GraphEdge(node1, node4, 9));

            graph.AddEdge(new GraphEdge(node2, node3, 3));
            graph.AddEdge(new GraphEdge(node2, node4, 4));
            graph.AddEdge(new GraphEdge(node2, node5, 7));
             
            graph.AddEdge(new GraphEdge(node3, node4, 2));
            graph.AddEdge(new GraphEdge(node3, node5, 6));
            graph.AddEdge(new GraphEdge(node3, node6, 8));

            graph.AddEdge(new GraphEdge(node4, node5, 2));
            graph.AddEdge(new GraphEdge(node4, node6, 2));

            graph.AddEdge(new GraphEdge(node5, node6, 5));

            return graph.FindShortestPathFromTo(node1, node6);
        }
        static void Main(string[] args)
        {
            List<GraphPath> shortestPathsFromExamples = new List<GraphPath>
            {
                Example0(),
                Example1(),
                Example2()
            };
            foreach (var shortestPath in shortestPathsFromExamples)
            {
                Console.WriteLine($"Shortest Path: {shortestPath}");    
            } 
        }
    }
}