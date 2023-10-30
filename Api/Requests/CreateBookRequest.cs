namespace Api.Requests;

public class CreateBookRequest
{
    public string Title { get; set; }

    public int NumberOfPages { get; set; }

    public DateOnly DateOfPublish { get; set; }

    public int PublisherId { get; set; }
}