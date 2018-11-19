using System;
using System.Collections.Generic;
using NameSorter;
using NameSorter.Repositories;
using Xunit;

namespace NameSorterTester
{
    public class UnitTests
    {
        [Fact]
        public void ValidateFullNameTest()
        {
            Boolean[] expected = { true, true , true , true , false, false };
            Boolean[] actual = new Boolean[expected.Length];

            var people = new List<Person>
            {
                new Person(new string[]{"Richard", "Martin"}, "Burgess"),
                new Person(new string[]{"Richard", "Larry"}, "Burgess"),
                new Person(new string[]{"Giacomo"}, "Zander"),
                new Person(new string[]{"Marc"}, "Lastly"),
                new Person(new string[]{"Hunter","Uriah","Mathew", "Tommy"}, "Clarke"),
                new Person(new string[]{},"Peter")
            };

            for (int i = 0; i < people.Count; i++)
            {
                string[] fullName = new string[people[i].GivenNames.Length+1];
                for (int j = 0; j < people[i].GivenNames.Length; j++){
                    fullName[j] = people[i].GivenNames[j];
                }
                fullName[people[i].GivenNames.Length] = people[i].LastName;
                actual[i] = new ValidateFullName().IsFullNameValid(fullName);
            }
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetSortedListOfNamesTest()
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

            for (int i = 0; i < actual.Count;i++){
                Assert.Equal(expected[i].LastName,actual[i].LastName);
            }

            for (int i = 0; i < actual.Count; i++)
            {
                string[] expGivenNames = expected[i].GivenNames;
                string[] actGivenNames = actual[i].GivenNames;
                bool result = ArrayAreEqual.ArraysAreEqual(expGivenNames, actGivenNames);
                if(result)
                {
                    Assert.True(result);
                }
            }
        }
    }
}
