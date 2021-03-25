using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meihana.Models;

namespace Meihana.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Improving Maori health through clinical assessment", Description="Research resource", url="https://www.researchgate.net/publication/241393435_Meihana_Model_A_Clinical_Assessment_Framework" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Maori Indigenous Health Framework in action", Description="Research resource", url="https://www.nzma.org.nz/journal-articles/maori-indigenous-health-framework-in-action-addressing-ethnic-disparities-in-healthcare" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "The Meihana Model: Engaging effectively with Maori clients", Description="Research resourse", url="https://www.organisationalpsychology.nz/_content/14_06_2016_The_Meihana_Model_Engaging_Effectively_with_Maori_Clients.pdf" },
            };
        }


        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}