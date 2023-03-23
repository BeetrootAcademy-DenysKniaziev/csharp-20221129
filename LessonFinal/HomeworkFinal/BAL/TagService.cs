using Contracts;
using DAL.Interfaces;
using DAL.Repositories;

public class TagService : ITagService
{
    private readonly IRepository<Tag> _tagRepository;

    public TagService(IRepository<Tag> tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Tag> GetTagByIdAsync(int id)
    {
        return await _tagRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Tag>> GetAllTagsAsync()
    {
        return await _tagRepository.GetAllAsync();
    }

    public async Task AddTagAsync(Tag tag)
    {
        await _tagRepository.AddAsync(tag);
    }

    public async Task UpdateTagAsync(Tag tag)
    {
        await _tagRepository.UpdateAsync(tag);
    }

    public async Task DeleteTagAsync(Tag tag)
    {
        _tagRepository.Remove(tag);
    }

    public async Task<bool> TagExistsAsync(int tagId)
    {
        return await _tagRepository.GetAllAsync() != null;
    }
}