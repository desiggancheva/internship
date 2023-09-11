// See https://aka.ms/new-console-template for more information

void concatenateTextFiles(string[] filePaths, string outputPath)
{
    using (StreamWriter writer = new StreamWriter(outputPath))
    {
        foreach (string filePath in filePaths)
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                writer.Write(content);
            }
            else
            {
                throw new FileNotFoundException($"File not found {filePath}");
            }
        }
    }

    Console.WriteLine("Concatenation completed.");
}

void writeLineNumbers(string filePath, string outputPath)
{
    using (StreamReader reader = File.OpenText(filePath))
    {
        string line;
        int countOfLines = 1;

        while ((line = reader.ReadLine()) is not null)
        {
            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                writer.WriteLine(countOfLines);
                writer.WriteLine(line);
            }
        }
    }

}

void CompareTextFiles(string filePath1, string filePath2)
{
    int countOfSameLines = 0;
    int countOfDifferentLines = 0;

    using (StreamReader reader1 = new StreamReader(filePath1))
    using (StreamReader reader2 = new StreamReader(filePath2))
    {
        while (!reader1.EndOfStream && !reader2.EndOfStream)
        {
            string line1 = reader1.ReadLine();
            string line2 = reader2.ReadLine();

            if (line1 == line2)
            {
                countOfSameLines++;
            }
            else
            {
                countOfDifferentLines++;
            }
        }
    }

    Console.WriteLine("Count of lines that are the same: " + sameLines);
    Console.WriteLine("Count of lines that are different: " + differentLines);
}

void saveSortedNames(string filePath, string outputPath)
{
    List<string> lines = new List<string>();
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            lines.Add(line);
        }
    }

    lines.Sort();

    using (StreamWriter writer = new StreamWriter(outputPath))
    {
        foreach (string line in lines)
        {
            writer.WriteLine(line);
        }
    }

}

void replaceSubstringInFile(string filePath, string targetSubstring, string replacementSubstring)
{
    string tempFilePath = Path.GetTempFileName();

    using (StreamReader reader = new StreamReader(filePath))
    using (StreamWriter writer = new StreamWriter(tempFilePath))
    {
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            line = line.Replace(targetSubstring, replacementSubstring);
            writer.WriteLine(line);
        }
    }

    File.Delete(filePath);
    File.Move(tempFilePath, filePath);
}

void deleteOddLines(string filePath)
{
    string [] lines;
   
    using (StreamReader reader = new StreamReader(filePath))
    {
        lines = reader.ReadToEnd().Split(Environment.NewLine);
        reader.Close();

    }

    using (StreamWriter writer = new StreamWriter(filePath))
    {
       
        for (int i = 0; i < lines.Length; i++ )
        {
            if (i % 2 == 0)
            {
                writer.WriteLine(lines[i]);
            }
        }

        writer.Close();
    }
}

void removeWordsWithPrefix(string filePath, string prefix)
{
    string[] lines;

    using (StreamReader reader = new StreamReader(filePath))
    {
        lines = reader.ReadToEnd().Split(' ');
        reader.Close();
    }

    using (StreamWriter writer = new StreamWriter(filePath))
    {
        for (int i = 0; i < lines.Length; ++i)
        {
            if (!lines[i].StartsWith(prefix))
            {
                writer.WriteLine(lines[i]);
            }
        }
    }
}

static string[] ReadFromFile(string filePath)
{
    string[] lines = null;

    try
    {
        using (StreamReader reader = new StreamReader(filePath))
        {
            lines = reader.ReadToEnd().Split(' ');
            reader.Close();
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (FileNotFoundException ex)
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

    return lines;
}

void removeWordsWithPrefixWithoutReaderInBody(string filePath, string prefix)
{
    string[] lines = ReadFromFile(filePath);

    using (StreamWriter writer = new StreamWriter(filePath))
    {
        for (int i = 0; i < lines.Length; ++i)
        {
            if (!lines[i].StartsWith(prefix))
            {
                writer.WriteLine(lines[i]);
            }
        }
    }
}