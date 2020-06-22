using System.Collections.Generic;

namespace JerrysQuest
{
    internal class EdgeList
    {
        public List<Edge> list;

        public EdgeList()
        {
            list = new List<Edge>();
        }

        public void put(int a, string b)
        {
            list.Add(new Edge(a, b));
        }
        public void put(string b, int a)
        {
            list.Add(new Edge(a, b));
        }

        public int get(string b)
        {
            for (int i=0; i < list.Count; i++)
            {
                if(list[i].b == b)
                {
                    return list[i].a;
                }
            }
            return -1;
        }
        public string get(int a)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i].a == a)
                {
                    return list[i].b;
                }
            }
            return null;
        }
    }
}