// See https://aka.ms/new-console-template for more information

double getSquareRoot(int number)
{
    double result = 0;

    try
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException("Invalid number");
        }

        result = Math.Sqrt(number);

    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Good bye")
    }

    return result;
}

(int, int) setInterval()
{
    int start = 0;
    int end = 0;

    try
    {
        Console.WriteLine("Enter a start:");
        checkInput("start", ref start);

        Console.WriteLine("Enter an end:");
        checkInput("end", ref end);

    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }

    (int, int) tuple = (start, end);

    return tuple;
}

const int COUNT_OF_NUMBERS = 10;
void enterNumbers()
{
    (int, int) interval = setInterval();
    int[] numbers = new int[COUNT_OF_NUMBERS];

    try
    {
        for (int i = 0; i < COUNT_OF_NUMBERS; i++)
        {
            checkInput("a" + i, ref numbers[i]);

            if (i == 0 && interval.Item1 > numbers[i])
            {
                throw new InvalidOperationException("The interval range is incorrect");
            }

            if (i != 0 && numbers[i - 1] > numbers[i])
            {
                throw new InvalidOperationException("The interval range is incorrect");
            }
        }

        if (numbers[numbers.Length - 1] < numbers[numbers.Length - 2])
        {
            throw new InvalidOperationException("The interval range is incorrect");
        }

    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

enterNumbers();

void printFile(string filename)
{
    try
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException(filename + " does not exist");
        }

        string text = File.ReadAllText(filename);
        Console.WriteLine(text);

    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (DirectoryNotFoundException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (SecurityException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

//printFile("D:\\oop\\strings_debug\\strings_debug\\test.txt");

void downloadFileFromURL(string url, string directory)
{
    try
    {
        WebClient webClient = new WebClient();
        webClient.DownloadFile(url, directory);
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (WebException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (NotSupportedException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

}
