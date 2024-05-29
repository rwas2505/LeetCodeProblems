https://en.wikipedia.org/wiki/Boyer%E2%80%93Moore_majority_vote_algorithm
https://www.geeksforgeeks.org/boyer-moore-majority-voting-algorithm/


```cs
public class Solution {
    public int MajorityElement(int[] nums) {
       int nominee = nums[0];
       int count = 0;

       for(var i = 0; i < nums.Length; i++)
       {
            var currentElement = nums[i];

            if(count == 0)
            {
                nominee = currentElement;
            }

            if(nominee == currentElement)
            {
                count++;
            }
            else
            {
                count--;
            }
       }
       return nominee;
    }
}
```