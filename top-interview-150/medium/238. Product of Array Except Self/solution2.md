https://leetcode.com/problems/product-of-array-except-self/solutions/1342916/3-minute-read-mimicking-an-interview

### Another persons approach

This arrives at the same solution I got, but takes it one step further by going from O(n) to O(1) space complexity


```java
class Solution {
    public int[] productExceptSelf(int[] nums) {
        int n = nums.length;
        int ans[] = new int[n];
        Arrays.fill(ans, 1);
        int curr = 1;
        for(int i = 0; i < n; i++) {
            ans[i] *= curr;
            curr *= nums[i];
        }
        curr = 1;
        for(int i = n - 1; i >= 0; i--) {
            ans[i] *= curr;
            curr *= nums[i];
        }
        return ans;
    }
}
```