using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingInterviewPrep.Graphs
{
    public class Graph
    {
        private IList<Node> nodes;

        public Graph()
        {
            nodes = new List<Node>();
        }

        public void AddVertex(Node node)
        {
            if (!nodes.Contains(node))
            {
                nodes.Add(node);
            }
        }

        public void AddEdge(Node node1, Node node2)
        {
            node1.Connect(node2);
            node2.Connect(node1);
        }

        public void AddTestData()
        {
            AddVertex(new Node("0"));
            AddVertex(new Node("1"));
            AddVertex(new Node("2"));
            AddVertex(new Node("3"));
            AddVertex(new Node("4"));
            AddVertex(new Node("5"));
            AddVertex(new Node("6"));

            AddEdge(GetNodeByName("3"), GetNodeByName("1"));
            AddEdge(GetNodeByName("3"), GetNodeByName("4"));
            AddEdge(GetNodeByName("4"), GetNodeByName("2"));
            AddEdge(GetNodeByName("4"), GetNodeByName("5"));
            AddEdge(GetNodeByName("1"), GetNodeByName("2"));
            AddEdge(GetNodeByName("1"), GetNodeByName("0"));
            AddEdge(GetNodeByName("0"), GetNodeByName("2"));
            AddEdge(GetNodeByName("6"), GetNodeByName("5"));
        }

        public void ShowConnections()
        {
            foreach (var node in nodes)
            {
                Console.Write($"{node.Name} -> [ ");
                foreach (var edge in node.Connections)
                {
                    Console.Write($"{edge.Name} "); ;
                }
                Console.Write($"]\n");
            }
        }

        public Node GetNodeByName(string name) => nodes.FirstOrDefault(n => n.Name == name);
    }

    public class Node
    {
        public string Name;
        public IList<Node> Connections;

        public Node(string name)
        {
            this.Name = name;
            this.Connections = new List<Node>();
        }

        public void Connect(Node other)
        {
            if (!Connections.Contains(other))
            {
                Connections.Add(other);
            }
        }
    }

}

