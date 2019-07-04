using System.Collections.Generic;

namespace GaleShapley
{
    public interface IPerson
    {
        IList<IPerson> PreferenceList { get; set; }
        bool IsEngaged { get; set; }
        string Name { get; set; }
        IPerson Fiance { get; set; }
        bool AddPersonToPrefList(IPerson person);
        bool RemovePersonFromPrefList(IPerson person);
    }
}
