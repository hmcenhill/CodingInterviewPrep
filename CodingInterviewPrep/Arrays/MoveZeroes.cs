using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPrep.Arrays
{
    public class MoveZeroes
    {
        public void Solution(int[] nums)
        {
            var zeroIndexes = new Queue<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroIndexes.Enqueue(i);
                }
                else if (zeroIndexes.Count > 0)
                {
                    nums[zeroIndexes.Dequeue()] = nums[i];
                    nums[i] = 0;
                    zeroIndexes.Enqueue(i);
                }
            }
        }
    }
}