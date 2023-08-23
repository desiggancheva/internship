// See https://aka.ms/new-console-template for more information


//Enter count of numbers: 3
//Enter number 1: 3
//Enter number 2: 4
//Enter number 4: 8

//Min: ; Max: ; Sum: ;Average: ;


//Enter numbers: 3, 4, 5
T validation<T> (string s) where T : int || T : uint || T : short
{
    Console.WriteLine(s);
    T number;

    bool success = T.TryParse(Console.ReadLine(), out number);

    if (success)
    {
        return number;
    }
    else
    {
        throw new Exception("Invalid arguments");
    }
}
void printMinMaxSumAvrg()
{
    double min = double.MaxValue;
    double max = double.MinValue;
    double sum = 0;

    uint N = validation<uint>(Console.ReadLine());

    for (int i = 0; i < N; i++)
    {
        Console.WriteLine("Enter number {0} :", i+1);
        double number= double.Parse(Console.ReadLine());

        sum += number;

        if (number>max)
        {
            max = number;
        }

        if (number< min)
        {
            min = number;
        }
    }
    Console.WriteLine("Min: {0}; Max: {1}; Sum: {2};Average: {3};", min, max, sum, sum / N);
}

//MMSA();

int factorization(int number)
{
    int res = 1;
    
    for (int i = 1; i <= number; i++)
    {
        res *= i;
    }
    return res;
}

int factorizationRecursive(int number)
{
    int result = 1;

    if (number != 0)
    {
       result = number * factRec(number - 1);
    }

    return result;

}

static short MIN_OF_N = 2;
static short MAX_OF_N = 10;

static double MIN_OF_X = 0.5;
static double MAX_OF_X = 100;

void claculateFirstTask()
{
    double res = 1;
    int N = validation<int>(Console.ReadLine());
    double x = validation<double>(Console.ReadLine());

    if (N < MIN_OF_N || N > MAX_OF_N || x < MIN_OF_X || x > MAX_OF_X)
    {
        Console.WriteLine("Invalid argument");
        return;
    }

    for (int i = 1; i <= N; i++)
    {
        res += factorizationRecursive(i) / x;
    }

    Console.WriteLine(res);

}

//Console.WriteLine(fact(5));

//claculate1(); 

void calculateSecondTask()
{
    Console.WriteLine("Enter a N = ");
    int N = validation<int>(Console.ReadLine());
    Console.WriteLine("Enter a K = ");
    int K = validation<int>(Console.ReadLine());

    int res = factorizationRecursive(N);  // it can be res= factRec(N) / factRec(K), but in this way there are not any loops

    for (int i = 1; i <= K; i++)
    {
        res /= i;
    }

    Console.WriteLine("{0}! / {1}! = {2}", N, K, res);

}

//calculate2();

void printMatrixOfNumbers()
{
    Console.WriteLine("Enter a N = ");
    int N = validation<int>(Console.ReadLine());

    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            Console.Write("{0}, ", i+j+1);
        }

        Console.WriteLine('\n');
    }
   
}

//printMatrixOfNumbers();

void binaryToDecimal()
{
    string s = Console.ReadLine();  
    int size = s.Length;
    long res = 0;

    for (int i = 0; i < size; i++)
    {
        if (s[i] == '1')
        {
            res += (long)Math.Pow(2, size - 1 - i);
        }
    }

    Console.WriteLine(res);
}

//binaryToDecimal();

void getGreatestCommonDivider()
{
    Console.WriteLine("Enter an a = ");
    int a = validation<int>(Console.ReadLine());
    Console.WriteLine("Enter a b = ");
    int b = validation<int>(Console.ReadLine());

    if (b > a)
        {
            (a, b) = (b, a);
        }

    while (b != 0)
    {   
        int remainder = a % b;
        a = b;
        b = remainder;
    }
    Console.WriteLine(a);
}
//GCD();

int[,] generateMatrix(int N)
{
    int[,] matrix = new int[N, N];
        int top = 0;
        int bottom = N - 1;
        int left = 0;
        int right = N - 1;
        int num = 1;

        while (num <= N * N)
        {
            for (int i = left; i <= right; i++)
            {
                matrix[top, i] = num++;
            }
            top++;

            for (int i = top; i <= bottom; i++)
            {
                matrix[i, right] = num++;
            }
            right--;

            for (int i = right; i >= left; i--)
            {
                matrix[bottom, i] = num++;
            }
            bottom--;

            for (int i = bottom; i >= top; i--)
            {
                matrix[i, left] = num++;
            }
            left++;
        }

        return matrix;
}

void printMatrix(int [ , ] matrix, int size)
{
    for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
}

printMatrix(generateMatrix(3), 3);
