```cs
public class Solution {
    public int MajorityElement(int[] nums) {
        var dict = new Dictionary<int, int>();

        double length = nums.Length; 

        double halfLength = length/2;

        double majorityCount = Math.Ceiling(halfLength);

        int majorityElement = 0;

        for(var i = 0; i < nums.Length; i++)
        {
            var currentElement = nums[i];

            var keyExists = dict.ContainsKey(currentElement);

            if(!keyExists)
            {
                dict[currentElement] = 1;
            }
            else
            {
                dict[currentElement] = dict[currentElement] + 1;
            }

            if (dict[currentElement] >= majorityCount) 
            {
                majorityElement =  currentElement;
                break;
            }
        }

        return majorityElement;
    }
}
```