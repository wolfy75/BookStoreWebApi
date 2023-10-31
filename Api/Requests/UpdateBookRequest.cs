namespace Api.Requests;

public class UpdateBookRequest
{
    public int Id { get; set; }
    
    public string Title { get; set; }

    public short NumberOfPages { get; set; }
    
    public DateTime DateOfPublish { get; set; }
    
    public int PublisherId { get; set; }

    public List<int> AuthorIds { get; set; }
}