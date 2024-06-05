https://leetcode.com/problems/rotate-array/solutions/3925380/c-simple-o-1-space-and-o-n-time-complexity

Intuition
Approach
Here we are Reversing the whole array first .Doing this we make our last k terms appears first in the array. Since we reverse the array the ordere is change now we need to reverse again the array but this time from index 0-> k-1 and k-> n-1 so that we can get the desired result without using extra space
Complexity
Time complexity: O(N)
Space complexity: O(1)
Code
```c++
class Solution {
public:

    void reverse(vector<int>&nums, int i , int j ){
        while( i < j){
            swap(nums[i++] , nums[j--] );
        }
    }

    void rotate(vector<int>& nums, int k) {
        int n = nums.size() ;
        k = k %n;
//  Reverse the whole Array 
        reverse(nums, 0 , n-1 );
//  Reverse the array from k index to n-1 index
        reverse(nums, k, n-1 );
//  Reverse the array from 0 to k-1 index 
        reverse(nums, 0, k-1);
    }
};
```


Here is me converting it to c# from the other users answer above and verified it beats about 90% on speed and space

```cs
public class Solution {
    public void Rotate(int[] nums, int k) {

        var n = nums.Length;
        var m = k % n;

        // Reverse the whole Array 
        reverse(nums, 0 , n-1 );

        // Reverse the array from k index to n-1 index
        reverse(nums, m, n-1 );

        // Reverse the array from 0 to k-1 index 
        reverse(nums, 0, m-1);
   

    }

    private void reverse(int[] n, int i , int j )
    {
        int first = 0;
        int last = 0;

        while( i < j )
        {
            first = n[i];
            last = n[j];
            n[i] = last;
            n[j] = first;
            i++;
            j--;
        }
    }
}
```