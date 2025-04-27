namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Сортування з підрахунком перестановок
            int[] numbers = { 8, 5, 2, 9, 1, 5, 6 }; 
            Console.WriteLine("Початковий масив: " + string.Join(", ", numbers));
            int swaps = BubbleSort(numbers); Console.WriteLine($"Кількість перестановок: {swaps}");
            Console.WriteLine("Після сортування: " + string.Join(", ", numbers)); }

    // Task1
    private static int BubbleSort(int[] arr)
        {
            int n = arr.Length;
            int swapCount = 0;
            bool swapped;

            for (int i = 0; i < n - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapCount++;
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
            return swapCount;
        }
    }

}