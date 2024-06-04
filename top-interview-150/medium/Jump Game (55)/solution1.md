My own solution: 
Start at the last index and work towards the first.

If none of the values are 0 return true becasue we can always jump forward.

If you hit a zero continue towards the first index and see if there is a way for you to get past it.

If there is, skip to that number and continue moving towards the front by 1 until you hit another zero and repeat the process.

The way we can see if we can get past the zero is by checking the value of the elements before it and seeing if they are greater than the difference between the indices of the two elements. In other words if an element with a value 5 is 5 spaces before the 0, then it will land on the zero. But if it has a value of 6 it can get past the zero.


```cs
public class Solution {
    public bool CanJump(int[] nums) {
         int length = nums.Length;
        bool canJump = true;

        // We don't need to check the last index because jump length is irrelevant there
        for(var i = length-2; i >= 0; i--)
        {
            int currentValue = nums[i];

            if(currentValue > 0) 
            {
                continue;    
            }
            else
            {
                int spacesPrior =0;
                
                bool canSkipTheZero = false;
                
                for(var j = i-1; j >=0; j--)
                {
                    spacesPrior +=1;

                    if(nums[j] > spacesPrior)
                    {
                        canSkipTheZero = true;
                        i = j;
                        break;
                    }
                }

                if (canSkipTheZero == false)
                {
                    canJump = false;
                    break;
                }
            }
        }

        return canJump;
    }
}

```


Example 1:

Input: nums = [2,3,1,1,4]
Output: true
Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.


Start at the last index and work towards the first.

If none of the values are 0 return true becasue we can always jump forward.

If you hit a zero continue towards the first index and see if there is a way for you to get past it.

If there is, skip to that number and continue moving towards the front by 1 until you hit another zero and repeat the process.

The way we can see if we can get past the zero is by checking the value of the elements before it and seeing if they are greater than the difference between the indices of the two elements. In other words if an element with a value 5 is 5 spaces before the 0, then it will land on the zero. But if it has a value of 6 it can get past the zero.


Example 2:

Input: nums = [3,2,1,0,4]
Output: false
Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.

1:
4, ok

2: 0 BAD
Move one space before zero
2a: 0Index - 1 = 1, no good, value must be greater than one, try again
2b: 0Index - 2 = 2, no good, value must be greater than two, try again
2b: 0Index - 3 = 3, no good, value must be greater than three, try again