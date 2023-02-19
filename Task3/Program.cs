// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
/* Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20   (2*3 + 4*3) (2*4 + 4*4) (0/0 * 0/0 + 0/1 * 1/0) (0/0 * 0/1 + 0/1 * 1/1)
15 18   (3*3 + 2*3) (3*4 + 2*3) (1/0 * 0/0 + 1/1 * 1/0) (1/0 * 0/1 + 1/1 * 1/1)
*/

int[,] MultiplieMatrix(int[,] firstArray, int[,] secondArray)
{
    int[,] resultArray = new int[secondArray.GetLength(0), firstArray.GetLength(0)];
    for (int i = 0; i < firstArray.GetLength(0); i++)
    {
        for (int j = 0; j < secondArray.GetLength(1); j++)
        {
            for (int k = 0; k < firstArray.GetLength(1); k++)
            {
                resultArray[i, j] += firstArray[i, k] * secondArray[k, j];
            }
        }
    }
    return resultArray;
}

void PrintArray(int[,] array)
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

int Promt(string message)
{
    Console.WriteLine(message + " > ");
    return Convert.ToInt32(Console.ReadLine());
}

bool ValidateArrays(int[,] firstArray, int[,] secondArray)
{
    if (firstArray.GetLength(1) == secondArray.GetLength(0))
    {
        return true;
    }
    Console.WriteLine(  $"Умножение невозможно! Количество столбцов первой" +
                        "матрицы не равно количеству строк второй матрицы.");
    return false;
}

int[,] CreateArray(int x = 2, int y = 2)
{
    Random rnd = new Random();
    int[,] array = new int[x, y];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(1, 10);
        }
    }
    return array;
}

int firstMatrixRowsNumbers = Promt("Введите количество строк первой матрицы");
int firstMatrixColumnsNumbers = Promt("Введите количество столбцов первой матрицы");
int secondMatrixRowsNumbers = Promt("Введите количество строк второй матрицы");
int secondMatrixColumnsNumbers = Promt("Введите количество столбцов второй матрицы");

int[,] firstMatrix = CreateArray(firstMatrixRowsNumbers, firstMatrixColumnsNumbers);
int[,] secondMatrix = CreateArray(secondMatrixRowsNumbers, secondMatrixColumnsNumbers);

PrintArray(firstMatrix);
PrintArray(secondMatrix);

if (ValidateArrays(firstMatrix, secondMatrix))
{
    int[,] resultMatrix = MultiplieMatrix(firstMatrix, secondMatrix);
    PrintArray(resultMatrix);
}
