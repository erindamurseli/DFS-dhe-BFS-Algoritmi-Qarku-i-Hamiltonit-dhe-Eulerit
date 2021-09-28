using System;
using System.Collections.Generic;
using System.Text;

namespace EM_App
{
    public class CikliHamiltonit
    {
        public int V;
        int[] path;
        public CikliHamiltonit(int v)
        {
            V = v;
        }
/* Një funksion i dobishëm për t'u kontrolluar
     nëse kulmi v mund të shtohet në
     indeksin pos në Ciklin Hamiltonian
     e ndërtuar deri më tani (e ruajtur në 'path []') */
        bool isSafe(int v, int[,] graph,
                    int[] path, int pos)
        {
            

            if (graph[path[pos - 1], v] == 0)
                return false;

//kontrolloni nese tani jan shtuar nyje
            for (int i = 0; i < pos; i++)
                if (path[i] == v)
                    return false;

            return true;
        }
/* Një funksion i shërbimeve rekursive
     për të zgjidhur problemin e ciklit hamiltonian */

        bool HamiltonCycleRec(int[,] graph, int[] path, int pos)
        {
/*  Nëse të gjitha kulmet
         përfshihen në Ciklin Hamiltonian */
            if (pos == V)
            {

                if (graph[path[pos - 1], path[0]] == 1)
                    return true;
                else
                    return false;
            }


            for (int v = 1; v < V; v++)
            {

                if (isSafe(v, graph, path, pos))
                {
                    path[pos] = v;
// * përsëritet për të ndërtuar pjesën tjetër të shtegut */
                    if (HamiltonCycleRec(graph, path, pos + 1) == true)
                        return true;

                    path[pos] = -1;
                }
            }
/* Nëse asnjë kulm nuk mund të shtohet në Ciklin Hamiltonian
         ndërtuar deri më tani, kthehet false */
            return false;
        }


        public int hamCycle(int[,] graph)
        {
            path = new int[V];
            for (int i = 0; i < V; i++)
                path[i] = -1;

/* Le të vendosim kulmin 0 si i pari
         kulm në shteg. Nëse ka një
         Cikli Hamiltonian, atëherë rruga mund të jetë
         filluar nga çdo pikë e ciklit
         pasi grafiku nuk është i drejtuar */
            path[0] = 0;
            if (HamiltonCycleRec(graph, path, 1) == false)
            {
                Console.WriteLine("\nNuk ekziston ndonje rruge qe krijon qark te Hamiltonit");
                return 0;
            }

            PrintoPathin(path);
            return 1;
        }

// / * Një funksion i dobishëm për të printuar zgjidhjen */
        void PrintoPathin(int[] path)
        {
            Console.WriteLine("Rruga e pershkuar me poshte paraqet qark te Hamiltonit");
            for (int i = 0; i < V; i++)
                Console.Write(" " + path[i] + " ");

// Le të shtypim përsëri kulmin e parë
         // për të treguar ciklin e plot
            Console.WriteLine(" " + path[0] + " ");
        }



    }
}
