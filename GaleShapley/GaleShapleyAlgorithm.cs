using System;
using System.Collections.Generic;
using System.Linq;

namespace GaleShapley
{
    public class GaleShapleyAlgorithm
    {
        public GaleShapleyAlgorithm()
        {

        }

        /// <summary>
        /// Gale-Shapley Algorithm. Preferences are ordered based on position in the list. Thus, indexing of elements
        /// will be considered as a point of comparison when ranking preferences.
        /// </summary>
        /// <param name="proposerList"></param>
        /// <param name="acceptorList"></param>
        /// <returns></returns>
        public IDictionary<IPerson, IPerson> FindStableMatches(List<IPerson> proposerList, List<IPerson> accepteeList)
        {
            if (proposerList == null || accepteeList == null)
            {
                Console.WriteLine("Input for either proposerList or accepteeList are null.");
                return null;
            }

            if (proposerList.Count.Equals(0) || accepteeList.Count.Equals(0))
            {
                Console.WriteLine("There are no proposerList or accepteeList in the given input collection.");
                return null;
            }

            if (!proposerList.Count.Equals(accepteeList.Count()))
            {
                Console.WriteLine("Input for proposerList and accepteeList do not have the same element count.");
                return null;
            }

            var pairDictionary = new Dictionary<IPerson, IPerson>();

            while (proposerList.Any(person => person.IsEngaged == false) || proposerList.Any(person => person.Fiance == null))
            {
                foreach (var proposer in proposerList)
                {

                    if (!proposer.IsEngaged)
                    {
                        var firstAccepteeInPrefList = proposer.PreferenceList.First();
                        var checkIfInList = accepteeList.Any(person => person.Name == firstAccepteeInPrefList.Name);

                        if (!checkIfInList)
                        {
                            Console.WriteLine($"{firstAccepteeInPrefList.Name} is not the list of people being proposed to.");
                            return null;
                        }
                        else if (!firstAccepteeInPrefList.IsEngaged && firstAccepteeInPrefList.Fiance == null)
                        {
                            var acceptee = accepteeList.Find(person => person == firstAccepteeInPrefList);
                            if (acceptee == null)
                            {
                                Console.WriteLine($"{acceptee.Name} is not the list of people being proposed to.");
                                return null;
                            }

                            proposer.IsEngaged = true;
                            proposer.Fiance = acceptee;

                            var result = proposer.RemovePersonFromPrefList(acceptee);
                            if (!result)
                            {
                                Console.WriteLine($"Error in removing acceptee: '{acceptee.Name}' from proposer's preference list");
                                return null;
                            }

                            acceptee.IsEngaged = true;
                            acceptee.Fiance = proposer;

                            if (pairDictionary.ContainsKey(proposer))
                            {
                                pairDictionary[proposer] = acceptee;
                            }
                            else
                            {
                                pairDictionary.Add(proposer, acceptee);
                            }

                        }
                        else if (firstAccepteeInPrefList.IsEngaged && firstAccepteeInPrefList.Fiance != null)
                        {
                            var currentFianceIndex = firstAccepteeInPrefList.PreferenceList.IndexOf(firstAccepteeInPrefList.Fiance);
                            var possibleFianceIndex = firstAccepteeInPrefList.PreferenceList.IndexOf(proposer);

                            if (possibleFianceIndex < currentFianceIndex)
                            {
                                var currentFiance = proposerList.Find(person => person == firstAccepteeInPrefList.Fiance);
                                if (currentFiance == null)
                                {
                                    Console.WriteLine($"{currentFiance.Name} is not the list of people that are proposing.");
                                    return null;
                                }
                                currentFiance.IsEngaged = false;
                                currentFiance.Fiance = null;

                                var acceptee = accepteeList.Find(person => person == firstAccepteeInPrefList);
                                if (acceptee == null)
                                {
                                    Console.WriteLine($"{acceptee.Name} is not the list of people being proposed to.");
                                    return null;
                                }

                                var removalResult = proposer.RemovePersonFromPrefList(acceptee);
                                if (!removalResult)
                                {
                                    Console.WriteLine($"Error in removing acceptee: '{acceptee.Name}' from proposer's preference list");
                                    return null;
                                }

                                acceptee.IsEngaged = true;
                                acceptee.Fiance = proposer;
                                proposer.IsEngaged = true;
                                proposer.Fiance = acceptee;

                                pairDictionary[proposer] = acceptee;
                                pairDictionary[currentFiance] = null;
                            }
                            else
                            {
                                var result = proposer.RemovePersonFromPrefList(firstAccepteeInPrefList);
                                if (!result)
                                {
                                    Console.WriteLine($"Error in removing acceptee: '{firstAccepteeInPrefList.Name}' from proposer's preference list");
                                    return null;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid preference list object in current proposer: {proposer}");
                            return null;
                        }
                    }
                }
            }
            return pairDictionary;
        }
    }
}
