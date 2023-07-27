using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    internal class GraphPath : IEnumerable<GraphNode>
    { 
        private List<GraphNode> m_nodes; 
        public GraphPath()
        {
            m_nodes = new List<GraphNode>();
        }
        public void AddNode(GraphNode graphNode)
        {
            m_nodes.Add(graphNode);
        }
        public void AddNodes(List<GraphNode> graphNodes)
        {
            m_nodes.AddRange(graphNodes);
        }
        public IEnumerator<GraphNode> GetEnumerator()
        {
            return m_nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return m_nodes.GetEnumerator();
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('(');
            stringBuilder.Append(m_nodes[0]);
            for (int i = 1; i < m_nodes.Count; i++)
            {
                stringBuilder.Append(" -> ");
                stringBuilder.Append(m_nodes[i]);
            }
            stringBuilder.Append(')');
            return stringBuilder.ToString();
        }
    }
}
