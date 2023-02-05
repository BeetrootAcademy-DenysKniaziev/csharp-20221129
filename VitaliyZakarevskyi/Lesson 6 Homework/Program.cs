using System.Threading.Tasks.Dataflow;

internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = { 2, 7, 5, 4, 6, 8, 9 };


        InsertionSort(numbers);
        BubbleSort(numbers);
        SelectionSort(numbers);


        foreach (int item in numbers)
            Console.WriteLine(item);
    }
    static void BubbleSort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - 1 - 1; j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = temp;
                }

            }
        }
    }

    static void SelectionSort(int[] numbers)
    {

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int min = i;
            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[min] > numbers[j])
                {
                    min = j;
                }
            }
            int temp = numbers[i];
            numbers[i] = numbers[min];
            numbers[min] = temp;
        }
    }

    static void InsertionSort(int[] numbers)
    {
        for(int i = 1; i < numbers.Length; i++)
        {
            int temp = numbers[i];
            int j = i - 1;

            while(j >= 0 && numbers[j] > 10)
            {
                numbers[j + 1] = numbers[j];
                j--;

            }
            numbers[j + 1] = temp;
        }
    }
}
enum SortAlgorithmType
{






}
