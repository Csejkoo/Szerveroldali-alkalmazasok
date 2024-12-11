using Demo.ApiClient1;
using Demo.ApiClient1.Models.ApiModels;

namespace Demo.MauiApiConsumer.Pages;

public partial class AddEditProduct : ContentPage
{
    private readonly DemoApiClientService _apiClient;
    private Product _product;

    public AddEditProduct(DemoApiClientService apiClient, Product product)
    {
        InitializeComponent();

        _apiClient = apiClient;
        _product = product;
        LoadProductDetails();
    }

    private void LoadProductDetails()
    {
        if (_product is not null)
        {
            txtProductCode.Text = _product.ProductDescription;
            txtProductName.Text = _product.ProductName;
            txtPrice.Text = _product.ProductPrice.ToString("0.00");
        }
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        if (_product is null)
        {
            // Add a new product

            await _apiClient.SaveProduct(new Product
            {
                ProductDescription = txtProductCode.Text,
                ProductName = txtProductName.Text,
                ProductPrice = decimal.Parse(txtPrice.Text)
            });
        }
        else
        {
            //Update an existing product

            await _apiClient.UpdateProduct(new Product
            {
                id = _product.id,
                ProductDescription = txtProductCode.Text,
                ProductName = txtProductName.Text,
                ProductPrice = decimal.Parse(txtPrice.Text)
            });
        }

        await Navigation.PopModalAsync();
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}