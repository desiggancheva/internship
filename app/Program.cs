// See https://aka.ms/new-console-template for more information
using System;
//const short EARTH_GRAVITY=10;
const float MOON_EARTH_DIF_GRAVITY = 0.17f;




void evenOrOdd()
{

    Console.WriteLine("Enter a number = ");
    int number = int.Parse(Console.ReadLine());
    Console.WriteLine(number);
    
    if (number % 2 == 0)
    {
        Console.WriteLine("Even {0}");
    }
    else
    {
        Console.WriteLine("Odd {0}", number);
    }
}

void moonGravity()
{
    float weight = float.Parse(Console.ReadLine());

    while (weight < 0)
    {
        Console.WriteLine("Incorrect weight, the number must be greater than 0");
        weight = float.Parse(Console.ReadLine());
    }

    float newWeight = MathF.Round(weight * MOON_EARTH_DIF_GRAVITY, 3);
    Console.WriteLine(newWeight);
}



//moonGravity();

void div7and5()
{
    Console.WriteLine("Enter a number = ");
    int number = int.Parse(Console.ReadLine());
    
    if(number%5==0 && number%7==0)
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
    uint number = uint.Parse(Console.ReadLine());
    bool isPrime = true;
    
    for (int i = 2; i< Math.Sqrt(number); i++)
    {
        if (number % i == 0)
        {
            isPrime = false;
            break;
        }
    }

     Console.WriteLine(isPrime);
}
//sisPrime();

void thirdBit()
{
     uint number = uint.Parse(Console.ReadLine());
     if( (number>>3) % 2 != 0)
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
    uint number = uint.Parse(Console.ReadLine());
    int bit = int.Parse(Console.ReadLine()) - 1;
 
     if((number>>bit) % 2 != 0)
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
      uint number = uint.Parse(Console.ReadLine());
      int p=int.Parse(Console.ReadLine());
      short v=short.Parse(Console.ReadLine());

      if(p<0 || p>64 || (v != 0 && v != 1) )
      {
        Console.WriteLine("invalid arguments");
        return;
      }
     
     if(v == 1)
     {
        //number = (number) & (~(v<<p))
     }




     

}