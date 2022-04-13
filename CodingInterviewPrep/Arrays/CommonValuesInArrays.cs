using System.Collections.Generic;

namespace CodingInterviewPrep.Arrays
{
    public class CommonValuesInArrays
    {
        public bool HasCommonValue<T>(ICollection<T> arr1, ICollection<T> arr2)
        {
            var hashSet = new HashSet<T>();
            foreach (var val in arr1)
            {
                hashSet.Add(val);
            }

            foreach (var val in arr2)
            {
                if (hashSet.Contains(val))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
