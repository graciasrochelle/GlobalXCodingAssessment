using System;
using System.Collections.Generic;

namespace NameSorter.Interfaces
{
    public interface INameSorter
    {
        List<Person> GetListOfNames(List<Person> listOfNames);
        Boolean WriteToScreen(string message , List<Person> listOfNames);
    }
}
