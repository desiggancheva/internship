// See https://aka.ms/new-console-template for more information


//Enter count of numbers: 3
//Enter number 1: 3
//Enter number 2: 4
//Enter number 4: 8

//Min: ; Max: ; Sum: ;Average: ;


//Enter numbers: 3, 4, 5

void MMSA()
{
    double min = double.MaxValue;
    double max = double.MinValue;
    double sum = 0;

    uint N = uint.Parse(Console.ReadLine());

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

int fact(int number)
{
    int res = 1;
    for (int i = 1; i <= number; i++)
    {
        res *= i;
    }
    return res;
}

int factRec(int number)
{
    if (number == 0)
    {
        return 1;
    }

    return number * factRec(number - 1);
}

void claculate1()
{
    double res = 1;
    int N = int.Parse(Console.ReadLine());
    double x = double.Parse(Console.ReadLine());

    if (N < 2 || N > 10 || x < 0.5 || x > 100)
    {
        Console.WriteLine("Invalid argument");
        return;
    }

    for (int i = 1; i <= N; i++)
    {
        res += factRec(i) / x;
    }

    Console.WriteLine(res);

}

//Console.WriteLine(fact(5));

//claculate1(); 

void calculate2()
{
    Console.WriteLine("Enter a N = ");
    int N = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter a K = ");
    int K = int.Parse(Console.ReadLine());

    int res = factRec(N);  // it can be res= factRec(N) / factRec(K), but in this way there are not any loops

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
    int N = int.Parse(Console.ReadLine());

    int [ , ] matrix= new int [N, N];

    for (int i = 0; i < N; i++)
    {
        for (int j = 0; j < N; j++)
        {
            matrix[i,j] = i+j+1;
            Console.Write("{0}, ",matrix[i , j]);
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

void GCD()
{
    Console.WriteLine("Enter an a = ");
    int a = int.Parse(Console.ReadLine());
    Console.WriteLine("Enter a b = ");
    int b = int.Parse(Console.ReadLine());
    if (b > a)
        {
            int temp = a;
            a = b;
            b = a;
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
