namespace NameSorterTester
{
    public static class ArrayAreEqual
    {
        internal static bool ArraysAreEqual(string[] obj1, string[] obj2)
        {
            if (obj1.Length != obj2.Length)
            {
                return false;
            }

            for (int index = 0; index < obj1.Length; index++)
            {
                if (obj1[index] != obj2[index])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
