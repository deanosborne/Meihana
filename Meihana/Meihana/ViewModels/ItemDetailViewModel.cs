using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Meihana.Models;
using Xamarin.Forms;
using Meihana.Infrastructure;
using System.Windows.Input;

namespace Meihana.ViewModels
{
 
    public class ItemDetailViewModel : BaseViewModel
    {
        private Item _item;

        public Item Item
        {
            get => _item;
            private set
            {
                SetProperty(ref _item, value);
                Title = _item?.Text;
            }
        }

        public Command LoadItemCommand { get; set; }

        public ItemDetailViewModel()
        {
            var item = new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Sample Item",
                Description = "This is an item description.",
                url = "Sample URL"
            };

            Item = item;

            LoadItemCommand = new Command<string>(async (itemId) => await LoadItem(itemId));
        }

        private async Task LoadItem(string itemId)
        {
            Item = await DataStore.GetItemAsync(itemId);
        }

        public ICommand ClickCommand => new Command<string>((url) =>
        {
            Device.OpenUri(new System.Uri(url));
        });
    }
}
