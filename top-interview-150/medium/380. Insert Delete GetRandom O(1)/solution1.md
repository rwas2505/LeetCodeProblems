### My solution

Using a dictionary

```cs
public class RandomizedSet {

    private readonly Dictionary<int, bool> _set;

    public RandomizedSet() {
        _set = new Dictionary<int, bool>();
    }
    
    public bool Insert(int val) {
        if(!_set.ContainsKey(val))
        {
            _set[val] = true;
            return true;
        }

        return false;
    }
    
    public bool Remove(int val) {
        if(_set.ContainsKey(val))
        {
            _set.Remove(val);

            return true;
        }

        return false;
    }
    
    public int GetRandom() {
        var count = _set.Count;

        return _set.ElementAt(new Random().Next(0, count)).Key;
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */
```