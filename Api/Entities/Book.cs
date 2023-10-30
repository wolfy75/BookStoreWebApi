namespace Api.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public short NumberOfPages { get; set; }

    public DateTime DateOfPublish { get; set; }

    public int PublisherId { get; set; }

    public virtual Publisher Publisher { get; set; }

    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
