public class Video
{
    public string _title;
    public string _author;
    public int _length; // Length in seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Method to get the number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Method to display all comments
    public void DisplayComments()
    {
        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment._name}: {comment._text}");
        }
    }
}