namespace Api.Responses;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public int NumberOfPages { get; set; }

    public DateOnly DateOfPublish { get; set; }

    public Publisher Publisher { get; set; }
}