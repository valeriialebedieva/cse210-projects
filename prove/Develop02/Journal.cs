class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter sw = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Saving the entry in CSV format
                sw.WriteLine($"\"{entry._date}\",\"{entry._promptText}\",\"{entry._entryText}\"");
            }
        }
        Console.WriteLine("Journal saved to file.");
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                // Parsing CSV format
                string[] parts = line.Split(new[] { "\",\"" }, StringSplitOptions.None);
                if (parts.Length == 3)
                {
                    string date = parts[0].Trim('"');
                    string prompt = parts[1].Trim('"');
                    string entryText = parts[2].Trim('"');
                    Entry entry = new Entry(date, prompt, entryText);
                    _entries.Add(entry);
                }
            }
            Console.WriteLine("Journal loaded from file.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
