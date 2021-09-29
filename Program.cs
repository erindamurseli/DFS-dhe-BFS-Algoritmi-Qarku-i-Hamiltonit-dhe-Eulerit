using System;
using System.Collections.Generic;
using System.Linq;

namespace EM_App
{
    class Program 
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Grafi 1 ");
            Graph g1 = new Graph();
            g1.ShtoNyje();
            // g1.ShtoNyje(0, 4);
            // g1.ShtoNyje(0, 5);
            // g1.ShtoNyje(1, 2);
            // g1.ShtoNyje(1, 3);
            // g1.ShtoNyje(1, 5);
            // g1.ShtoNyje(2, 3);
            // g1.ShtoNyje(2, 4);
            // g1.ShtoNyje(3, 4);
            // g1.ShtoNyje(4, 5);
        

            g1.DFS(0);
            g1.BFS(0);
            g1.KonvertimiiMatrices();
            Console.WriteLine();
            Console.WriteLine(g1.GrafiEshteEulerian());
            Console.WriteLine(g1.eshteHamiltonian());
            Console.WriteLine();
            CikliHamiltonit hamiltonian1 = new CikliHamiltonit(6);
            
            hamiltonian1.hamCycle(g1.KonvertimiiMatrices());
            Console.WriteLine("===========================================================================================================");
            // Console.WriteLine("Grafi 2");
            

            // Graph g2 = new Graph(8);
            // g2.ShtoNyje(0, 1);
            // g2.ShtoNyje(0, 7);
            // g2.ShtoNyje(1, 2);
            // g2.ShtoNyje(1, 3);
            // g2.ShtoNyje(1, 7);
            // g2.ShtoNyje(2, 3);
            // g2.ShtoNyje(3, 4);
            // g2.ShtoNyje(3, 5);
            // g2.ShtoNyje(4, 5);
            // g2.ShtoNyje(5, 6);
            // g2.ShtoNyje(5, 7);
            // g2.ShtoNyje(6, 7);

            // g2.DFS(1);
            // g2.BFS(1);
            // g2.KonvertimiiMatrices();

            
            // Console.WriteLine();
            // Console.WriteLine(g2.GrafiEshteEulerian());
            // Console.WriteLine(g2.eshteHamiltonian());
            // Console.WriteLine();
            // CikliHamiltonit hamiltonian2 = new CikliHamiltonit(8);
            // hamiltonian2.hamCycle(g2.KonvertimiiMatrices());
            // Console.WriteLine("===========================================================================================================");
            // Console.WriteLine("Grafi 3 ");

            // Graph g3 = new Graph(5);

            // g3.ShtoNyje(0, 1);
            // g3.ShtoNyje(1, 4);
            // g3.ShtoNyje(2, 3);
            // g3.ShtoNyje(2, 4);
            // g3.ShtoNyje(3, 4);
           

            // g3.DFS(0);
            // g3.BFS(0);
            // g3.KonvertimiiMatrices();
            // Console.WriteLine();
            // Console.WriteLine(g3.GrafiEshteEulerian());
            // Console.WriteLine(g3.eshteHamiltonian());
            // Console.WriteLine();
            // CikliHamiltonit hamiltonian3 =  new CikliHamiltonit(5);
            // hamiltonian3.hamCycle(g3.KonvertimiiMatrices());
            Console.ReadKey();
        }
    }



   

}
