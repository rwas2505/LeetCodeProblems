Example 1:

Input: nums = [1,2,3,4]
Output: [24,12,8,6]


before the given index [1, 1, 2, 6]
after the given index [24, 12, 4, 1]

merge [24, 12, 8, 6]

So the above one...

create a prefixProduct array and a suffixProduct array each of length nums.Length

foreach element in prefixProducts set the element to the total products of all nums prior to that element in the nums array

to avoid looping over from the start everytime, just multiply the previous total product by the previous element in the nums array

always use 1 for the first element, so can acutally start at element two

do the same for the suffix array but starting from the end

then multiply the product of each array together at each index and insert it into a new answer array

```cs
public class Solution {
    public int[] ProductExceptSelf(int[] nums) {
        
        int[] prefixProducts = new int[nums.Length];
        int[] suffixProducts = new int[nums.Length];

        prefixProducts[0] = 1;
        suffixProducts[nums.Length - 1] = 1;

        for (var i = 1; i < prefixProducts.Length; i ++)
        {
            prefixProducts[i] = prefixProducts[i-1] * nums[i-1];
        }

        for(var j = suffixProducts.Length - 2; j >= 0; j--)
        {
            suffixProducts[j] = suffixProducts[j+1] * nums[j+1];
        }

        int[] answer = new int[nums.Length];

        for (var k = 0; k < answer.Length; k++)
        {
            answer[k] = prefixProducts[k] * suffixProducts[k];
        }

        return answer;
    }
}
```