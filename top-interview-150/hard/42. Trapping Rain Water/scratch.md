

Thoughts:

- Water can only be contained when there is a valley with peaks on both sides 
- so valley as first or last element will not hold water, nor will anything between it and the next peak (right peak for first el left peak for last el)
- The max height of the water can only be as high as the lowest peak relative to the valley
- The amount of water in any column is not the difference between the absolute valley and peak, but rather the lower of the two peaks and the height array value at that column/index




Pseudo Code:
## Create a Peak, Step, Valley array
1. Start at the first element and determine if its a peak or valley
   - Valley if first non-matching height is greater
   - Peak if first non-matching height is less
2. If first element is VALLEY
   - Traverse right until the first peak
   - First peak is the first height whose right neighbor is LESS than the current height
   - As you traverse
     - IF NOT P AND height == valley height THEN assign V
     - IF NOT P AND height > valley height THEN assign S
     - IF IS P THEN assign P
3. If first element is PEAK
   - Traverse right until the first valley
   - First valley is the first eight whose right neighbor is GREATER than the current height
   - As you traverse
   - IF NOT V and height == peak THEN assign P
   - IF NOT V AND height < peak height then assign S
   - IF IS V THEN assign V
4. When you reach the last element, 
   - if you are moving from P and searching for V, then it must be V 
   - if you are moving from V and searching for P, then it must be P

## Assign water levels to each height
1. At each height:
   - IF Peak, water level = 0
   - IF Step or Valley, water level = (lowest peak) - (current height) 
   - Lowest peak determined by lowest height of left P and right P