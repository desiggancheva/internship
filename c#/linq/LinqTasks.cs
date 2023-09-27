// See https://aka.ms/new-console-template for more information
using System.Reflection.PortableExecutable;
using Microsoft.VisualBasic;

public class LinqTasks
{
    void printEvenNumbers(int[] numbers)
    {
        var evenNumbers =
            from evenNumber in numbers
            where evenNumber % 2 == 0
            select evenNumber;

        foreach (int evenNumber in evenNumbers)
        {
            Console.WriteLine(evenNumber);
        }
    }

    int[] numbers = { 1, 2, 3, 2, 5, 6, 7 };

    //printEvenNumbers(numbers);

    void prinNumbersInGivenDiapason(int beg, int end, int[] numbers)
    {
        var numbersInDiapason =
            from numberInDiapason in numbers
            where numberInDiapason > beg && numberInDiapason < end
            select numberInDiapason;

        foreach (int numberInDiapason in numbersInDiapason)
        {
            Console.WriteLine(numberInDiapason);
        }
    }

    //prinNumbersInGivenDiapason(3, 6, numbers);

    void printSquareOfNumbers(int[] numbers)
    {
        var squareOfNumbers =
            from squareNumber in numbers
            select squareNumber * squareNumber;

        foreach (int squareNumber in squareOfNumbers)
        {
            Console.WriteLine(squareNumber);
        }
    }

    //printSquareOfNumbers(numbers);

    void printFrequencyOfNumbers(int[] numbers)
    {
        var countOfNumbers =
            from number in numbers
            group number by number into count
            select count;

        foreach (var count in countOfNumbers)
        {
            Console.WriteLine("Number " + count.Key + " - " + count.Count() + "times");
        }
    }

    // printFrequencyOfNumbers(numbers);

    void printFrequencyOfCharactersInString(string str)
    {
        var countOfCharacters =
            from character in str
            group character by character into count
            select count;

        foreach (var count in countOfCharacters)
        {
            Console.WriteLine("Character " + count.Key + "-" + count.Count() + " times");
        }
    }

    //printFrequencyOfCharactersInString("apple");

    void printDaysOfWeek(string[] daysOfTheWeek)
    {
        var days =
            from dayOfWeek in daysOfTheWeek
            select dayOfWeek;

        foreach (string day in days)
        {
            Console.WriteLine(day);
        }
    }

    void printMultiplicationFrequencyNumber(int[] number)
    {
        var output =
            from num in numbers
            group num by num into count
            select count;

        foreach (var num in output)
        {
            Console.WriteLine(num.Key + " " + num.Count() * num.Key + " " + num.Count());
        }
    }

    //printMultiplicationFrequencyNumber(numbers);

    void printStringByStartAndEnding(string[] strings, char start, char end)
    {
        var output =
            from str in strings
            where str.StartsWith(start) && str.EndsWith(end)
            //where str.EndsWith(end)
            select str;

        foreach (var str in output)
        {
            Console.WriteLine(str);
        }
    }

    string[] cities = { "ROME", "AMSTERDAM", "PARIS" };

    //printStringByStartAndEnding(cities, 'A', 'M');

    void printNumberGreaterThan(int[] number, int toCompare)
    {
        var greaterNumbers =
            from num in numbers
            where num > toCompare
            select num;

        foreach (var num in greaterNumbers)
        {
            Console.WriteLine(num);
        }
    }

    //printNumberGreaterThan(numbers, 3);

    void printTopNNumbers(int[] numbers, int n)
    {
        List<int> listNumber = numbers.ToList();
        listNumber.Sort();
        listNumber.Reverse();

        foreach (int topn in listNumber.Take(n))
        {
            Console.WriteLine(topn);
        }
    }

    //printTopNNumbers(numbers, 3);

    public class Item_mast
    {
        public int ItemId { get; set; }
        public string ItemDes { get; set; }
    }

    public class Purchase
    {
        public int InvNo { get; set; }
        public int ItemId { get; set; }
        public int PurQty { get; set; }
    }

    static void Main(string[] arg)
    {
        List<Item_mast> itemlist = new List<Item_mast>
        {
           new Item_mast { ItemId = 1, ItemDes = "Biscuit  " },
           new Item_mast { ItemId = 2, ItemDes = "Chocolate" },
           new Item_mast { ItemId = 3, ItemDes = "Butter   " },
           new Item_mast { ItemId = 4, ItemDes = "Brade    " },
           new Item_mast { ItemId = 5, ItemDes = "Honey    " }
        };

        List<Purchase> purchlist = new List<Purchase>
        {
           new Purchase { InvNo = 100, ItemId = 3,  PurQty = 800 },
           new Purchase { InvNo = 101, ItemId = 2,  PurQty = 650 },
           new Purchase { InvNo = 102, ItemId = 3,  PurQty = 900 },
           new Purchase { InvNo = 103, ItemId = 4,  PurQty = 700 },
           new Purchase { InvNo = 104, ItemId = 3,  PurQty = 900 },
           new Purchase { InvNo = 105, ItemId = 4,  PurQty = 650 },
           new Purchase { InvNo = 106, ItemId = 1,  PurQty = 458 }
        };

        var joinPurchaseToItems =
            from item in itemlist
            join purchase in purchlist on item.ItemId equals purchase.ItemId
            select new
            {
                itid = item.ItemId,
                itdes = item.ItemDes,
                prqty = purchase.PurQty
            };

        foreach (var data in joinPurchaseToItems)
        {
            Console.WriteLine(data.itid + "\t\t" + data.itdes + "\t\t" + data.prqty);
        }
    }
}

