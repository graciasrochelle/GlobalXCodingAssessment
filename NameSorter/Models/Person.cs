namespace NameSorter
{
    public class Person
    {
        public Person(string[] givenNames, string lastName)
        {
            GivenNames = givenNames;
            LastName = lastName;
        }

        public string[] GivenNames { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            string givenNames = "";
            for (int i = 0; i < GivenNames.Length;i++){
                givenNames += GivenNames[i] + " ";
            }
            return givenNames + LastName;
        }
    }
}
