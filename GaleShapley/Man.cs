using System;
using System.Collections.Generic;

namespace GaleShapley
{
    public class Man : IPerson
    {
        public IList<IPerson> PreferenceList { get; set; }
        public bool IsEngaged { get; set; }
        public string Name { get; set; }
        public IPerson Fiance { get; set; }

        public Man(string name)
        {
            PreferenceList = new List<IPerson>();
            IsEngaged = false;
            Name = name;
            Fiance = null;
        }

        public bool AddPersonToPrefList(IPerson person)
        {
            if (person == null)
            {
                Console.WriteLine("Null value for person being added");
                return false;
            }

            if (person.GetType() == typeof(Man))
            {
                Console.WriteLine("Error: Adding Man to Woman Preference List.");
                return false;
            }

            if (PreferenceList.Contains(person))
            {
                Console.WriteLine($"Person {person} has already been added to the list.");
                return false;
            }

            PreferenceList.Add(person);
            return true;
        }

        public bool RemovePersonFromPrefList(IPerson person)
        {
            if (person == null)
            {
                Console.WriteLine("Null value for person being removed");
                return false;
            }

            if (person.GetType() == typeof(Man))
            {
                Console.WriteLine("Error: Removing Man from Women Preference List.");
                return false;
            }

            if (PreferenceList.Contains(person))
            {
                PreferenceList.Remove(person);
                return true;
            }
            else
            {
                Console.WriteLine("Person being removed does not exist.");
                return false;
            }
        }
    }
}
