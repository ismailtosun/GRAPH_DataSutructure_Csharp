using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSC09122014
{
    class Test
    {
        static void Main(string[] args)
        {
            int[,] x = new int[3, 3];
            x.GetLength(0);

            Graph<int> myGraph = new Graph<int>();
            myGraph.addVertex("1");
            myGraph.addVertex("2");
            myGraph.addVertex("3");
            myGraph.addVertex("4");
            myGraph.addVertex("5");

            myGraph.addEdge("1", "3", 0);
            myGraph.addEdge("3", "4", 0);
            myGraph.addEdge("3", "5", 0);
            myGraph.addEdge("4", "5", 0);
            myGraph.addEdge("2", "3", 0);
            Graph<int> copy = myGraph.copyGraph();


            Vertex<int> [] sorted = copy.topologicalSorting();

            for (int i = 0; i < sorted.Length; i++)
            {
                Console.WriteLine(sorted[i]);
            }

            //myGraph.display();
            //Console.WriteLine(myGraph.inDegree("1"));



        }
    }
}
