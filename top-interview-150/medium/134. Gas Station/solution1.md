
### My solution
Works but is wildly inefficient and times out on huge arrays with 1 as each element. See solution 2 for very clean and fast O(n) solution 

--------------------------
START 0: 
    gas total: 1
    cost: 3
    delta: -2 (can't advance)

START 1:
    gas total:2
    cost: 4 
    delta: -2 (can't advance)

START 2:
    gas total: 3
    cost: 5 
    delta: -2 (can't advance)

--------------------------
Start 3:
    gas total: 4
    cost: 1 
    delta: +3 (can advance) 

Next 4:
    gas total: 3 + 5 = 8
    cost: 2
    delta: +6 (can advance) 

Next: 0:
    gas total: 6 + 1 = 7
    cost: 3
    delta: +4 (can advance)

Next 1:
    gas total: 4 + 2 = 6
    cost: 4
    delta: +3 (can advance)

Next 2:
    gas total: 3 + 3 = 6
    cost: 3
    delta: +3 (Can advance to the start which is 3 -> FINISH!)

Input: gas = [1,2,3,4,5], cost = [3,4,5,1,2]






gas: [2,3,4]
cost: [3,4,3]

Start: 2:
    gas gotal: 4
    cost: 3
    delta: 1 (can advance)

Next: 0: 
    gas total: 1 + 2 = 3
    cost: 3
    delta: 0 (can advance)

Next: 1:
    gas total: 0 + 3 = 3
    cost: 4
    delta: - 1 (can't advance)

    ```cs
public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        var gasTotal = 0;
        var costToAdvance = 0;
        var delta = 0;
        var initialOffset = 0;
        int winningStart = -1;


        // Loop around until finding a potential starting point
        // Once we get there, we should start a new loop with this starting point as the offset
        // We need to account for hitting the end of the array and checking the 0th index so we will use an offset and %
        for (var i = 0; i < gas.Length; i++)
        {
            var pointer1 = (i + initialOffset) % gas.Length;
            // Console.WriteLine("Pointer1: " + pointer1);

            gasTotal = gasTotal + gas[pointer1];
            costToAdvance = cost[pointer1];
            delta = gasTotal - costToAdvance;

            // Console.WriteLine("Delta1: " + delta);

            if(delta < 0)
            {
                gasTotal = 0;
                costToAdvance = 0;
                delta = 0;
                continue;
            }
            else
            {
                gasTotal = 0;
                costToAdvance = 0;
                delta = 0;

                var tripOffset = i;

                // Start a new wraparound loop with i as the offset
                for(var j = 0; j < gas.Length; j++)
                {
                    var pointer2 = (j + tripOffset) % gas.Length;

                    // Console.WriteLine("Pointer2: " + pointer2);

                    // Console.WriteLine("gasTotal1: " + gasTotal);
                    gasTotal = gasTotal + gas[pointer2];
                    // Console.WriteLine("gasTotal2: " + gasTotal);
                    costToAdvance = cost[pointer2];
                    // Console.WriteLine("costToAdvance: " + costToAdvance);
                    delta = gasTotal - costToAdvance;

                    // Console.WriteLine("Delta2: " + delta);

                    if(delta < 0)
                    {
                        gasTotal = 0;
                        costToAdvance = 0;
                        delta = 0;
                        break;
                    }
                    else
                    {
                        gasTotal = delta;   
                    }

                    if (j == gas.Length -1 && delta >= 0)
                    {
                        winningStart = i;
                    }
                }

                if(winningStart > -1) break;
            }
        }

        return winningStart;
    }
}
    ```









Example 1:

Input: gas = [1,2,3,4,5], cost = [3,4,5,1,2]
Output: 3
Explanation:
Start at station 3 (index 3) and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
Travel to station 4. Your tank = 4 - 1 + 5 = 8
Travel to station 0. Your tank = 8 - 2 + 1 = 7
Travel to station 1. Your tank = 7 - 3 + 2 = 6
Travel to station 2. Your tank = 6 - 4 + 3 = 5
Travel to station 3. The cost is 5. Your gas is just enough to travel back to station 3.
Therefore, return 3 as the starting index.
Example 2:

Input: gas = [2,3,4], cost = [3,4,3]
Output: -1
Explanation:
You can't start at station 0 or 1, as there is not enough gas to travel to the next station.
Let's start at station 2 and fill up with 4 unit of gas. Your tank = 0 + 4 = 4
Travel to station 0. Your tank = 4 - 3 + 2 = 3
Travel to station 1. Your tank = 3 - 3 + 3 = 3
You cannot travel back to station 2, as it requires 4 unit of gas but you only have 3.
Therefore, you can't travel around the circuit once no matter where you start.