### Other users solution

https://leetcode.com/problems/jump-game-ii/solutions/5205903/easy-java-solution-with-explanation-1-ms-beats-100

The code isn't super clean but the explanation matches one of my original ideas:


Approach
While traversing the array, for every element, its value is the maximum jump it can take. So between that jum, we find the element which can give us the meaximum jump.
Eg.
2,2,3,4,3,2,1

we are at index 0, and it can jump to index 1 and 2 with values 2 and 3 resp.
Here value 3 can get us more far than 2, so we jump till 3 and do the same steps until we reach end element.

Please upvote if you like the solution.
Thanks for reading! Good day

Complexity
Time complexity:
O(N)

Space complexity:
O(1)

```java
class Solution {
    int ans = 0;

    public int jump(int[] nums) {
        int i = 0;
        while (i < nums.length - 1) {
            i = helper(i, nums[i], nums);

        }
        return ans;
    }

    public int helper(int a, int b, int[] nums) {
        ans++;
        if (a + b >= nums.length - 1) {
            return nums.length;
        }
        int max = Integer.MIN_VALUE;
        int temp = 0;
        for (int i = a; i <= a + b; i++) {
            if (nums[i] + i >= max) {
                temp = i;
                max = nums[i] + i;
            }
        }
        return temp;
    }
}
```