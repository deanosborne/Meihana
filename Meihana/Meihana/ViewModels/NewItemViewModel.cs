using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Meihana.Models;
using Xamarin.Forms;
using Meihana.Infrastructure;
namespace Meihana.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private Item _item;

        public Item Item
        {
            get => _item;
            set
            {
                SetProperty(ref _item, value);
            }
        }

        public NewItemViewModel()
        {
            var item = new Item
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Item name",
                Description = "This is an item description."
            };

            Item = item;
        }
    }
}