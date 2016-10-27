using System;
using System.Collections.Generic;
namespace Лаба_4._2
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                List<State> state1 = new List<State>();
                Random rand = new Random();
                for (int i = 0; i < 10; ++i)
                {
                    Republic rep = new Republic("unitary", "presidential", "Name" + i, i * 123 + 34, i * 343 + 23, i * 2 + 1);
                    state1.Add(rep);
                }
                int ind = rand.Next(state1.Count);
                Console.WriteLine("It is countries in list\n");
                foreach (State s in state1)
                    Console.WriteLine(s.Name);
                Console.WriteLine();
                state1[ind].DoAgreement(state1);
                Console.WriteLine("{0} want to do agreement with upper country ",state1[ind].Name);
                Console.WriteLine("\nThere country have done agreement\n");
                foreach (State s in state1[ind].CountryDoAgreement)
                    Console.WriteLine(s.Name);
                Console.WriteLine();
                List<State> state = new List<State>();
                State s1 = new State(1, 2, "DSDF");
                state.Add(s1);
                Console.WriteLine(s1);
                Console.WriteLine();
                Console.WriteLine();
                Republic r = new Republic("unitary", "presidential", "Ukrain", 450000, 603000, 5);
                Console.WriteLine(r + "\n\n");
                state.Add(r);
                Monarchy m = new Monarchy(3400, 12000, "unitary", "absolute", "Britain");
                Console.WriteLine(m + "\n\n");
                state.Add(m);
                Kingdom k = new Kingdom(3400, 12000, "unitary", "absolute", "Monako","title");
                Console.WriteLine(k + "\n\n");
                state.Add(k);
                Console.WriteLine("In " + r.Name + " rup some territory. Terrtorry was " + r.Area);
                r.DeleteTerritory(1000000);
                Console.WriteLine("Territory is {0} now", r.Area);
                Console.WriteLine("\nPodatok in " + s1.Name + ":" + s1.Podatok());
                Console.WriteLine("Podatok in " + r.Name + ":" + r.Podatok());
                Console.WriteLine("Podatok in " + m.Name + ":" + m.Podatok());
                Console.WriteLine("Podatok in " + k.Name + ":" + k.Podatok());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
