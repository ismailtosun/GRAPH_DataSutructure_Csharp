using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSC09122014
{
    class Edge<T>  where T:IComparable
    {
        string vertexId;

        public string VertexId
        {
            get { return vertexId; }
            set { vertexId = value; }
        }
        T weight;

        public T Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        Edge<T> next;

        internal Edge<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        public Edge(string id, T w)
        {
            vertexId = id;
            weight = w;
        }
        public override string ToString()
        {
            return vertexId + " "; //+ weight.ToString();
        }
    }
}
