using System;
using System.ComponentModel;
using Xamarin.Forms;
using Meihana.ViewModels;
using System.Windows.Input;
using Xamarin.Essentials;
using System.Diagnostics;

namespace Meihana.Views
{
    [DesignTimeVisible(false)]
    [QueryProperty(nameof(ItemId), "itemid")]
    public partial class ItemDetailPage : ContentPage
    {
        private readonly ItemDetailViewModel _viewModel;
        private string _itemId;

        public string ItemId
        {
            get => _itemId;
            set => _itemId = Uri.UnescapeDataString(value);
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemDetailViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.LoadItemCommand.Execute(ItemId);
        }

    }
}