using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerrysQuest
{
    class Edge
    {
        public int a;
        public string b;

        public Edge(int a, string b)
        {
            this.a = a;
            this.b = b;
        }

        public Edge(string b, int a)
        {
            this.a = a;
            this.b = b;
        }
    }
}
