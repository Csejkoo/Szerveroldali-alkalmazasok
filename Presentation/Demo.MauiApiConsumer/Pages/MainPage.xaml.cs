using Demo.ApiClient1;
using Demo.ApiClient1.Models.ApiModels;
using Demo.MauiApiConsumer.Pages;

namespace Demo.MauiApiConsumer
{
    public partial class MainPage : ContentPage
    {


        private readonly DemoApiClientService _apiClient;

        public MainPage(DemoApiClientService apiClient)
        {
            InitializeComponent();

            _apiClient = apiClient;
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddEditProduct(_apiClient, null));
        }

        private async void btnShowProducts_Clicked(object sender, EventArgs e)
        {
            await LoadProducts();
        }

        private async void productListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var product = (Product)e.Item;
            var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");

            switch (action)
            {
                case "Edit":
                    await Navigation.PushModalAsync(new AddEditProduct(_apiClient, product));
                    break;
                case "Delete":
                    await _apiClient.DeleteProduct(product.id);
                    await LoadProducts();
                    break;
            }
        }

        private async Task LoadProducts()
        {
            var products = await _apiClient.GetProducts();
            productListView.ItemsSource = products;
        }
    }
}