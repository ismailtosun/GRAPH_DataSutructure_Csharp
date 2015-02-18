using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSC09122014
{
    class Graph<T> where T:IComparable
    {
        Vertex<T> head;



        public Vertex<T> findVertex(string id)
        {
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                if (iterator.Id == id)
                    return iterator;
                iterator = iterator.Next;
            }
            return null;
        }
        public int outdegree(string id)
        {
            Vertex<T> current = findVertex(id);
            if (current != null)
            {
                int counter = 0;
                Edge<T> iterator = current.EdgeLink;
                while (iterator != null)
                {
                    counter++;
                    iterator = iterator.Next;
                }
                return counter;
            }
            return -1;
        }
        public void display()
        {
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                Console.Write(iterator.ToString()+" --> ");
                Edge<T> iteratorEdge = iterator.EdgeLink;
                while (iteratorEdge != null)
                {
                    Console.Write(iteratorEdge.ToString()+" ");
                    iteratorEdge = iteratorEdge.Next;
                }
                Console.WriteLine();
                iterator = iterator.Next;
            }
            Console.WriteLine();
        }
        public int vertexCount()
        {
            int counter = 0;
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                counter++;
                iterator = iterator.Next;
            }
            return counter;
        }
        public void addVertex(string id)
        {
            if (findVertex(id) == null)
            {
                if (head == null)
                    head = new Vertex<T>(id);
                else
                {
                    Vertex<T> iterator = head;
                    while (iterator.Next != null)
                        iterator = iterator.Next;
                    iterator.Next = new Vertex<T>(id);
                }
            }
            else
            {
                Console.WriteLine("this vertex exists");
            }
        }
        public void addEdge(string startId, string endId, T weight)
        {
            Vertex<T> current = findVertex(startId);
            if (current != null && findVertex(endId) != null)
            {
                Edge<T> iterator = current.EdgeLink;
                if (iterator == null)
                    current.EdgeLink = new Edge<T>(endId, weight);
                else
                {
                    while (iterator.Next != null)
                        iterator = iterator.Next;
                    iterator.Next = new Edge<T>(endId, weight);
                }
            }else
                Console.WriteLine("this edge can not exist");

        }
        public int inDegree(string id)
        {
            if (findVertex(id) == null)
                return -1;
            else
            {
                int counter = 0;
                Vertex<T> iterator = head;
                while (iterator != null)
                {
                    Edge<T> iteratorEdge = iterator.EdgeLink;
                    while (iteratorEdge != null)
                    {
                        if (id == iteratorEdge.VertexId)
                            counter++;
                        
                        iteratorEdge = iteratorEdge.Next;
                     }
                     iterator = iterator.Next;
                }
                return counter;
            }
        }

        private int findIndex(string id)
        {

            Vertex<T> iterator = head;
            int index = 0;
            while (iterator != null)
            {
                if (iterator.Id == id)
                    return index;
                index++;
                iterator = iterator.Next;

            }
            return index;
        }
        public int[,] adjacencyMatrix()
        {
            int[,] matrix = new int[vertexCount(), vertexCount()];
            return matrix;


        }
        public Vertex<T>[] topologicalSorting()
        {
            Vertex<T>[] sorted = new Vertex<T>[vertexCount()];
            for (int i = 0; i < sorted.Length; i++)
            {
                Vertex<T> withZeroIndegree = zeroIndegree();
                if (withZeroIndegree == null)
                    throw new Exception("hatalı graph");

                deleteVertex(withZeroIndegree.Id);
                sorted[i] = withZeroIndegree;
                 
            }
            return sorted;
            

        }
        public Vertex<T> zeroIndegree()
        {
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                if(inDegree(iterator.Id)==0)
                    return iterator;
                iterator = iterator.Next;
            }
            return null;
        }
        public void deleteVertex(string id)
        {
            if (head.Id == id)
                head = head.Next;
            else
            {
                Vertex<T> iterator = head.Next;
                Vertex<T> prev = head;
                while (iterator != null)
                {
                    if (iterator.Id == id)
                        prev.Next = iterator.Next;
                    prev = iterator;
                    iterator = iterator.Next;
                }
            }
        }
        public Graph<T> copyGraph()
        {
            Graph<T> copy = new Graph<T>();
            Vertex<T> iterator = head;
            while (iterator != null)
            {
                copy.addVertex(iterator.Id);
                iterator = iterator.Next;
            }
            iterator = head;
            while (iterator != null)
            {
                Edge<T> edgeIterator = iterator.EdgeLink;
                while (edgeIterator != null)
                {
                    copy.addEdge(iterator.Id, edgeIterator.VertexId, edgeIterator.Weight);
                    edgeIterator = edgeIterator.Next;
                }
                iterator = iterator.Next;
            }
            return copy;
         }


    }
}
