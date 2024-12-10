public class Scripture {
    private Reference _reference;

    private string _text;
    private List<Word> _words = new List<Word>();

     public Scripture(Reference reference, string text) {
        _reference = reference;
        _text = text;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

   public Scripture(ScriptureLibrary library) {
        var randomScripture = library.GetRandomScripture();
        _reference = randomScripture.GetReference(); // Using the getter
        _text = randomScripture.GetText();           // Using the getter
        _words = randomScripture.GetWords();         // Using the getter
    }

    //Getter methods
    public Reference GetReference() {
        return _reference;
    }

    public string GetText() {
        return _text;
    }

    public List<Word> GetWords() {
        // Deep copy to ensure immutability
        return _words.Select(word => new Word(word.GetDisplayText())).ToList();
    }


    public void HideRandomWords(int count) {
        Random random = new Random();
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        for (int i = 0; i < count && visibleWords.Any(); i++) {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText() {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}\n{scriptureText}";
    }

    public bool IsCompletelyHidden() {
        return _words.All(word => word.IsHidden());
    }
}
