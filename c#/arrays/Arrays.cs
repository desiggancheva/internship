// See https://aka.ms/new-console-template for more information

void printArray(int [] array, int size)
{
    for (int i = 0; i < size; i++)
    {
        Console.WriteLine(array [i]);
    }
}

int[] allocateArray(int size)
{
    if (size < 0 || size > 20)
    {
        throw new ArgumentOutOfRangeException("The size must be betwen 0 and 21 \n");
    }

    int [] data = new int [size];

    for (int i = 0; i < size; i++)
    {
        data [i] = i * 5;
    }

    return data;   
}

//printArray(allocateArray(5), 5);

bool compareArrays(int [] leftArg, int [] rightArg, int N)
{
    bool equal = true;
    int index = 0;

    while (equal && index < N)
    {
        if (leftArg [index] != rightArg [index])
        {
            equal = false;
        }  
         
         index++;

    }

    return equal;
}

int [] readArray(int size)
{
    int [] data = new int [size];

    for (int i = 0; i < size; i++)
    {
        data [i] = int.Parse(Console.ReadLine());
    }

    return data;
}

//Console.WriteLine(compareArrays(readArray(3), readArray(3), 3));

int maxSequence(int [] array, int size) 
{
    int maxSequence = 1;
    int tempMaxSequence = 1;
    for (int i = 0; i < size-1; i++)
    {
        if (array [i] == array [i+1])
        {
            tempMaxSequence++;
        }
        else
        {
            if(tempMaxSequence > maxSequence)
            {
                maxSequence = tempMaxSequence;
            }

            tempMaxSequence = 1;
        }
    }

    return maxSequence;

}

//Console.WriteLine(maxSequence(readArray(10), 10));

int maxIncreasingSequence(int [] array, int size) 
{
    int maxIncreasingSequence = 1;
    int tempMaxIncreasingSequence = 1;
    for (int i = 0; i < size-1; i++)
    {
        if (array [i] < array [i+1])
        {
            tempMaxIncreasingSequence++;
        }
        else
        {
            if(tempMaxIncreasingSequence > maxIncreasingSequence)
            {
                maxIncreasingSequence = tempMaxIncreasingSequence;
            }

            tempMaxIncreasingSequence = 1;
        }
    }

    return maxIncreasingSequence;

}

//Console.WriteLine(maxIncreasingSequence(readArray(8), 8));

int [] selectionSort(int [] array, int size)
{

    for (int i = 0; i < size - 1; i++)
    {
        int minIndex = i;

        for (int j = i + 1; j < size; j++)
        {
            if (array [j] < array [minIndex])
            {
                minIndex = j;
            }

        }
        (array [minIndex], array [i]) = (array [i], array [minIndex]);
    }
    return array;
}

//printArray(selectionSort(readArray(5), 5), 5);

int maxSumOfK(int [] array, int size, int K)
{
    int [] sortedArray = selectionSort(array, size);
    int sum = 0;

    for (int i = size - K; i < size; i++)
    {
        sum += sortedArray [i];
    }

    return sum;
}

//Console.WriteLine(maxSumOfK(readArray(8), 8, 3));

int binarySearched(int [] array, int size, int x)
{
    int index = -1;

    int left = 0;
    int right = 0;
    int mid;

    while (left <= right)
    {
        mid = (right - left) / 2;
        
        if (array [mid] < x)
        {
            left = mid + 1;
        }
        else if (array [mid] > x)
        {
            right = mid - 1;
        }
        else
        {
            index = mid;
            break;
        }
    }

    return index;
}

//Console.WriteLine(binarySearched(readArray(10), 10, 1));

char [] alphabet = new char [27];
for (int i = 0; i < 26; i++)
{
    alphabet [i] = (char)((int)'a' + i);
}

//Console.WriteLine (alphabet);

// Write a program that creates an array containing all letters from the alphabet (a-z). Read a word from the console and print the index of each of its letters in the array.
// there is no need for an array, if taken the ASCII code of each letter in the word and substracted with the ACSII code of the 'a' it will give the right index

bool [] primeNumbers(int N)
{
    bool [] primeNumbers = new bool [N];
    primeNumbers [0] =  primeNumbers [1] = true;

    for (int i = 2; i < N; i++)
    {
        if (!primeNumbers [i])
        {
            for (int j = i*2; j < N; j += i)
            {
                 primeNumbers [j] = true;
            }
        }
    }
    return primeNumbers;
}

void printPrimeNumbers(bool [] primes, int N)
{
    for (int i = 0; i < N; i++)
    {
        if (!primes [i])
        {
            Console.WriteLine (i);
        }
    }
}


//printPrimeNumbers(primeNumbers(20), 20);

int removeElemts(int [] array, int size)
{
  
    int smaller = 0; 

    for (int i = 0; i < size-1; i++)
    {
        if (array [i] > array [i + 1])
        {
             smaller++;
        }
       
    }

    return smaller;
}

Console.WriteLine (removeElemts(readArray(10), 10));