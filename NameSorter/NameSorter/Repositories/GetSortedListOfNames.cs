using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Repositories
{
    public class GetSortedListOfNames
    {
        public GetSortedListOfNames()
        {
        }

        public List<Person> SortNames(List<Person> unsortedListOfNames)
        {
            List<Person> sortedNames = unsortedListOfNames.OrderBy(p => p.LastName).ToList();
            return sortedNames;
        }
    }
}
