using System.Collections.Generic;
using NameSorter;
using NameSorter.Repositories;
using Xunit;

namespace NameSorterTester
{
    public class Testing_GetSortedListOfNames
    {
        [Fact]
        public void Test()
        {
            List<Person> unsortedListOfNames = new List<Person>
            {
                new Person(new string[]{ "Janet"}, "Parsons"),
                new Person(new string[]{ "Vaughn"}, "Lewis"),
                new Person(new string[]{ "Adonis", "Julius"}, "Archer"),
                new Person(new string[]{ "Shelby", "Nathan"}, "Yoder"),
                new Person(new string[]{ "Marin"}, "Alvarez"),
                new Person(new string[]{ "Richard", "Martin"}, "Burgess"),
                new Person(new string[]{ "Richard", "Larry"}, "Burgess"),
                new Person(new string[]{ "Shelby", "Nathan"}, "Yoder"),
                new Person(new string[]{ "Richard", "Benny", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Andrew", "Larry"}, "Burgess")
            };

            List<Person> expected = new List<Person>
            {
                new Person(new string[]{ "Marin"}, "Alvarez"),
                new Person(new string[]{ "Adonis", "Julius"}, "Archer"),
                new Person(new string[]{ "Richard", "Andrew", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Benny", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Martin"}, "Burgess"),
                new Person(new string[]{ "Vaughn"}, "Lewis"),
                new Person(new string[]{ "Janet"}, "Parsons"),
                new Person(new string[]{ "Shelby", "Nathan"}, "Yoder"),
                new Person(new string[]{ "Shelby", "Nathan"}, "Yoder")
            };

            List<Person> actual = new GetSortedListOfNames().SortNames(unsortedListOfNames);

            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);

            // Checking if expected list of people is same as actual sorted list of people
            for (int i = 0; i < actual.Count; i++)
            {
                // If expected LastName same as actual LastName returned after sorting
                Assert.Equal(expected[i].LastName, actual[i].LastName);
            }

            // Checking if expected GivenNames of a person same as actual GivenNames returned after sorting
            for (int i = 0; i < actual.Count; i++)
            {
                string[] expGivenNames = expected[i].GivenNames;
                string[] actGivenNames = actual[i].GivenNames;

                bool result = ArrayAreEqual.ArraysAreEqual(expGivenNames, actGivenNames);
                // If expected GivenNames same as actual GivenNames returned after sorting
                if (result)
                {
                    Assert.True(result);
                }
            }
        }

        [Fact]
        public void Tes1()
        {
            string inputFileName = System.IO.Path.GetFullPath("../../../Utils/TextFiles/unit-test-unsorted-names-list1.txt");

            List<Person> expected = new List<Person>
            {
                new Person(new string[]{ "Shelby" , "Nathan"}, "Yoder"),
                new Person(new string[]{ "Shelby" , "Nathan"}, "Yoder")
            };

            List<Person> unsortedListOfNames = new GetUnsortedListOfNames().ReadFromFile(inputFileName);

            List<Person> actual = new GetSortedListOfNames().SortNames(unsortedListOfNames);

            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);

            // Checking if expected list of people is same as actual sorted list of people
            for (int i = 0; i < actual.Count; i++)
            {
                // If expected LastName same as actual LastName returned after sorting
                Assert.Equal(expected[i].LastName, actual[i].LastName);
            }

            // Checking if expected GivenNames of a person same as actual GivenNames returned after sorting
            for (int i = 0; i < actual.Count; i++)
            {
                string[] expGivenNames = expected[i].GivenNames;
                string[] actGivenNames = actual[i].GivenNames;

                bool result = ArrayAreEqual.ArraysAreEqual(expGivenNames, actGivenNames);
                // If expected GivenNames same as actual GivenNames returned after sorting
                if (result)
                {
                    Assert.True(result);
                }
            }
        }

        [Fact]
        public void LastNameNotEqual()
        {
            Person person1 = new Person(new string[] { "Andrew" }, "Burgess");
            Person person2 = new Person(new string[] { "Benny" }, "Peters");

            int actual = GetSortedListOfNames.CompareLastNames(person1.LastName, person2.LastName);

            Assert.NotEqual(0, actual);
        }

        [Fact]
        public void LastNameEqual()
        {
            Person person1 = new Person(new string[] { "Andrew" }, "Burgess");
            Person person2 = new Person(new string[] { "Benny" }, "Burgess");

            int actual = GetSortedListOfNames.CompareLastNames(person1.LastName, person2.LastName);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void IfLastNameEqual_NextGivenNameEqual()
        {
            Person person1 = new Person(new string[] { "Andrew", "B" }, "Burgess");
            Person person2 = new Person(new string[] { "Andrew", "B" }, "Burgess");

            int actual = GetSortedListOfNames.CompareGivenNames(person1.GivenNames, person2.GivenNames);

            Assert.Equal(0, actual);
        }

        [Fact]
        public void IfLastNameEqual_NextGivenNameNotEqual()
        {
            Person person1 = new Person(new string[] { "Andrew" }, "Burgess");
            Person person2 = new Person(new string[] { "Benny" }, "Burgess");

            int actual = GetSortedListOfNames.CompareGivenNames(person1.GivenNames, person2.GivenNames);

            Assert.NotEqual(0, actual);
        }
    }
}
