// See https://aka.ms/new-console-template for more information
void printEvenNumbers(int[] numbers)
{
    var evenNumbers =
        from evenNumber in numbers
        where evenNumber != null && evenNumber % 2 == 0
        select evenNumber;

    foreach (int evenNumber in evenNumbers)
    {
        Console.WriteLine(evenNumber);
    }
}

int[] numbers = {1, 2, 3, 4, 5, 6, 7};

printEvenNumbers(numbers);

void prinNumbersInGivenDiapason(int beg, int end, int[] numbers)
{
    var numbersInDiapason =
        from numberInDiapason in numbers
        where numberInDiapason != null && numberInDiapason > beg && numberInDiapason < end
        select numberInDiapason;
    
    foreach (int numberInDiapason in numbersInDiapason)
    {
        Console.WriteLine(numberInDiapason);
    }    
}

prinNumbersInGivenDiapason(3, 6, numbers);