// See https://aka.ms/new-console-template for more information
const char OPENING_BRACET = '(';
const char CLOSING_BRACET = ')';

bool areBracetsCorrect(string s)
{
    bool areCorrect = false;

    if (s == null)
    {
        areCorrect = true;
    }
    else
    {
        int countOfOpeningBracets = s.Split(OPENING_BRACET).Length - 1;
        int countOfClosingBracets = s.Split(CLOSING_BRACET).Length - 1;

        if (countOfOpeningBracets == countOfClosingBracets)
        {
            areCorrect = true;
        }
    }

    return areCorrect;

}

//Console.WriteLine(areBracetsCorrect("((a+b)+5(a+2)"));

int countOfSubstringInString(string sts, string subStr)
{
    int beg = 0;
    int end = sts.Length - subStr.Length + 1;
    int subStrLenght = subStr.Length;
    int counter = 0;

    while (beg < end)
    {
        if (sts.Substring(beg, subStrLenght) == subStr)
        {
            counter++;
        }

        beg += 1;
    }

    return counter;
}

//Console.WriteLine(countOfSubstringInString("The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.", "in"));

string ParseTags(string text)
{
    string result = "";
    int currentIndex = 0;

        while (currentIndex < text.Length)
        {
            int openTagIndex = text.IndexOf("<upcase>", currentIndex, StringComparison.OrdinalIgnoreCase);

            if (openTagIndex == -1)
            {
                result += text.Substring(currentIndex);
                break;
            }

            result += text.Substring(currentIndex, openTagIndex - currentIndex);

            int closeTagIndex = text.IndexOf("</upcase>", openTagIndex + 8, StringComparison.OrdinalIgnoreCase);

            if (closeTagIndex == -1)
            {
                result += text.Substring(openTagIndex);
                break;
            }

            string tagContent = text.Substring(openTagIndex + 8, closeTagIndex - openTagIndex - 8);
            result += tagContent.ToUpper();

            currentIndex = closeTagIndex + 9;
        }

        return result;
}

Console.WriteLine(ParseTags("We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else."));

string EncodeDecode(string input, string key)
{
    StringBuilder result = new StringBuilder();

    for (int i = 0; i < input.Length; i++)
    {
        char encodedChar = (char)(input[i] ^ key[i % key.Length]);
        result.Append(encodedChar);
    }

    return result.ToString();
}

string task6(string str)
{
    StringBuilder sb = new StringBuilder(str);

    if (str.Length>20)
    {
        sb = new StringBuilder(str.Substring(0, 20));
    }
    else
    {
        for (int i = str.Length-1; i < 20; i++)
        {
            sb.Append('*');
        }
    }

    return sb.ToString();
}

//Console.WriteLine(task6("abcd"));

string extractSentences(string text, string subStr)
{
    string[] sentance = text.Split('.');

    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < sentance.Length; i++)
    {
        if (sentance[i].Contains(subStr))
        {
            sb.Append(sentance[i]);
            sb.Append(".");
        }
    }

    return sb.ToString();
}

//Console.WriteLine(extractSentences("The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.", "in"));

string reverseSentence(string text)
{
    string[] words = text.Split(' ');

    StringBuilder stringBuilder = new StringBuilder();

    for (int i = 0; i < words.Length; i++)
    {
        stringBuilder.Append(words[words.Length - 1 - i]);
        stringBuilder.Append(" ");
    }

    return stringBuilder.ToString();
}

//Console.WriteLine(reverseSentence("C# is not C++, not PHP and not Delphi!"));

string getSeriesOfLetters(string input)
{
    StringBuilder sb = new StringBuilder();
    char temp = input[0];
    sb.Append(temp);

    for(int i = 1; i < input.Length; i++ )
    {
        if (temp != input[i])
        {
            temp = input[i];
            sb.Append(temp);
        }
    }

    return sb.ToString();
}

//Console.WriteLine(getSeriesOfLetters("aaaaabbbbbcdddeeeedssaa"));

const int COUNT_OF_LETTERS = 26;
int[] alphabet = new int[COUNT_OF_LETTERS]; // 0 is for a, 1 is for b ...

int[] getLetterCount(string str)
{
    for (int i = 0; i < str.Length; i++)
    {
        alphabet[(int)str[i]-(int)'a']++;
    }

    return alphabet;
}

void printLettersCount()
{
    for (int i = 0; i < COUNT_OF_LETTERS; i++)
    {
        Console.WriteLine("{0} - {1}", (char)(i + (int)'a'), alphabet[i]);
    }
}

//getLetterCount("aaaaabbbbbcdddeeeedssaa");
//printLettersCount();

Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
//Match m = emailregex.Match("desi3gancheva@gmail.com");

void printEmails(string input)
{
    string[] emails = input.Split(' ');
    
    for (int i = 0; i < emails.Length; i++ )
    {
        Match m = emailregex.Match(emails[i]);
        
        if(m.Success)
        {
            Console.WriteLine(emails[i]);
        }
    }
}

//printEmails("desi3gan4eva@gmail.com jsjfro ivanivanov@abv.bg rfsejkjkr patetoala@gmail.com ksfskd");

string replaceTags(string input)
{
    string result = input.Replace("<a href", "[URL]");
    result = result.Replace("</a>", "[/URL]");

    return result;
}

//Console.WriteLine(replaceTags("<p>Please visit <a href=\"http://academy.telerik. com\">our " +
//    "site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a>" +
//    " to discuss the courses.</p>"));