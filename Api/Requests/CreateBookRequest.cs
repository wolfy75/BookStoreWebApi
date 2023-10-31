namespace Api.Requests;

public class CreateBookRequest
{
    public string Title { get; set; }

    public short NumberOfPages { get; set; }

    public DateTime DateOfPublish { get; set; }

    
    public List<int> AuthorIds { get; set; }
    
    public int PublisherId { get; set; }
}