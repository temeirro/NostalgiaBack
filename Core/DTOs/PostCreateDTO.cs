using Core.DTOs;

public class PostCreateDTO
{
    public string Title { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public DateTime PostedOn { get; set; }
    public DateTime Modified { get; set; }

    public int CategoryId { get; set; }

    // List of tag IDs associated with the post
    public List<int> TagIds { get; set; }

    // Navigation property
    public List<PostImageDTO> PostImages { get; set; }
}
