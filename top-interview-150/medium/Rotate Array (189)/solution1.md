My first solution


k can be a number larger than the length of the array which would result in rotating so many times that you eventually end up at the initial array. To avoid unnecessary rotations, if k > nums.Length we take k % nums.Length to get the number of rotations such that it doesn't redundantly rotate all the way though the array.


If array = [1, 2, 3, 4, 5]

k = 10
10 % 5 = 0
no reotations necessary, return the final array


k = 13
13 % 5 = 3
rotate 3 times instead of 13

Next we make a clone of nums and save to numsCopy

Then we point at the pivot element in the copy array. So if we are rotating 3 times we point to index 2, if we are rotating 5 times we point at index 4 etc.

Iterate from the pivot point to the end of the array, each time replacing the original nums array with that element starting at element 0.

Then replace the rest of the nums array with the remaining elements. 

Essentially we are snatching from the pivot point to the end of the array and shifting that section to the beginning of the array.



```cs
public class Solution {
    public void Rotate(int[] nums, int k) {

        var numsCopy = new int[nums.Length];

        var l = k;

        if(k > nums.Length)
        {
            l = k % (nums.Length);
        }

        for(var i = 0; i < nums.Length; i++)
        {
            numsCopy[i] = nums[i];
        }

        var j = 0;

        for(var i = nums.Length - l; i < nums.Length; i++)
        {
            nums[j] = numsCopy[i];
            j++;
        }

        for(var i = 0; i < nums.Length - l; i++)
        {
            nums[j] = numsCopy[i];
            j++;
        }

    }
}
```