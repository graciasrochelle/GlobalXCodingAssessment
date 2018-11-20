using System.Collections.Generic;
using NameSorter;
using NameSorter.Repositories;
using Xunit;

namespace NameSorterTester
{
    public class GetSortedListOfNamesUnitTest
    {
        [Fact]
        public void Test()
        {
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
                new Person(new string[]{ "Shelby", "Nathan"}, "Yoder")
            };

            List<Person> unsortedListOfNames = new List<Person>
            {
                new Person(new string[]{ "Janet"}, "Parsons"),
                new Person(new string[]{ "Vaughn"}, "Lewis"),
                new Person(new string[]{ "Adonis", "Julius"}, "Archer"),
                new Person(new string[]{ "Shelby", "Nathan"}, "Yoder"),
                new Person(new string[]{ "Marin"}, "Alvarez"),
                new Person(new string[]{ "Richard", "Martin"}, "Burgess"),
                new Person(new string[]{ "Richard", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Benny", "Larry"}, "Burgess"),
                new Person(new string[]{ "Richard", "Andrew", "Larry"}, "Burgess")
            };

            List<Person> actual = new GetSortedListOfNames().SortNames(unsortedListOfNames);

            Assert.NotNull(actual);
            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i].LastName, actual[i].LastName);
            }

            for (int i = 0; i < actual.Count; i++)
            {
                string[] expGivenNames = expected[i].GivenNames;
                string[] actGivenNames = actual[i].GivenNames;
                bool result = ArrayAreEqual.ArraysAreEqual(expGivenNames, actGivenNames);
                if (result)
                {
                    Assert.True(result);
                }
            }
        }
    }
}
