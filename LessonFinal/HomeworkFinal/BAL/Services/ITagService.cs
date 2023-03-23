using Contracts;

public interface ITagService
{
    Task<Tag> GetTagByIdAsync(int id);
    Task<IEnumerable<Tag>> GetAllTagsAsync();
    Task AddTagAsync(Tag tag);
    Task UpdateTagAsync(Tag tag);
    Task DeleteTagAsync(Tag tag);
    Task<bool> TagExistsAsync(int tagId);
}
