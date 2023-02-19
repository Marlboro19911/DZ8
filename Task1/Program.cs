// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
/* Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

int[,] CreateArray(int x = 3, int y = 4)
{
    int[,] array = new int[x, y];
    Random rnd = new Random();
    for    (int i = 0;   i < array.GetLength(0); i++)
    {
        for    (int j = 0;   j < array.GetLength(1); j++)
        {
            array[ i, j ] = rnd.Next(1, 10);
        }
    }
    return;
}

void PrintArray(int[,] array, string msg)
{
    Console.WriteLine();
    for    (int i = 0;   i < array.GetLength(0); i ++)
    {
        for    (int j = 0;   j < array.GetLength(1); j ++)
        {
            Console.Write(array [i, j] + " ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] SortArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - j - 1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    int temp = array[i, k];
                    array[i, k] = array[i, k + 1];
                    array[i, k + 1] = temp;
                }
            }
        }
    }
    return array;
}

int [,] baseArray = CreateArray();
PrintArray(baseArray, "Базовый массив: ");
int [,] sortedArray = SortArray(baseArray);
PrintArray(sortedArray, "Сортированный по убыванию массив: ");