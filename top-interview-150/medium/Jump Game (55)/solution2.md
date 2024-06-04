https://leetcode.com/problems/jump-game/solutions/4651419/c-easy-and-efficient-solution-o-1-o-n

This is another posters solution. It traverses the array left to right instead of right to left which is what I did.


Intuition
If we find a 0 in the array that we can't jump over we won't be able to reach the end.

Approach
We traverse the vector using a variable (maxIdx) to store the maximum index we can reach. If we find a 0 inside the array we need to make sure that our maxIdx is higher than the current, if that isn't the case, we'll return False as we won't be able to pass that index, which will prevent us from reaching the end.

If we reach the end we return true.

Complexity
Time complexity:
O(n)

Space complexity:
O(1)

```c++
class Solution {
public:
    bool canJump(vector<int>& nums) {
        int maxIdx = nums[0];

        for (int i = 0; i < nums.size(); ++i) {
            if (maxIdx >= nums.size() - 1) return true;

            if (nums[i] == 0 and maxIdx == i) return false;

            if (i + nums[i] > maxIdx) maxIdx = i + nums[i];
        }

        return true;
    }
};
```