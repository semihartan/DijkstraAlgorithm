namespace DijkstraAlgorithm
{
    internal class Program
    {
        static void Main(string[] args)
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

            GraphPath shortestPathFromA2C = graph.FindShortestPathFromTo(nodeA, nodeC);

            Console.WriteLine($"Shortest Path From A to C is {shortestPathFromA2C}");
        }
    }
}