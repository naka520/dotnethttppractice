public class Todo
{
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }

    public Todo(int UserId, int Id, string Title, bool Completed)
    {
        this.UserId = UserId;
        this.Id = Id;
        this.Title = Title;
        this.Completed = Completed;
    }

    public override string ToString()
    {
        return $"Todo {{ UserId = {UserId}, Id = {Id}, Title = {Title}, Completed = {Completed} }}";
    }
}