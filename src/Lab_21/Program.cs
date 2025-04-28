using System;

namespace Lab21
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Task1. Узагальнений контейнер
            Container<int> intContainer = new Container<int> { Value = 42 };
            Container<string> stringContainer = new Container<string> { Value = "Hello" };
            intContainer.ShowInfo();
            stringContainer.ShowInfo();
            Console.WriteLine();

            // Task2. Узагальнений метод пошуку
            int[] intArray = { 3, 7, 1, 9, 4 };
            double[] doubleArray = { 2.5, 7.8, 1.2, 9.3 };
            string[] stringArray = { "apple", "zebra", "banana" };

            Console.WriteLine($"Максимум int: {FindMax(intArray)}");
            Console.WriteLine($"Максимум double: {FindMax(doubleArray)}");
            Console.WriteLine($"Максимум string: {FindMax(stringArray)}");
        }
        //Task1
        static T FindMax<T>(T[] array) where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
                throw new ArgumentException("Масив не може бути порожнім або null");

            T max = array[0];
            foreach (var item in array)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }
    }

    // Task2
    public class Container<T>
    {
        public T Value { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Значення: {Value}, Тип: {typeof(T).Name}");
        }
    }

}