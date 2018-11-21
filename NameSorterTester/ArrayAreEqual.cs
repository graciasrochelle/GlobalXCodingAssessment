namespace NameSorterTester
{
    public static class ArrayAreEqual
    {
        /// <summary>
        /// Checks if two arrays are equal
        /// </summary>
        /// <returns><c>true</c>, if arrays equal, <c>false</c> otherwise.</returns>
        /// <param name="obj1">Array1</param>
        /// <param name="obj2">Array2</param>
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
