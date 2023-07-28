using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    internal class GraphEdge
    {
        public GraphNode StartNode;
        public GraphNode EndNode;
        public double Length; 
        public bool IsDirected;
        public GraphEdge(GraphNode startNode, GraphNode endNode, double length, bool isDirected = false)
        {
            StartNode = startNode;
            EndNode = endNode;
            Length = length;
            IsDirected = isDirected;
        }
        public override int GetHashCode()
        {
            uint hashCode = 31;
            hashCode ^= (uint)(StartNode.GetHashCode() & 0x0000FFFF);
            hashCode ^= (uint)((EndNode.GetHashCode() << 16) & 0xFFFF0000);
            //hashCode ^= (uint)((Length.GetHashCode() << 8) & 0x000000FF00);
            //hashCode ^= (uint)(IsDirected.GetHashCode() & 0x00000000FF);
            return unchecked((int)hashCode);
        }
        public override string ToString()
        {
            string separator = "--";
            if (IsDirected)
                separator = "->";
            return $"({StartNode} {separator} {EndNode})";
        }
        public class GraphEdgeComparer : IComparer<GraphEdge>
        {
            int IComparer<GraphEdge>.Compare(GraphEdge? x, GraphEdge? y)
            {
                if (x?.Length == y?.Length) 
                    return 0;
                else if (x?.Length < y?.Length) 
                    return -1;
                return 1;
            }
        }
    }
}
