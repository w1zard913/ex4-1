using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Xml.Linq;

namespace ex4_1
{
    internal class LineArray<T>
    {
        private T[] _array;
        private int _capacity;
        private int _size;

        public LineArray(int capacity)
        {
            _capacity = capacity;
            _array = new T[capacity];
            _size = 0;
        }

        public LineArray() : this(7)
        {
        }

        public void Add(T item)
        {
            if (_size >= _capacity)
            {
                _capacity = _capacity * 2 + 1;
                Array.Resize(ref _array, _capacity);
            }
            _array[_size] = item;
            _size++;
        }

        public void Display()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.Write(_array[i]);
                Console.Write(" ");
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= _capacity) return;
            T[]new_array = new T[_array.Length - 1];
            Array.Copy(_array, 0, new_array, 0, index);
            Array.Copy(_array, index + 1, new_array, index, _array.Length - index - 1);
        }

        public T[] Where(Func<T, bool> condition)
        {
            T[] newArray = new T[_array.Length];
            int count = 0;
            for (int i = 0; i < newArray.Length; i++)
            {
                if (condition(_array[i]))
                {
                    newArray[count] = _array[i];
                    count++;
                }
            }
            Array.Resize(ref newArray, count);
            return newArray;
        }

        public void SortArray()
        {
            Array.Sort(_array);
        }

        public int Count()
        {
            return _array.Length;
        }

        public int CountWhere(Func<T, bool> condition)
        {
            return Where(condition).Length;
        }

        public bool Check(Func<T, bool> condition)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (condition(_array[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CheckForAllElements(Func<T, bool> condition)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (!condition(_array[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckElement(T element)
        {
            return Array.IndexOf(_array, element) != -1;
        }

        public T CheckElementWith(Func<T, bool> condition)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (condition(_array[i]))
                {
                    return _array[i];
                }
            }
            throw new InvalidOperationException();
        }

        public void ApplyForAllElements(Func<T, T> condition)
        {
            for (int i = 0; i < _array.Length; ++i)
            {
                _array[i] = condition(_array[i]);
            }
        }

        //public T GetRightTypeElement(string)

        public void RevarsedArray()
        {
            Array.Reverse(_array);
        }

        public T Maxelement()
        {
            if (typeof(T) == typeof(int) || typeof(T) == typeof(double))
            {
                T maxi = _array[0];
                
                for (int i =0; i < _array.Length; i++)
                {

                    if (maxi < _array[i])
                    {

                        maxi = _array[i];
                    }
                }
            }
            throw new InvalidOperationException();

        }

        public T FindMinElement(Func<T, T, int> comparer)
        {
            if (_array.Length == 0)
            {
                throw new InvalidOperationException("Array is empty");
            }

            T min = _array[0];
            for (int i = 1; i < _array.Length; i++)
            {
                if (comparer(_array[i], min) < 0)
                {
                    min = _array[i];
                }
            }
            return min;
        }

        public T[] ElemetnsFromIndex(int index, int elements)
        {
            if (index + elements >= _array.Length)
            {
                throw new InvalidOperationException("Invalid index");
            }
            T[] values = new T[elements];
            for (int i = index; i < _array.Length; ++i)
            {
                values[i] = _array[i];
            }
            return values;
        }

        public TMin FindMin<TMin>(Func<T, TMin> selector)
        {
            if (_array == null || _array.Length == 0)
            {
                throw new InvalidOperationException("Empty array");
            }
            var min = _array.Min(selector);
            return min;
        }

        public TMax FindMax<TMax>(Func<T, TMax> selector)
        {
            if (_array == null || _array.Length == 0)
            {
                throw new InvalidOperationException("Empty array");
            }
            var max = _array.Max(selector);
            return max;
        }
    }
}
