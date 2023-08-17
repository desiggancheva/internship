// void printMatrix(int[,] matrix, int size)
// {
//     for (int i = 0; i < size; i++)
//     {
//         for (int j = 0; j < size; j++)
//         {
//             Console.Write(matrix[i, j] + " ");
//         }
//         Console.WriteLine();
//     }
// }

// void printArrayOfString(string[] array, int size)
// {
//     for (int i = 0; i < size; i++)
//     {
//         Console.WriteLine(array[i]);
//     }
// }

// int[,] generateSpiralMatrix(int N)
// {
//     int[,] matrix = new int[N, N];
//     int top = 0;
//     int bottom = N - 1;
//     int left = 0;
//     int right = N - 1;
//     int num = 1;

//     while (num <= N * N)
//     {
//         for (int i = left; i <= right; i++)
//         {
//             matrix[top, i] = num++;
//         }
//         top++;

//         for (int i = top; i <= bottom; i++)
//         {
//             matrix[i, right] = num++;
//         }
//         right--;

//         for (int i = right; i >= left; i--)
//         {
//             matrix[bottom, i] = num++;
//         }
//         bottom--;

//         for (int i = bottom; i >= top; i--)
//         {
//             matrix[i, left] = num++;
//         }
//         left++;
//     }

//     return matrix;
// }

// int[,] generateMatrixA(int N)
// {
//     int[,] matrix = new int[N, N];
//     int el = 1;

//     for (int i = 0; i < N; i++)
//     {
//         //el++;
//         for (int j = 0; j < N; j++)
//         {
//             matrix[j, i] = el++;
//         }
//     }
//     return matrix;
// }
// int[,] generateMatrixB(int N)
// {
//     int[,] matrix = new int[N, N];
//     int el = 1;
//     bool line = true;

//     for (int i = 0; i < N; i++)
//     {
//         //el++;
//         for (int j = 0; j < N; j++)
//         {
//             if (line)
//             {
//                 matrix[j, i] = el++;
//             }
//             else
//             {
//                 matrix[N - j - 1, i] = el++;
//             }
//         }

//         line = !line;
//     }
//     return matrix;
// }
// //printMatrix (generateMatrixB(4), 4);
// int sumOfMatrixN(int[,] matrix, int N)
// {
//     int sum = 0;

//     for (int i = 0; i < N; i++)
//     {
//         for (int j = 0; j < N; j++)
//         {
//             sum += matrix[i, j];
//         }
//     }

//     return sum;
// }

// int[,] readMatrix(int n, int m)
// {
//     int[,] matrix = new int[n, m];
//     Console.WriteLine("Enter your values separated by space.");
//     for (int i = 0; i < n; i++)
//     {
//         var values = (Console.ReadLine().Split(' '));
//         for (int j = 0; j < m; j++)
//         {
//             matrix[i, j] = int.Parse(values[j]);
//         }
//     }
//     return matrix;

// }
// int[,] generateMinorNxN(int[,] matrix, int begRow, int begCol, int N)
// {
//     int[,] minor = new int[N, N];

//     for (int i = 0; i < N; i++)
//     {
//         for (int j = 0; j < +N; j++)
//         {
//             minor[i, j] = matrix[i + begRow, j + begCol];
//         }
//     }

//     return minor;
// }

// int maxSumMatrix(int[,] matrix, int rows, int cols, int N)
// {
//     int maxSum = int.MinValue;

//     for (int i = 0; i < rows - N; i++)
//     {
//         for (int j = 0; j < cols - N; j++)
//         {
//             if (maxSum < sumOfMatrixN(generateMinorNxN(matrix, i, j, N), N))
//             {
//                 maxSum = sumOfMatrixN(generateMinorNxN(matrix, i, j, N), N);
//             }
//         }
//     }
//     return maxSum;
// }

// //Console.WriteLine(maxSumMatrix(readMatrix(5,5),5,5,3));

// string[] sortByStringLenght(string[] array, int size)
// {
//     for (int i = 0; i < size - 1; i++)
//     {
//         int minIndex = i;

//         for (int j = i + 1; j < size; j++)
//         {
//             if (array[j].Length < array[minIndex].Length)
//             {
//                 minIndex = j;
//             }

//         }
//         (array[minIndex], array[i]) = (array[i], array[minIndex]);
//     }
//     return array;

// }
// string[]  temp= {"abcsd", "abg", "akkseka"};
// printArrayOfString(sortByStringLenght( temp, 3), 3);

class Matrix
{
    private int[,] matrix;
    private int rows = 0;
    private int cols = 0;

    public Matrix(int rows, int cols)
    {
        this.matrix = new int[rows, cols];
        this.rows = rows;
        this.cols = cols;
    }

    public void initilizeMatrix()
    {
        Console.WriteLine("Enter your values separated by space.");
        for (int i = 0; i < this.rows; i++)
        {
            var values = (Console.ReadLine().Split(' '));
            for (int j = 0; j < this.cols; j++)
            {
                matrix[i, j] = int.Parse(values[j]);
            }
        }

    }
    public Matrix operator *(Matrix otherMatrix)
    {
        if (this.cols != otherMatrix.rows)
        {
            throw new ArgumentException("Those matrix can not be multiplide");
        }
       
        Matrix result = new Matrix(this.rows, otherMatrix.cols);

        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < otherMatrix.cols; j++)
            {
                int sum = 0;
                for (int k = 0; k < this.cols; k++)
                {
                    sum += this.matrix[i, k] * otherMatrix.matrix[k, j];
                }
                result.matrix[i, j] = sum;
            }
        }

        return result;


    }

    // public Matrix operator += (Matrix otherMatrix)
    // {
    //     if (otherMatrix.rows != this.rows || otherMatrix.cols != this.cols)
    //     {
    //         throw new ArgumentException("The matrix should be with the same count of rows and cols");
    //     }
    //     else
    //     {
    //         for (int i = 0; i < rows; i++)
    //         {
    //             for (int j = 0; j < cols; j++)
    //             {
    //                 this.matrix[i, j] += otherMatrix.matrix[i, j];
    //             }
    //         }
    //     }

    //     return this;
    // }


}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter your values separated by space.");

        var m = new Matrix(2, 2);
        m.initilizeMatrix();
    }
}