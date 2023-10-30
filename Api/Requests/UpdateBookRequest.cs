namespace src.Requests;

public class UpdateBookRequest
{
    public int Id { get; set; }
    
    public string Title { get; set; }

    public int NumberOfPages { get; set; }

    public DateOnly DateOfPublish { get; set; }

    public int PublisherId { get; set; }
}