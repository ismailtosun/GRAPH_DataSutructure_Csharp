using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSC09122014
{
    class Vertex<T> where T :IComparable
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        Vertex<T> next;

        internal Vertex<T> Next
        {
            get { return next; }
            set { next = value; }
        }
        Edge<T> edgeLink;

        internal Edge<T> EdgeLink
        {
            get { return edgeLink; }
            set { edgeLink = value; }
        }
        public Vertex(string id)
        {
            this.id = id;
        }
        public override string ToString()
        {
            return id;
        }
    }
}
