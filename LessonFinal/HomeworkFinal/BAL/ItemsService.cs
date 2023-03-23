using BAL.Interfaces;
using BAL.Services;
using Contracts;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Services
{

    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IRepository<Tag> _tagRepository;

        public ItemService(IRepository<Item> itemRepository, IRepository<Tag> tagRepository)
        {
            _itemRepository = itemRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _itemRepository.GetAllAsync();
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _itemRepository.GetByIdAsync(id);
        }

        public async Task<Item> CreateItemAsync(Item item)
        {
            await _itemRepository.AddAsync(item);
            await _itemRepository.SaveChangesAsync();
            return item;
        }

        public async Task<Item> UpdateItemAsync(int id, Item item)
        {
            if (id != item.ItemID)
            {
                throw new ArgumentException("Item ID mismatch");
            }

            _itemRepository.UpdateAsync(item);
            await _itemRepository.SaveChangesAsync();
            return item;
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var item = await _itemRepository.GetByIdAsync(id);
            if (item == null)
            {
                return false;
            }

            _itemRepository.Remove(item);
            await _itemRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            //return await _tagRepository.GetAllAsync();
            var tags = await _tagRepository.GetAllAsync();
            return tags;
        }

    }
}
