namespace Extension.UnitTest.List;

public class ListTests
{
    private static readonly int[] CollectionA = { 1, 2, 3 };
    private static readonly int[] CollectionB = { 4, 5, 6 };
    private static readonly int[] FullCollection = { 1, 2, 3, 4, 5, 6 };

    [Fact]
    public void AddRange_ShouldThrowArgumentNullException_WhenListIsNull()
    {
        IList<int>? list = null;
        Assert.Throws<ArgumentNullException>(() => list.AddRange(CollectionA));
    }

#pragma warning disable CS8625
    [Fact]
    public void AddRange_ShouldThrowArgumentNullException_WhenCollectionIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new List<int>().AddRange(null));
    }
#pragma warning restore CS8625

    [Fact]
    public void AddRange_ShouldAddElementsToEnd_WhenCollectionIsNotNull()
    {
        var list = new List<int> { 1, 2, 3 };
        list.AddRange(CollectionB);
        Assert.Equal(FullCollection, list);
    }

    [Fact]
    public void AddRange_WithIndexAndCount_ShouldThrowArgumentNullException_WhenListIsNull()
    {
        IList<int>? list = null;
        Assert.Throws<ArgumentNullException>(() => list.AddRange(CollectionA, 0, 3));
    }

    [Fact]
    public void AddRange_WithIndexAndCount_ShouldThrowArgumentNullException_WhenCollectionIsNull()
    {
        var list = new List<int>();
        Assert.Throws<ArgumentNullException>(() => list.AddRange(null, 0, 3));
    }

    [Fact]
    public void AddRange_WithIndexAndCount_ShouldAddSpecifiedNumberOfElements_WhenCollectionIsNotNull()
    {
        var list = new List<int> { 1, 2, 3 };
        list.AddRange(CollectionB, 0, 2);
        int[] expected = { 1, 2, 3, 4, 5 };
        Assert.Equal(expected, list);
    }

    [Fact]
    public void AddRange_WithIndexAndCount_ShouldAddSpecifiedNumberOfElementsStartingAtIndex_WhenCollectionIsNotNull()
    {
        var list = new List<int> { 1, 2, 3 };
        list.AddRange(CollectionB, 1, 2);
        int[] expected = { 1, 2, 3, 5, 6 };
        Assert.Equal(expected, list);
    }

    [Fact]
    public void AddRange_WithCount_ShouldThrowArgumentNullException_WhenListIsNull()
    {
        IList<int>? list = null;
        Assert.Throws<ArgumentNullException>(() => list.AddRange(CollectionA, 3));
    }

    [Fact]
    public void AddRange_WithCount_ShouldThrowArgumentNullException_WhenCollectionIsNull()
    {
        var list = new List<int>();
        Assert.Throws<ArgumentNullException>(() => list.AddRange(null, 3));
    }

    [Fact]
    public void AddRange_WithCount_ShouldAddSpecifiedNumberOfElements_WhenCollectionIsNotNull()
    {
        var list = new List<int> { 1, 2, 3 };
        list.AddRange(CollectionB, 2);
        int[] expected = { 1, 2, 3, 4, 5 };
        Assert.Equal(expected, list);
    }

    [Fact]
    public void GetDuplicates_ShouldReturnEmptyEnumerable_WhenCollectionIsEmpty()
    {
        var duplicates = new List<int>().GetDuplicates();
        Assert.Empty(duplicates);
    }

    [Fact]
    public void GetDuplicates_ShouldReturnEmptyEnumerable_WhenCollectionHasNoDuplicates()
    {
        var collection = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        var duplicates = collection.GetDuplicates();
        Assert.Empty(duplicates);
    }

    [Fact]
    public void GetDuplicates_ShouldReturnDuplicateElements_WhenCollectionHasDuplicates()
    {
        var collection = new List<int>
        {
            1,
            2,
            2,
            3,
            4,
            4,
            5
        };
        var duplicates = collection.GetDuplicates();
        int[] expected = { 2, 4 };
        Assert.Equal(expected, duplicates);
    }

    [Fact]
    public void GetDuplicates_ShouldReturnDuplicateElements_WhenCollectionHasDuplicatesWithCustomComparer()
    {
        var collection = new List<string>
        {
            "a",
            "A",
            "b",
            "B",
            "c",
            "C",
            "c"
        };
        var comparer = StringComparer.OrdinalIgnoreCase;
        var duplicates = collection.GetDuplicates(comparer);
        string[] expected = { "A", "B", "C" };
        Assert.Equal(expected, duplicates);
    }

    [Fact]
    public void GetDuplicates_ShouldReturnDuplicateElements_WhenCollectionHasDuplicatesWithCustomCapacity()
    {
        var collection = new List<int>
        {
            1,
            2,
            2,
            3,
            4,
            4,
            5
        };
        const int capacity = 3;
        var duplicates = collection.GetDuplicates(capacity: capacity);
        int[] expected = { 2, 4 };
        Assert.Equal(expected, duplicates);
    }

    [Fact]
    public void Map_ShouldThrowArgumentNullException_WhenListIsNull()
    {
        IList<int>? list = null;
        Func<int, int, int> map = (x, _) => x * 2;
        Assert.Throws<ArgumentNullException>(() => list.Map(map));
    }

    [Fact]
    public void Map_ShouldThrowArgumentNullException_WhenMapFunctionIsNull()
    {
        IList<int> list = new List<int> { 1, 2, 3 };
        Func<int, int, int>? map = null;
        Assert.Throws<ArgumentNullException>(() => list.Map(map));
    }

    [Fact]
    public void Map_ShouldMapElementsOfTheListUsingTheSpecifiedMappingFunction()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        list.Map(Map);
        Assert.Equal(new List<int>
        {
            2,
            4,
            6,
            8,
            10
        }, list);
        int Map(int x, int _) => x * 2;
    }

    [Fact]
    public void Map_ShouldMapElementsOfTheListUsingTheSpecifiedMappingFunctionWithIndex()
    {
        var list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        list.Map(Map);
        Assert.Equal(new List<int>
        {
            1,
            3,
            5,
            7,
            9
        }, list);
        int Map(int x, int i) => x + i;
    }

    [Fact]
    public void Merge_ShouldThrowArgumentNullException_WhenListIsNull()
    {
        IList<int>? list = null;
        IEnumerable<int> collection = new List<int> { 1, 2, 3 };
        Assert.Throws<ArgumentNullException>(() => list.Merge(0, collection));
    }

    [Fact]
    public void Merge_ShouldThrowArgumentNullException_WhenCollectionIsNull()
    {
        IList<int> list = new List<int>();
        IEnumerable<int>? collection = null;
        Assert.Throws<ArgumentNullException>(() => list.Merge(0, collection));
    }

    [Fact]
    public void Merge_ShouldMergeElementsOfTheCollectionIntoTheListAtSpecifiedIndex()
    {
        IList<int> list = new List<int>
        {
            1,
            2,
            3,
            7,
            8,
            9
        };
        IEnumerable<int> collection = new List<int> { 4, 5, 6 };
        list.Merge(3, collection);
        Assert.Equal(new List<int>
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9
        }, list);
    }

    [Fact]
    public void Merge_ShouldInsertElementsAtTheEndOfTheList_WhenIndexIsEqualToListCount()
    {
        IList<int> list = new List<int> { 1, 2, 3 };
        IEnumerable<int> collection = new List<int> { 4, 5, 6 };
        list.Merge(3, collection);
        Assert.Equal(new List<int>
        {
            1,
            2,
            3,
            4,
            5,
            6
        }, list);
    }

    [Fact]
    public void Merge_ShouldInsertElementsAtTheBeginningOfTheList_WhenIndexIsZero()
    {
        IList<int> list = new List<int> { 4, 5, 6 };
        IEnumerable<int> collection = new List<int> { 1, 2, 3 };
        list.Merge(0, collection);
        Assert.Equal(new List<int>
        {
            1,
            2,
            3,
            4,
            5,
            6
        }, list);
    }
#pragma warning disable CS8604
    [Fact]
    public void Partition_ShouldThrowArgumentNullException_WhenSourceIsNull()
    {
        IEnumerable<int>? source = null;
        const int size = 5;
        Assert.Throws<ArgumentNullException>(() => source.Partition(size).ToList());
    }
#pragma warning restore CS8604

    [Fact]
    public void Reduce_ShouldThrowArgumentNullException_WhenListIsNull()
    {
        IList<int>? list = null;
        Func<int, int, int> func = (x, y) => x + y;
        Assert.Throws<ArgumentNullException>(() => list.Reduce(func));
    }

    [Fact]
    public void Reduce_ShouldThrowArgumentNullException_WhenFuncIsNull()
    {
        IList<int> list = new List<int> { 1, 2, 3 };
        Func<int, int, int>? func = null;
        Assert.Throws<ArgumentNullException>(() => list.Reduce(func));
    }

    [Fact]
    public void Reduce_ShouldThrowInvalidOperationException_WhenListIsEmpty()
    {
        IList<int> list = new List<int>();
        Func<int, int, int> func = (x, y) => x + y;
        Assert.Throws<InvalidOperationException>(() => list.Reduce(func));
    }

    [Fact]
    public void Reduce_ShouldReturnAccumulatedValue_WhenListHasElements()
    {
        IList<int> list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        var result = list.Reduce(Func);
        Assert.Equal(15, result);
        int Func(int x, int y) => x + y;
    }

    [Fact]
    public void Reduce_ShouldReturnCorrectResult_WhenListHasElementsAndFuncIsSubtraction()
    {
        IList<int> list = new List<int> { 10, 5, 3 };
        var result = list.Reduce(Func);
        Assert.Equal(2, result);
        int Func(int x, int y) => x - y;
    }

    [Fact]
    public void RemoveAll_ShouldThrowArgumentNullException_WhenListIsNull()
    {
        IList<int>? list = null;
        Func<int, bool> match = x => x > 0;
        Assert.Throws<ArgumentNullException>(() => list.RemoveAll(match));
    }

    [Fact]
    public void RemoveAll_ShouldThrowArgumentNullException_WhenMatchIsNull()
    {
        IList<int> list = new List<int> { 1, 2, 3 };
        Func<int, bool>? match = null;
        Assert.Throws<ArgumentNullException>(() => list.RemoveAll(match));
    }

    [Fact]
    public void RemoveAll_ShouldRemoveMatchingElements_WhenListIsNotEmpty()
    {
        IList<int> list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        list.RemoveAll(Match);
        Assert.DoesNotContain(2, list);
        Assert.DoesNotContain(4, list);
        bool Match(int x) => x % 2 == 0;
    }

    [Fact]
    public void RemoveAll_ShouldRemoveAllElements_WhenAllElementsMatch()
    {
        IList<int> list = new List<int>
        {
            1,
            1,
            1,
            1,
            1
        };
        list.RemoveAll(Match);
        Assert.Empty(list);
        bool Match(int x) => x == 1;
    }

    [Fact]
    public void RemoveAll_ShouldNotRemoveAnyElement_WhenNoneMatch()
    {
        IList<int> list = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        list.RemoveAll(Match);
        Assert.Equal(new List<int>
        {
            1,
            2,
            3,
            4,
            5
        }, list);
        bool Match(int x) => x > 5;
    }

    [Fact]
    public void RemoveFirst_ShouldThrowArgumentNullException_WhenCollectionIsNull()
    {
        IEnumerable<int>? collection = null;
        Assert.Throws<ArgumentNullException>(() => collection.RemoveFirst());
        Assert.Throws<ArgumentNullException>(() => collection.RemoveFirst(3));
        Assert.Throws<ArgumentNullException>(() => collection.RemoveFirst(x => x > 5));
        Assert.Throws<ArgumentNullException>(() => collection.RemoveFirst(3, x => x > 5));
    }

    [Fact]
    public void RemoveFirst_ShouldRemoveFirstElement_WhenCollectionIsNotEmpty()
    {
        var collection = new List<int> { 1, 2, 3 };
        collection.RemoveFirst();
        Assert.Equal(new List<int> { 2, 3 }, collection);
    }

    [Fact]
    public void RemoveFirst_ShouldRemoveFirstElementSatisfyingCondition_WhenCollectionIsNotEmpty()
    {
        var collection = new List<int> { 1, 2, 3 };
        collection.RemoveFirst(x => x % 2 == 0);
        Assert.Equal(new List<int> { 1, 3 }, collection);
    }

    [Fact]
    public void RemoveLast_ShouldRemoveLastElement_WhenCollectionIsNotEmpty()
    {
        var collection = new List<int> { 1, 2, 3 };
        collection.RemoveLast();
        Assert.Equal(new List<int> { 1, 2 }, collection);
    }

    [Fact]
    public void RemoveLast_Predicate_ShouldRemoveLastElementSatisfyingCondition_WhenCollectionIsNotEmpty()
    {
        var collection = new List<int>
        {
            1,
            2,
            3,
            4,
            5
        };
        collection.RemoveLast(x => x % 2 == 0);
        Assert.Equal(new List<int> { 1, 2, 3, 5 }, collection);
    }

    [Fact]
    public void Shuffle_ShouldThrowArgumentNullException_WhenListIsNull()
    {
        IList<int>? list = null;
        Assert.Throws<ArgumentNullException>(() => list.Shuffle());
    }

    [Fact]
    public void Shuffle_ShouldNotThrowException_WhenListIsNotNull()
    {
        IList<int> list = new List<int> { 1, 2, 3, 4, 5 };
        var thrownException = Record.Exception(() => list.Shuffle());
        Assert.Null(thrownException);
    }

    [Fact]
    public void Shuffle_ShouldNotChangeListLength_WhenListIsNotNull()
    {
        IList<int> list = new List<int> { 1, 2, 3, 4, 5 };
        var originalCount = list.Count;
        list.Shuffle();
        Assert.Equal(originalCount, list.Count);
    }

    [Fact]
    public void Shuffle_ShouldPreserveAllElements_WhenListIsNotNull()
    {
        IList<int> originalList = new List<int> { 1, 2, 3, 4, 5 };
        var expectedList = new List<int>(originalList);
        originalList.Shuffle();
        Assert.All(expectedList, item => Assert.Contains(item, originalList));
        Assert.All(originalList, item => Assert.Contains(item, expectedList));
    }

    [Fact]
    public void Shuffle_ShouldChangeElementOrder_WhenListIsNotNull()
    {
        IList<int> originalList = new List<int> { 1, 2, 3, 4, 5 };
        var expectedList = new List<int>(originalList);
        originalList.Shuffle();
        Assert.NotEqual(expectedList, originalList);
    }
}
