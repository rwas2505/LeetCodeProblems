From another member on leet:
https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/solutions/4613251/two-pointer-beats-93-o-n

Since the array is sorted, it is guaranteed that duplicated elements will be next to each other. A pointer is initialized for which index to put the next element. While iterating through nums array, since there can be only 2 duplicated elements in result, replaceIndex-2 is checked to ensure there are only 2 duplicated elements on the list.

```cs
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var replaceIndex = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (replaceIndex-2 >= 0 && nums[replaceIndex-2] == nums[i])
            {
                continue;
            }
            nums[replaceIndex] = nums[i];
            replaceIndex++;
        }
        return replaceIndex;
    }
}
```