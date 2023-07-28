using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    internal class Graph
    {
        private class NodeTag
        {
            public double Length;
            public GraphNode PreviousNode; 
            public NodeTag(double length, GraphNode previousNode)
            {
                Length = length;
                PreviousNode = previousNode; 
            }
        }
        private List<GraphNode> m_nodes;
        private List<GraphEdge> m_edges;
        private Hashtable m_nodeTags;
        private Hashtable m_edgesHashtable;
        public Graph()
        { 
            m_nodes = new List<GraphNode>();
            m_edges = new List<GraphEdge>();
            m_nodeTags = new Hashtable();
            m_edgesHashtable = new Hashtable();
        }
        public void AddNode(GraphNode node)
        {
            m_nodes.Add(node);
            m_nodeTags.Add(node, new NodeTag(double.MaxValue, null));
        }
        public void AddEdge(GraphEdge edge)
        {
            m_edges.Add(edge);
            m_edgesHashtable.Add(GetHashcodeForConnection(edge.StartNode, edge.EndNode), edge);
        }
        public void RemoveNode(GraphNode node)
        {
            m_nodes.Remove(node);
        }
        public void RemoveEdge(GraphEdge edge)
        {
            m_edges.Remove(edge);
        } 
        public GraphPath FindShortestPathFromTo(GraphNode from, GraphNode to)
        {
            GraphPath shortestPath = new GraphPath();
            List<GraphNode> shortestPathNodes = new List<GraphNode>();
            CalculateShortestPaths(from);
            while (to != from)
            {
                NodeTag nodeTag = (NodeTag)m_nodeTags[to];
                shortestPathNodes.Add(to);
                to = nodeTag.PreviousNode;
            }
            shortestPathNodes.Add(from);
            shortestPathNodes.Reverse();
            shortestPath.AddNodes(shortestPathNodes);
            return shortestPath;
        }
        private void CalculateShortestPaths(GraphNode start)
        {
            m_nodeTags[start] = new NodeTag(0.0, null);
            List<GraphNode> undiscoveredNodes = new List<GraphNode>(m_nodes.ToArray());

            GraphNode lastDiscoveredNode = start;
            while (undiscoveredNodes.Count > 1)
            {
                List<GraphEdge> edgesFrom = FindEdgesFrom(undiscoveredNodes, lastDiscoveredNode);
                NodeTag lastNodeTag = (NodeTag)m_nodeTags[lastDiscoveredNode];
                foreach (var edge in edgesFrom)
                {
                    NodeTag nodeTag = (NodeTag)m_nodeTags[edge.EndNode];
                    if (lastNodeTag.Length + edge.Length < nodeTag.Length)
                    {
                        nodeTag.Length = lastNodeTag.Length + edge.Length;
                        nodeTag.PreviousNode = lastDiscoveredNode;
                    }
                }
                undiscoveredNodes.Remove(lastDiscoveredNode);
                lastDiscoveredNode = FindNextDisoveredNode(undiscoveredNodes);
            }
        }
        private GraphNode FindNextDisoveredNode(List<GraphNode> undiscoveredNodes)
        {
            GraphNode graphNode = null;
            double min = double.MaxValue;
            foreach (var node in undiscoveredNodes)
            {
                NodeTag nodeTag = (NodeTag)m_nodeTags[node];
                if (nodeTag.Length < min)
                {
                    min = nodeTag.Length;
                    graphNode = node;
                }
            }
            return graphNode;
        }
        private List<GraphEdge> FindEdgesFrom(GraphNode from)
        {
            List<GraphEdge> edges = new List<GraphEdge>();
            for (int i = 0; i < m_edges.Count; i++)
            {
                GraphEdge edge = m_edges[i];
                if ((!edge.IsDirected && (edge.StartNode == from || edge.EndNode == from)) || 
                    (edge.IsDirected && edge.StartNode == from))
                    edges.Add(edge); 
            }
            return edges;
        }
        private List<GraphEdge> FindEdgesFrom(List<GraphNode> graphNodes, GraphNode from)
        {
            List<GraphEdge> edges = new List<GraphEdge>();
            for (int i = 0; i < graphNodes.Count; i++)
            {
                GraphNode graphNode = graphNodes[i];

                GraphEdge edge = (GraphEdge)m_edgesHashtable[GetHashcodeForConnection(from, graphNode)];    
                if(edge != null)
                    edges.Add(edge);
            }
            return edges;
        }
        private int GetHashcodeForConnection(GraphNode start, GraphNode end)
        {
            int hashcode = 17;
            hashcode ^= start.GetHashCode();
            hashcode ^= end.GetHashCode();
            return hashcode;
        }
    }
}
