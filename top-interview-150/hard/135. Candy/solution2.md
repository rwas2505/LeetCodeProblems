#### After a lot of manual note taking

1. Iterate through the list and assign each element as a P, V, or S (Peak, Valley, or Step)
2. Loop through again** and assign numbers to the step (S) elements
3. Loop through again** and assign numbers to the peak (P) elements

* **Can probably improve from 3 iterations to 1 iteration but this step makes building it out simpler and then can refactor further


- -1 = previous element
- +1 = next element
- CE = current element


*1. P, V, or S?*
   
Peak if:
- CE is first element AND +1 is less
- CE is last element AND -1 is less
- -1 is same and +1 is less
- -1 is less and +1 is same
- -1 is less and +1 is less

Valley if:
- CE is first element AND +1 is same
- CE is first element and +1 is greater
- CE is last element AND -1 is same
- CE is last element and - 1 is greater
- -1 is greater and +1 is same
- -1 is greater and +1 is greater
- -1 is same and +1 is same
- -1 is same and +1 is greater

Step if:
- None of the peak or valley conditions are true

*2. Assign values to S*
- If S is on an island (no S neighbors), assign it a value of 2
- If S is ascending (value before first S is 1/V), increment each S starting at 2
- If S is descendng (value bfore first S is a P), get the count of the current cluster of S's and decrement starting at count + 1

*3. Assign values to P*
- If P is on an island (no P neighbors) set it to the max(leftElementValue, rightElementValue) since Vs and Ss have been assigned
- If P is not on an island, it means there can only be two Ps in a row (if more than two, the middle values would be V) and so set the left P to value of element to left of P +1 and the right P to value right of P +1. This allows for the two peaks to be the minimum necessary value for their respective side of the plateau.
