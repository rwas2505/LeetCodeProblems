### My solution

Iterate over each element

if i + n[i] >= n.Length -1 then this is the last element we have to reach since its the first one that can hit the end
the first time we hit this can be thought of as our new target in a way, call it index targetIndex

now if we start from the beginning again, we would want to go until i + n[i] >= targetIndex
this would be the earliest element that could reach our updated final destination

do this while targetIndex > 0


```cs

public class Solution {
    public int Jump(int[] nums) {
        int targetIndex = nums.Length - 1;
        int minJumps = 0;

        while (targetIndex > 0)
        {
            for(var i = 0; i < nums.Length; i++)
            {
                if(i + nums[i] >= targetIndex)
                {
                    targetIndex = i;
                    minJumps += 1;
                    break;
                }
            }
        }

        return minJumps;
    }
}
```

