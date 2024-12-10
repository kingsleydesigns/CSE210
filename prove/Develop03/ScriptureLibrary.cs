public class ScriptureLibrary {
    private List<Scripture> _scriptures = new List<Scripture>();

    public void AddScripture(Scripture scripture) {
        _scriptures.Add(scripture);
    }

    // Getter to access the list of scriptures
    public List<Scripture> GetAllScriptures() {
        return _scriptures;
    }

    // Fetch a random scripture
    public Scripture GetRandomScripture() {
        if (_scriptures.Count == 0) {
            throw new InvalidOperationException("No scriptures in the library.");
        }
        Random random = new Random();
        return _scriptures[random.Next(_scriptures.Count)];
    }
}
