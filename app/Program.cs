// See https://aka.ms/new-console-template for more information
using System;
//const short EARTH_GRAVITY=10;

validation<T> ()
{
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
void evenOrOdd()
{
    Console.WriteLine("Enter a number = ");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine(number);

    if (number % 2 == 0)
    {
        Console.WriteLine("Even {0}", number);
    }
    else
    {
        Console.WriteLine("Odd {0}", number);
    }
}

void printMoonGravity()
{
    float weight = float.Parse(Console.ReadLine());

    while (weight < 0)
    {
        Console.WriteLine("Incorrect weight, the number must be greater than 0");
        weight = float.Parse(Console.ReadLine());
    }

    float newWeight = MathF.Round(weight * Constants.MOON_EARTH_DIF_GRAVITY, 3);
    Console.WriteLine(newWeight);
}

//moonGravity();

void div7and5()
{
    Console.WriteLine("Enter a number = ");
    int number = int.Parse(Console.ReadLine());

    if (number % 5 == 0 && number % 7 == 0)
    {
        Console.WriteLine("true {0}", number);
    }
    else
    {
        Console.WriteLine("false {0}", number);
    }
}

//div7and5();

void isPrime()
{
    uint number = validation<uint>();
    bool isPrime = true;
    int dev = 2;

    while (isPrime && dev < Math.Sqrt(number))
    {
        if (number % dev == 0)
        {
            isPrime = false;
        }

        dev++;
    }

    // for (int i = 2; i < Math.Sqrt(number); i++)
    // {
    //     if (number % i == 0)
    //     {
    //         isPrime = false;
    //         break;
    //     }
    // }

    Console.WriteLine(isPrime);
}

//isPrime();

void thirdBit()
{
    uint number = validation<uint>();
    if ((number >> Constants.THEERD_BIT) % 2 != 0)
    {
        Console.WriteLine("true");
    }
    else
    {
        Console.WriteLine("false");
    }

}

//thirdBit();

void NthBits()
{
    uint number = validation<uint>();
    int bit = validation<int>() - 1;

    if ((number >> bit) % 2 != 0)
    {
        Console.WriteLine("1");
    }
    else
    {
        Console.WriteLine("0");
    }
}

//NthBits();

void modifyBits()
{
    uint number = validation<uint>();
    int p = int.Parse(Console.ReadLine());
    short v = short.Parse(Console.ReadLine());

    if (p < 0 || p > 64 || (v != 0 && v != 1))
    {
        Console.WriteLine("invalid arguments");
        return;
    }

    if (v == 1)
    {
        //number = (number) & (~(v<<p))
    }


}

bool checkForInvalidInputSumOfThree(int number)
{
    return number < Constants.MIN_SUMOF_THREE || number > Constants.MAX_SUMOF_THREE;
}

void sumOf3Numbers()
{
    Console.WriteLine("a = ");
    short a = short.Parse(Console.ReadLine());
    Console.WriteLine("b = ");
    short b = short.Parse(Console.ReadLine());
    Console.WriteLine("c = ");
    short c = short.Parse(Console.ReadLine());

    if (checkForInvalidInputSumOfThree(a) || checkForInvalidInputSumOfThree(b) || checkForInvalidInputSumOfThree(c))
    {
        Console.WriteLine("Invalid arguments");
    }

    int sum = a + b + c;

    Console.WriteLine(sum);

}

void sumOfNumbers(int number)
{
    int sum = 0;

    for (int i = 0; i < number; i++)
    {
        Console.WriteLine("{0} number = ", i+1);
        short a = short.Parse(Console.ReadLine());
        sum += a;
    }

}

//sumOf3Numbers();

void maxOfNumbers()
{
    Console.WriteLine("a = ");
    int a = int.Parse(Console.ReadLine());
    Console.WriteLine("b = ");
    int b = int.Parse(Console.ReadLine());

    if (a > b)
    {
        Console.WriteLine(a);
    }
    else
    {
        Console.WriteLine(b);
    }
}

//maxOfNumbers();

void quadraticEquation()
{
    Console.WriteLine("a = ");
    int a = int.Parse(Console.ReadLine());
    Console.WriteLine("b = ");
    int b = int.Parse(Console.ReadLine());
    Console.WriteLine("c = ");
    int c = int.Parse(Console.ReadLine());

    double d = Math.Sqrt(b * b - 4 * a * c);
    double x1 = (-b + d) / (2 * a);
    double x2 = (-b - d) / (2 * a);

    Console.WriteLine("{0}, {1}", x1, x2);

}

//quadraticEquation();

void numbersFromOntoToN()
{
    Console.WriteLine("N = ");
    uint N = validation<uint>();

    if ((N == 0) || N > 1000)
    {
        Console.WriteLine("Invalid arguments");
    }
    else
    {
        for (int i = 1; i <= N; i++)
        {
            Console.WriteLine(i);
        }

    }
}

//numbersFromOntoToN();

int fibRec(int number)
{
    int res = 0;

    if (number == 2 || number == 3)
    {
        res = 1;
    }
    else
    {
        res = fibRec(number - 1) + fibRec(number - 2);
    }

    return res;

}
Console.WriteLine(fibRec( 5 ));

int fibCycle(int number)
{
    int prevNumber = 0;
    int nextNumber = 1;
    int res = 0;
    
    for (int i = 0; i < number - 2; i++)
    {
        res = prevNumber + nextNumber;
        prevNumber = nextNumber;
        nextNumber = res;
    }

    return res;
}

Console.WriteLine(fibCycle( 5 ));

void interval()
{
    Console.WriteLine("N = ");
    uint N = uint.Parse(Console.ReadLine());
    Console.WriteLine("M = ");
    uint M = uint.Parse(Console.ReadLine());

    for (uint i = N; i < M; i++)
    {
        if (i % 5 == 0)
        {
            Console.WriteLine(i);
        }
    }
}

//interval();