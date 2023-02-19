// Задайте прямоугольный двумерный массив. Напишите программу, 
//которая будет находить строку с наименьшей суммой элементов.
/* Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки 
с наименьшей суммой элементов: 1 строка */

int[,] CreateArray(int x = 4, int y = 4)
{
    int[,] array = new int[x, y];
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array [ i, j ] = rnd.Next(1, 10);
        }
    }
    return;
}

int [] FindSumLines(int[,] array)
{
    int [] sumArray = new int[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - j - 1; k++)
            {
                sum += array[i, k];
            }
        }
        sumArray[i] = sum;
    }
    return sumArray;
}

int FindLess(int[] array)
{
    int minValue = array[0];
    int minValueIndex = 0;
    for (int i = 1; i < array.Length; i++)
    {
        if (minValue > array[i])
        {
            minValue = array[i];
            minValueIndex = i;
        }
    }
    return minValueIndex;
}

void PrintDoubleArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] array = CreateArray();
PrintDoubleArray(array);
int[] sumsArray = FindSumLines(array);
int lesserSumString = FindLess(sumsArray) + 1;
Console.WriteLine($"Строка с наименьшей суммой: {lesserSumString}");