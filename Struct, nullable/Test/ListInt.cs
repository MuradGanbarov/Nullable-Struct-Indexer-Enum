using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class ListInt
    {
        private int[] _array;

        public ListInt(int size)
        {
            _array = new int[size];
        }

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < _array.Length)
                    return _array[index];
                throw new IndexOutOfRangeException("Bu indeks intervaldan kenardi");
            }
            set
            {
                if (index >= 0 && index < _array.Length)
                    _array[index] = value;
                else
                    throw new IndexOutOfRangeException("Bu indeks intervaldan kenardi"); //Console.WriteLine error verdiyinchin, bu usulla getdim.
            }
        }

        public void Add(int num)
        {
            Array.Resize(ref _array, _array.Length + 1);
            _array[_array.Length - 1] = num;
        }

        public void AddRange(params int[] nums)
        {
            int newSize = _array.Length + nums.Length;
            Array.Resize(ref _array, newSize);
            Array.Copy(nums, 0, _array, _array.Length - nums.Length, nums.Length);
        }

        public bool Contains(int num)
        {
            return Array.IndexOf(_array, num) != -1;
        }

        public int Sum()
        {
            int sum = 0;
            foreach (int num in _array)
            {
                sum += num;
            }
            return sum;
        }

        public void Remove(int num)
        {
            int index = Array.IndexOf(_array, num);
            if (index != -1)
            {
                for (int i = index; i < _array.Length - 1; i++)
                {
                    _array[i] = _array[i + 1];
                }
                Array.Resize(ref _array, _array.Length - 1);
            }
        }

        public void RemoveRange(params int[] nums)
        {
            foreach (int num in nums)
            {
                while (Contains(num))
                {
                    Remove(num);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _array.Length; i++)
            {
                sb.Append(_array[i]);
                if (i < _array.Length - 1)
                    sb.Append(", ");
            }
            return sb.ToString();
        }
    }
}
