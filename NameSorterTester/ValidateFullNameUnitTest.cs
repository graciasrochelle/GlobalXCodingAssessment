using System;
using System.Collections.Generic;
using NameSorter;
using NameSorter.Repositories;
using Xunit;

namespace NameSorterTester
{
    public class ValidateFullNameUnitTest
    {
        /// <summary>
        /// Validates the full name test.
        /// </summary>
        [Fact]
        public void Test()
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
    }
}
