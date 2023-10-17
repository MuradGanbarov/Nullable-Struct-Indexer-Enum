using System;
using System.Text;

class Program
{
    static void Main()
    {
        ListInt list = new ListInt(5);

        list[0] = 10;
        list[1] = 20;
        list[2] = 30;
        list[3] = 40;
        list[4] = 50;

        Console.WriteLine("ListInt: " + list);

        list.Add(60);
        list.AddRange(70, 80, 90);
        Console.WriteLine("ListInt after Add and AddRange: " + list);

        Console.WriteLine("Contains 30: " + list.Contains(30));
        Console.WriteLine("Sum: " + list.Sum());

        list.Remove(20);
        list.RemoveRange(40, 60, 100); // 100 not found
        Console.WriteLine("ListInt after Remove and RemoveRange: " + list);
    }
}



public class ListInt
{
    private int[] array;

    public ListInt(int size)
    {
        array = new int[size];
    }

    public int this[int index]
    {
        get
        {
            if (index >= 0 && index < array.Length)
                return array[index];
            throw new IndexOutOfRangeException("Index out of range.");
        }
        set
        {
            if (index >= 0 && index < array.Length)
                array[index] = value;
            else
                throw new IndexOutOfRangeException("Index out of range.");
        }
    }

    public void Add(int num)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = num;
    }

    public void AddRange(params int[] nums)
    {
        int newSize = array.Length + nums.Length;
        Array.Resize(ref array, newSize);
        Array.Copy(nums, 0, array, array.Length - nums.Length, nums.Length);
    }

    public bool Contains(int num)
    {
        return Array.IndexOf(array, num) != -1;
    }

    public int Sum()
    {
        int sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }
        return sum;
    }

    public void Remove(int num)
    {
        int index = Array.IndexOf(array, num);
        if (index != -1)
        {
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }
            Array.Resize(ref array, array.Length - 1);
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
        for (int i = 0; i < array.Length; i++)
        {
            sb.Append(array[i]);
            if (i < array.Length - 1)
                sb.Append(", ");
        }
        return sb.ToString();
    }
}