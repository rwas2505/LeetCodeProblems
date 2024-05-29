This solution iterates over the nums array and keeps count of how many times a unique number has been identified.

If the number has already been identified fewer than 2 times, it is inserted into the nums array starting at index 0 and incrementing the index for each new insertion.

It uses two pointers and a counter

- k is the current index in which to insert/replace the element in the nums array
- i is the current number to evaluate in nums
- count is the number of times we have visited this number

We know the first element in nums will always remain the first element in nums because it is the first time it has appeared so we can start iterating at the 2nd element (index 1) 

If the next element does not equal the previous element, then it musts be the first time we are seeing it since the array is sorted and so we set count equal to 1, replace index k with the current number, and continue iterating.

If the next element does equal the previous element, and our count is less than 2, we also replace index k with the current number and increment count.

If the next element does equal the previous element, and count is 2 or greater, we continue on without any replacement since we can only keep 2 of a unique element.


```cs
public class Solution {
    public int RemoveDuplicates(int[] nums) {

        var count = 1;
        var currentNum = nums[0];
        var k = 1;

        for(var i = 1; i < nums.Length; i++)
        {
            if(nums[i] != currentNum)
            {
                currentNum = nums[i];
                nums[k] = currentNum;
                count = 1;
                k++;
            }
            else if(count < 2)
            {
                nums[k] = nums[i];
                count++;
                k++;
            }
        }
        
        return k;
    }
}
```