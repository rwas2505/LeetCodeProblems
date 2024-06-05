O(1) extra space
This seems to work on smaller inputs but when the nums array gets large this times out. Need to improve the time complexity



```cs
public class Solution {
    public void Rotate(int[] nums, int k) {

        if(nums.Length == 1) return;

        var l = k;

        if(k > nums.Length)
        {
            l = k % (nums.Length);
        }

        // Each loop should be a full single rotation in place
        for(var j = 0; j < l; j++)
        {
            // 0
            var lastNum = nums[nums.Length-1];

            // 1
            var currentNum = nums[0];

            // 2
            var nextNum = nums[1];

            // 3
            nums[0] = lastNum;


            for(var i = 1; i < nums.Length; i++)
            {
                // 4
                nums[i] = currentNum;

                // 5
                currentNum = nextNum;

                if(i != (nums.Length-1))
                {
                    // 6
                    nextNum = nums[i+1];
                }
            }
        }
    }
}


```

Example 1:
Input: nums = [1,2,3,4,5,6,7], k = 3
Output: [5,6,7,1,2,3,4]
Explanation:
rotate 1 steps to the right: [7,1,2,3,4,5,6]
rotate 2 steps to the right: [6,7,1,2,3,4,5]
rotate 3 steps to the right: [5,6,7,1,2,3,4]

rotate = 3
1. lastNum = 7 (nums[nums.Length-1])
2. currentNum = 1 (nums[0]) (index = 0)
3. nextNum = 2 (nums[1]) (index = 1)

4. replace currentNum with lastNum
[7,2,3,4,5,6,7]

1. replace nextNum with currentNum
[7,1,3,4,5,6,7]
1. set currentNum to nextNum
currentNum = 2
1. set nextnum to nextNum + 1 (index= 2)
nextNum = 3

1. replace nextNum with currentNum
[7,1,2,4,5,6,7]
1. set currentNum to nextNum
currentNum = 3
1. set nextNum to nextNum + 1 (index = 3)
nextNum =4

replace nextNum with currentNum
[7,1,2,3,5,6,7]
set currentNum to nextNum
currentNum = 4
set nextNum to nextNum + 1 (index = 4)
nextNum =5

replace nextNum with currentNum
[7,1,2,3,4,6,7]
set currentNum to nextNum
currentNum = 5
set nextNum to nextNum + 1 (index = 5)
nextNum =6

replace nextNum with currentNum
[7,1,2,3,4,5,7]
set currentNum to nextNum
currentNum = 6
set nextNum to nextNum + 1 (index = 6)
nextNum =7

replace nextNum with currentNum
[7,1,2,3,4,5,6]
set currentNum to nextNum

SO WHILE index < nums.Length