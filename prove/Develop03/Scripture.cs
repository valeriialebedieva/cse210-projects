using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (var word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<Word> wordsToHide = _words.FindAll(w => !w.IsHidden());
        for (int i = 0; i < numberToHide && wordsToHide.Count > 0; i++)
        {
            int randomIndex = random.Next(wordsToHide.Count);
            wordsToHide[randomIndex].Hide();
            wordsToHide.RemoveAt(randomIndex);
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = _reference.GetDisplayText() + " ";
        foreach (var word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return scriptureText.Trim();
    }

    public bool IsCompletelyHidden()
    {
        return _words.TrueForAll(w => w.IsHidden());
    }
}
