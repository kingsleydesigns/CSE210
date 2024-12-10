public class Word {
    private string _text;
    private bool _isHidden;

    public Word(string text) {
        _text = text;
        _isHidden = false; // Words start as visible
    }

    // Hides the word
    public void Hide() {
        _isHidden = true;
    }

    // Shows the word
    public void Show() {
        _isHidden = false;
    }

    // Checks if the word is hidden
    public bool IsHidden() {
        return _isHidden;
    }

    // Returns the display text based on hidden status
    public string GetDisplayText() {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}