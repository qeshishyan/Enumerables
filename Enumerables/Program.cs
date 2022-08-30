using System.Collections;

var list1 = new MyList<int>();
list1.Add(71);

foreach (var item in list1)
{
    Console.WriteLine(item);
}

Console.ReadKey();
class MyList<T> : IEnumerable<T>
{
    private T[] _array;
    public MyList()
    {
   
    }
    public MyList(params T[] array)
    {
        _array = array;
    }

    public MyList<T> Add(T value)
    {
        T[] newArr = new T[_array.Length + 1];

        for (int i = 0; i < _array.Length; i++)
            newArr[i] = _array[i];
        newArr[_array.Length] = value;

        _array = newArr;
        return this;
    }

    public IEnumerator<T> GetEnumerator()
        => new MyEnumerator(_array);

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    class MyEnumerator : IEnumerator<T>
    {
        private readonly T[] _array;
        int index = -1;

        public MyEnumerator(T[] list)
        {
            _array = list;
        }

        object? IEnumerator.Current
            => Current;
        
        public T Current
        {
            get
            {
                return _array[index];
            }
        }
        public bool MoveNext()
        {
            if (index < _array.Length - 1)
            {
                index++;
                return true;
            }
            return false;
        }
        public void Dispose()
            => Reset();
        public void Reset()
            => index = -1;
    }
}
