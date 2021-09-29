using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace EM_App
{
    public class Graph
    // Kjo klasë paraqet një graf të padrejtuar duke përdorur listën e fqijnesise
    {
        private int Kulmet; //Nr i kulmeve/nyjeve
        private List<int>[] lidhjaEKulmeve; //Vargu i listes qe paraqet lidhjen e kulmeve

        public Graph()
        {
            Console.WriteLine("sa kulme keni:");
            int kulmet;
            kulmet = int.Parse(Console.ReadLine());
            Kulmet = kulmet;
            lidhjaEKulmeve = new List<int>[kulmet];
            for (int i = 0; i < kulmet; ++i)
                lidhjaEKulmeve[i] = new List<int>();
        }
        public void ShtoNyje()
        {
            // Graf jo i drejtuar
           
            for(int i=0;i<Kulmet;i++){
                for(int j=0;j<Kulmet;j++){
                    Console.WriteLine("Nese ka dege mes dy kulmeve vendos 1 ne te kunderten 0!");
                    Console.WriteLine("Dega: (" +i+ "," +j+") = ");
                    int dega =int.Parse(Console.ReadLine());
                    if (dega == 1){
                        lidhjaEKulmeve[dega].Add(j);//Shto w në listën  kulmet
                        lidhjaEKulmeve[j].Add(dega);
                    }
                    
                }
            }
            
        }
        public string eshteHamiltonian()
        {
            
            if (!eshteiLidhur())
            {
                return "\nGrafi nuk eshte Hamiltonian, sepse nuk eshte i lidhur";
            }
            else if (Kulmet < 3)
            {
                return "\nGrafi nuk eshte Hamiltonian, sepse ka numer te nyjeve me te vogel se 3";
            }
            else if (TeoremaeDirakut() && TeoremaeOresit())
            {
                return "\nGrafi eshte Hamiltonian nga teorema e Dirakut dhe Oresit";
            }
            else if (TeoremaeDirakut() && !TeoremaeOresit())
            {
                return "\nGrafi eshte Hamiltonian nga teorema e Dirakut dhe nuk mund te percaktohet nga teorema e Oresit";
            }
            else if (TeoremaeDirakut() && !TeoremaeOresit())
            {
                return "\nGrafi eshte Hamiltonian nga teorema e Oresit dhe nuk mund te percaktohet nga teorema e Dirakut";
            }
            else
            {
                return "\nGrafi nuk mund te percaktohet nese eshte Hamiltonian per nga teorema e Dirakut apo nga teorema e Oresit ";
            }
        }


        public int[,] KonvertimiiMatrices()
        {
            int[,] matricaeKonvertuar = new int[Kulmet, Kulmet];
            for (int j = 0; j < lidhjaEKulmeve.Count(); j++)
            {
                for (int i = 0; i < Kulmet; i++)
                {

                    if (lidhjaEKulmeve[j].Contains(i))
                    {
                        matricaeKonvertuar[j, i] = 1;
                    }

                }
            }

            return matricaeKonvertuar;
        }
        public bool TeoremaeOresit()
        {
            int Count = 0;
            int Count2 = 0;
            var list = new List<KeyValuePair<int, int>>();
            for (int j = 0; j < lidhjaEKulmeve.Count(); j++)
            {
                for (int i = 0; i < Kulmet; i++)
                {
                    if (true)
                    {
                        if (!lidhjaEKulmeve[j].Contains(i))
                        {
                            list.Add(new KeyValuePair<int, int>(j, i));
                            Count++;
                        }
                    }
                }
            }
            foreach (KeyValuePair<int, int> acct in list)
            {
                int a = acct.Key;
                int b = acct.Value;

                int nr1 = lidhjaEKulmeve[a].Count();
                int nr2 = lidhjaEKulmeve[b].Count();

                if (nr1 + nr2 > Kulmet)
                {
                    Count2++;
                }
            }

            if (Count == Count2)
            {
                return true;
            }
            return false;
        }

        public bool TeoremaeDirakut()
        {
            int k = Kulmet / 2;
            int counter = 0;
            foreach (var item in lidhjaEKulmeve)
            {
                if (item.Count() >= k)
                {
                    counter++;
                }
            }

            if (counter == Kulmet)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    // Funksioni qe perdoret nga DFS
        public void DFSrec(int kulmet, bool[] vizito)
        {
      // Shënoni nyjen aktuale si të vizituar
            vizito[kulmet] = true;
            Console.Write(kulmet + " ");

            List<int> listaeKulmeve = lidhjaEKulmeve[kulmet];//// Përsëritet për të gjitha lidhjeteKulmeve ne kulmet
            foreach (var n in listaeKulmeve)
            {
                if (!vizito[n])
                    DFSrec(n, vizito);
            }
        }
        public void DFSrec1(int kulmet, bool[] vizito)
        {

            vizito[kulmet] = true;

            List<int> listaeKulmeve = lidhjaEKulmeve[kulmet];
            foreach (var n in listaeKulmeve)
            {
                if (!vizito[n])
                    DFSrec1(n, vizito);
            }
        }
        public void BFS(int s)
        {
            
            Console.WriteLine("\nGjeresia se pari (BFS):");

            bool[] vizito = new bool[Kulmet];
            for (int i = 0; i < Kulmet; i++)
                vizito[i] = false;

            LinkedList<int> queue = new LinkedList<int>();


            vizito[s] = true;
            queue.AddLast(s);

            while (queue.Any())
            {
                s = queue.First();
                Console.Write(s + " ");
                queue.RemoveFirst();

                List<int> list = lidhjaEKulmeve[s];

                foreach (var val in list)
                {
                    if (!vizito[val])
                    {
                        vizito[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
        }

        public void DFS(int kulmet)
        {
            Console.WriteLine("\nThellesia se pari (DFS) ");
            bool[] vizito = new bool[Kulmet];

            DFSrec(kulmet, vizito);

        }

        public bool eshteiLidhur()
        {

            bool[] vizito = new bool[Kulmet];
            int i;
            for (i = 0; i < Kulmet; i++)
                vizito[i] = false;


            for (i = 0; i < Kulmet; i++)
                if (lidhjaEKulmeve[i].Count != 0)
                    break;

            if (i == Kulmet)
                return true;

            DFSrec1(i, vizito);

            for (i = 0; i < Kulmet; i++)
                if (vizito[i] == false && lidhjaEKulmeve[i].Count > 0)
                    return false;

            return true;
        }
        public String GrafiEshteEulerian()
        {

            if (eshteiLidhur() == false)
                return "\nGrafi nuk eshte Eulerian sepse nuk eshte i lidhur";
// Numëro kulme me shkallë teke/odd
            int odd = 0;
            for (int i = 0; i < Kulmet; i++)
                if (lidhjaEKulmeve[i].Count % 2 != 0)
                    odd++;
// Nëse numërimi është më shumë se 2, atëherë grafiku nuk është Eulerian
            if (odd > 2)
                return "\nGrafi nuk eshte Eulerian, sepse me shume se dy nyje te tij kane shkalle teke";


            return (odd == 2) ? "\nGrafi ka rruge te Eulerit" : "\nGrafi ka qark te Eulerit";
        }

    }
}
