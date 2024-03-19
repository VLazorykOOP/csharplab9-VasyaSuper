using System.Collections;
using System.Threading.Tasks;

Console.WriteLine("Lab#9  or  Lab#10");

Task task1 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(1000);
    Console.WriteLine("Початок виконання завдання 1");

    task1 task11 = new task1("C:\\University\\VI_semester\\CSharp\\lab_9\\task1\\read.txt", "C:\\University\\VI_semester\\CSharp\\lab_9\\task1\\output.txt");
    task11.ProcessText();

    Console.WriteLine("Завершення виконання завдання 1");
});

Task task2 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(3000);
    Console.WriteLine("\nПочаток виконання завдання 2");

    task2 task21 = new task2("C:\\University\\VI_semester\\CSharp\\lab_9\\task2\\read.txt");
    task21.ProcessText();

    Console.WriteLine("\nЗавершення виконання завдання 2");
});

Task task3 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(5000);
    Console.WriteLine("\nПочаток виконання завдання 3");

    task31 task331 = new task31("C:\\University\\VI_semester\\CSharp\\lab_9\\task3\\read_1.txt", "C:\\University\\VI_semester\\CSharp\\lab_9\\task3\\output_1.txt");
    task331.ProcessText();

    task32 task332 = new task32("C:\\University\\VI_semester\\CSharp\\lab_9\\task3\\read_2.txt");
    task332.ProcessText();

    Console.WriteLine("\nЗавершення виконання завдання 3");
});

Task task4 = Task.Run(() =>
{
    System.Threading.Thread.Sleep(7000);
    Console.WriteLine("\nПочаток виконання завдання 4");

    MusicCatalog catalog = new MusicCatalog();

    Console.WriteLine("\n\nAdding disks to the catalog");
    catalog.AddCD("CD 1");
    catalog.AddCD("CD 2");

    Console.WriteLine("\n\nAdding songs to disk");
    catalog.AddSong("CD 1", "performer1", "Song1");
    catalog.AddSong("CD 1", "performer2", "Song2");

    catalog.AddSong("CD 2", "performer3", "Song3");
    catalog.AddSong("CD 2", "performer1", "Song4");

    Console.WriteLine("\n\nShowing the catalog");
    Console.WriteLine();
    catalog.ShowCatalog();

    catalog.SearchByArtist("performer3");

    Console.WriteLine("\n\nRemoving songs and disks");
    catalog.DeleteSong("CD 1", "performer2", "Song2");
    catalog.DeleteCD("CD 2");

    Console.WriteLine("\n\nShowing the catalog after removing");
    catalog.ShowCatalog();

    Console.WriteLine("\nЗавершення виконання завдання 4");
});

Task.WaitAll(task1, task2, task3, task4);
Console.WriteLine("Усi завдання завершено");


class task1
{
    private string readingFilePath;
    private string recordFilePath;

    public task1(string sourceFilePath, string targetFilePath)
    {
        this.readingFilePath = sourceFilePath;
        this.recordFilePath = targetFilePath;
    }

    public void ProcessText()
    {
        try
        {
            Stack stack = new Stack();

            using (StreamReader sr = new StreamReader(readingFilePath))
            using (StreamWriter sw = new StreamWriter(recordFilePath))
            {

                if (!File.Exists(recordFilePath))
                {
                    File.Create(recordFilePath).Close();
                }

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (string word in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    {
                        stack.Push(word);
                    }
                }

                while (stack.Count > 0)
                {
                    sw.Write($"{stack.Pop()} ");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

class task2
{
    private string readingFilePath;

    public task2(string sourceFilePath)
    {
        this.readingFilePath = sourceFilePath;
    }

    public void ProcessText()
    {
        try
        {
            Queue<char> nonDigitsQueue = new Queue<char>();

            Queue<char> digitsQueue = new Queue<char>();

            using (StreamReader sr = new StreamReader(readingFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (char c in line)
                    {
                        if (char.IsDigit(c))
                        {
                            digitsQueue.Enqueue(c);
                        }
                        else
                        {
                            nonDigitsQueue.Enqueue(c);
                        }
                    }
                }
            }

            Console.WriteLine("All non-numeric characters first: ");
            while (nonDigitsQueue.Count > 0)
            {
                Console.Write(nonDigitsQueue.Dequeue());
            }

            Console.WriteLine("\n\nNow all the numbers:");
            while (digitsQueue.Count > 0)
            {
                Console.Write(digitsQueue.Dequeue());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

class task31
{
    private string readingFilePath;
    private string recordFilePath;

    public task31(string sourceFilePath, string targetFilePath)
    {
        this.readingFilePath = sourceFilePath;
        this.recordFilePath = targetFilePath;
    }

    public void ProcessText()
    {
        try
        {
            ArrayList arrayList = new ArrayList();
            Stack stack = new Stack();

            using (StreamReader sr = new StreamReader(readingFilePath))
            using (StreamWriter sw = new StreamWriter(recordFilePath))
            {

                if (!File.Exists(recordFilePath))
                {
                    File.Create(recordFilePath).Close();
                }

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (string word in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                    {
                        arrayList.Add(word);
                    }
                }
                foreach (string item in ((IEnumerable)arrayList).Cast<object>().Reverse())
                {
                    sw.Write($"{item} ");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}

class task32
{
    private string readingFilePath;

    public task32(string sourceFilePath)
    {
        this.readingFilePath = sourceFilePath;
    }

    public void ProcessText()
    {
        try
        {
            ArrayList arrayListIsDigit = new ArrayList();

            ArrayList arrayListNotDigit = new ArrayList();

            using (StreamReader sr = new StreamReader(readingFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (char c in line)
                    {
                        if (char.IsDigit(c))
                        {
                            arrayListIsDigit.Add(c);
                        }
                        else
                        {
                            arrayListNotDigit.Add(c);
                        }
                    }
                }
            }

            ArrayList clonedListIsDigit = (ArrayList)arrayListIsDigit.Clone();
            ArrayList clonedListNotDigit = (ArrayList)arrayListNotDigit.Clone();

            ArrayList combinedList = new ArrayList();
            combinedList.AddRange(clonedListNotDigit);
            combinedList.AddRange(clonedListIsDigit);

            foreach (var item in combinedList)
            {
                Console.Write(item);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

}

public class MusicCatalog
{
    private Hashtable catalog = new Hashtable();

    public void AddCD(string CDName)
    {
        if (!catalog.ContainsKey(CDName))
        {
            catalog[CDName] = new ArrayList();
            Console.WriteLine($"'{CDName}' disk has been added to the catalogue. ");
        }
        else
        {
            Console.WriteLine($"'{CDName}' disc is already in the catalogue. ");
        }
    }

    public void DeleteCD(string CDName)
    {
        if (catalog.ContainsKey(CDName))
        {
            catalog.Remove(CDName);
            Console.WriteLine($"'{CDName}' disk has been deleted from the catalogue. ");
        }
        else
        {
            Console.WriteLine($"'{CDName}' disk was not found in the catalogue. ");
        }
    }

    public void AddSong(string CDName, string performer, string songName)
    {
        if (catalog.ContainsKey(CDName))
        {
            ArrayList songs = (ArrayList)catalog[CDName];
            songs.Add($"{performer} - {songName}");
            Console.WriteLine($"Song '{songName}' by {performer} added to the disk '{CDName}'. ");
        }
        else
        {
            Console.WriteLine($"Disk '{CDName}' not found in the catalog.");
        }
    }

    public void DeleteSong(string CDName, string performer, string songName)
    {
        if (catalog.ContainsKey(CDName))
        {
            ArrayList songs = (ArrayList)catalog[CDName];
            string songToRemove = $"{performer} - {songName}";

            if (songs.Contains(songToRemove))
            {
                songs.Remove(songToRemove);
                Console.WriteLine(
                    $"Song '{songName}' by {performer} removed from disk '{CDName}'."
                );
            }
            else
            {
                Console.WriteLine(
                    $"Song '{songName}' by {performer} not found in disk '{CDName}'."
                );
            }
        }
        else
        {
            Console.WriteLine($"Disk '{CDName}' not found in the catalog.");
        }
    }

    public void ShowCatalog()
    {
        Console.WriteLine("Music Catalog:");
        foreach (DictionaryEntry entry in catalog)
        {
            string CDName = (string)entry.Key;
            ArrayList songs = (ArrayList)entry.Value;

            Console.WriteLine($"Disk: {CDName}");
            Console.WriteLine("Songs:");
            foreach (string song in songs)
            {
                Console.WriteLine($"  {song}");
            }
            Console.WriteLine();
        }
    }

    public void SearchByArtist(string performer)
    {
        Console.WriteLine($"Search results for artist '{performer}':");
        foreach (DictionaryEntry entry in catalog)
        {
            ArrayList songs = (ArrayList)entry.Value;

            foreach (string song in songs)
            {
                if (song.Contains(performer))
                {
                    Console.WriteLine($"Disk: {entry.Key}, Song: {song}");
                }
            }
        }
    }
}



