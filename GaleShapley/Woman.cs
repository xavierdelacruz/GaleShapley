using System;
using System.Collections.Generic;

namespace GaleShapley
{
    public class Woman : IPerson
    {
        public IList<IPerson> PreferenceList { get; set; }
        public bool IsEngaged { get; set; }
        public string Name { get; set; }
        public IPerson Fiance { get; set; }

        public Woman(string name)
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
                Console.WriteLine("Error: Non-existent person being added");
                return false;
            }

            if (person.GetType() == typeof(Woman)) 
            {
                Console.WriteLine("Error: Adding Woman to Woman Preference List.");
                return false;
            }

            if (PreferenceList.Contains(person))
            {
                Console.WriteLine($"Error: Person {person.Name} has already been added to the list.");
                return false;
            }

            PreferenceList.Add(person);
            return true;
        }

        public bool RemovePersonFromPrefList(IPerson person)
        {
            if (person == null)
            {
                Console.WriteLine("Null value for person being removed.");
                return false;
            }

            if (person.GetType() == typeof(Woman))
            {
                Console.WriteLine($"Error: Removing Woman: {person.Name} from Men Preference List.");
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
