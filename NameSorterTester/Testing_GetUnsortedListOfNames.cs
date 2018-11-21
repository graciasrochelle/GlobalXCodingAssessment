using System;
using System.Collections.Generic;
using System.IO;
using NameSorter;
using NameSorter.Repositories;
using NameSorter.Services;
using Xunit;

namespace NameSorterTester
{
    public class Testing_GetUnsortedListOfNames
    {

        [Fact]
        public void Test()
        {
            string inputFileName = Path.GetFullPath("../../../Utils/TextFiles/unit-test-unsorted-names-list-test1.txt");

            List<Person> actual = new GetUnsortedListOfNames().ReadFromFile(inputFileName);

            List<Person> expected = new List<Person>
            {
                new Person(new string[]{ "Marin"}, "Alvarez"),
                new Person(new string[]{ "Adonis", "Julius"}, "Archer"),
                new Person(new string[]{ "Richard", "Martin"}, "Burgess"),
                new Person(new string[]{ "Vaughn"}, "Lewis"),
                new Person(new string[]{ "Janet"}, "Parsons"),
                new Person(new string[]{ "Shelby" , "Nathan"}, "Yoder"),
               
            };

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i].LastName, actual[i].LastName);
            }
        }

        [Fact]
        public void Test1()
        {
            string inputFileName = Path.GetFullPath("../../../Utils/TextFiles/unit-test-unsorted-names-list-test2.txt");

            List<Person> actual = new GetUnsortedListOfNames().ReadFromFile(inputFileName);

            List<Person> expected = new List<Person>
            {
                new Person(new string[]{ "Marin"}, "Alvarez"),
                new Person(new string[]{ "Adonis", "Julius"}, "Archer"),
                new Person(new string[]{ "Richard", "Martin"}, "Burgess"),
                new Person(new string[]{ "Vaughn"}, "Lewis"),
                new Person(new string[]{ "Janet"}, "Parsons"),
                new Person(new string[]{ "Shelby" , "Nathan"}, "Yoder"),
            };

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i].LastName, actual[i].LastName);
            }
        }
    }
}
