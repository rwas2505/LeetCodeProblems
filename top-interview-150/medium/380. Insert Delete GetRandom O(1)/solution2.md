Try using an actual set and see if its faster

```cs
public class RandomizedSet {

    private readonly HashSet<int> _set;

    public RandomizedSet() {
        _set = new HashSet<int>();
    }
    
    public bool Insert(int val) {
        if(!_set.Contains(val))
        {
            _set.Add(val);
            return true;
        }

        return false;
    }
    
    public bool Remove(int val) {
        if(_set.Contains(val))
        {
            _set.Remove(val);

            return true;
        }

        return false;
    }
    
    public int GetRandom() {
        var count = _set.Count;

        return _set.ElementAt(new Random().Next(0, count));
    }
}
```