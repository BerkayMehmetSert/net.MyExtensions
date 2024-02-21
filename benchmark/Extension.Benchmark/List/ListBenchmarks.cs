namespace Extension.Benchmark.List;

public class ListBenchmarks
{
    private readonly List<int> _list = GetRandomIntegersInRange(100, 1000, 25);
    private readonly List<int> _collection = GetRandomIntegersInRange(50, 500, 25);
    private readonly Func<int, bool> _predicate = x => x % 2 == 0;

    [Benchmark]
    public void AddRangeArray()
    {
        _list.AddRange(_collection.ToArray());
    }

    [Benchmark]
    public void AddRangeIndexCount()
    {
        _list.AddRange(_collection, 0, IterationCount);
    }

    [Benchmark]
    public void AddRangeCount()
    {
        _list.AddRange(_collection, IterationCount);
    }

    [Benchmark]
    public void GetDuplicates_DefaultComparer()
    {
        _ = _collection.GetDuplicates();
    }

    [Benchmark]
    public void Merge_AtStart()
    {
        _list.Merge(0, _collection);
    }

    [Benchmark]
    public void Merge_InMiddle()
    {
        var index = _list.Count / 2;
        _list.Merge(index, _collection);
    }

    [Benchmark]
    public void Merge_AtEnd()
    {
        var index = _list.Count;
        _list.Merge(index, _collection);
    }

    [Benchmark]
    public void PartitionBenchmarkTest()
    {
        _ = _collection.Partition(PartitionSize).ToList();
    }

    [Benchmark]
    public void RemoveAllBenchmarkTest()
    {
        _list.RemoveAll(_predicate);
    }

    [Benchmark]
    public void RemoveFirst()
    {
        _collection.RemoveFirst();
    }

    [Benchmark]
    public void RemoveFirst_Count()
    {
        _collection.RemoveFirst(IterationCount);
    }

    [Benchmark]
    public void RemoveFirst_Predicate()
    {
        _collection.RemoveFirst(_predicate);
    }

    [Benchmark]
    public void RemoveFirst_CountPredicate()
    {
        _collection.RemoveFirst(IterationCount, _predicate);
    }

    [Benchmark]
    public void RemoveLast()
    {
        _collection.RemoveLast();
    }

    [Benchmark]
    public void RemoveLast_Count()
    {
        _collection.RemoveLast(IterationCount);
    }

    [Benchmark]
    public void RemoveLast_Predicate()
    {
        _collection.RemoveLast(_predicate);
    }

    [Benchmark]
    public void RemoveLast_CountPredicate()
    {
        _collection.RemoveLast(IterationCount, _predicate);
    }
}
