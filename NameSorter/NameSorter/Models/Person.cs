namespace NameSorter
{
    public class Person
    {
        public long Position { get; set; }
        public string GivenNames { get; set; }
        public string LastName { get; set; }
        public override string ToString()
        {
            return GivenNames + " " + LastName;
        }
    }
}
