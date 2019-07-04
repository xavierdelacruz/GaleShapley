using System;
using System.Collections.Generic;

namespace GaleShapley
{
    public class Program
    {
        static void Main(string[] args)
        {
            var solver = new GaleShapleyAlgorithm();
            var m1 = new Man("Johnny");
            var m2 = new Man("James");
            var m3 = new Man("Joe");

            var w1 = new Woman("Jane");
            var w2 = new Woman("Joyce");
            var w3 = new Woman("Jenny");

            m1.AddPersonToPrefList(w1);
            m1.AddPersonToPrefList(w2);
            m1.AddPersonToPrefList(w3);

            m2.AddPersonToPrefList(w3);
            m2.AddPersonToPrefList(w2);
            m2.AddPersonToPrefList(w1);

            m3.AddPersonToPrefList(w3);
            m3.AddPersonToPrefList(w1);
            m3.AddPersonToPrefList(w2);

            w1.AddPersonToPrefList(m1);
            w1.AddPersonToPrefList(m2);
            w1.AddPersonToPrefList(m3);

            w2.AddPersonToPrefList(m2);
            w2.AddPersonToPrefList(m3);
            w2.AddPersonToPrefList(m1);

            w3.AddPersonToPrefList(m2);
            w3.AddPersonToPrefList(m1);
            w3.AddPersonToPrefList(m3);

            List<IPerson> proposers = new List<IPerson>
            {
                m1,
                m2,
                m3
            };

            List<IPerson> proposees = new List<IPerson>
            {
                w1,
                w2,
                w3
            };

            var result = solver.FindStableMatches(proposers, proposees);

            foreach (KeyValuePair<IPerson, IPerson> pair in result)
            {
                Console.WriteLine($"{pair.Key.Name} is paired with {pair.Value.Name}");
            }
            Console.ReadLine();
        }
    }
}
