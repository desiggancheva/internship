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
 
 claculate1(); 

