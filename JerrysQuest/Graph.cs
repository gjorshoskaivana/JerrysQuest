using System.Collections.Generic;

namespace JerrysQuest
{
    internal class Graph
    {
        public int N;
        public List<int>[] neighbors;

        public Graph(int N)
        {
            neighbors = new List<int>[N];
            for(int i=0; i<N; i++)
            {
                neighbors[i] = new List<int>();
            }
            this.N = N;
        }

        public void addEdge_Undirected(int i, int j) 
        {
            neighbors[i].Add(j); // i -> j
            neighbors[j].Add(i); // j -> i
        }

        public void addEdge_Directed(int i, int j)
        {
            neighbors[i].Add(j); // i -> j
        }
    }
}