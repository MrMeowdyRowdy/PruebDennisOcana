using PruebDennisOcana.ViewModels;

namespace PruebDennisOcana;

public partial class MainPage : ContentPage
{
    private ImageListModel viewMode;
    public MainPage(ImageListModel viewModel)
    {
        InitializeComponent();
        viewMode = viewModel;
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewMode.GetPhotoListCommand.Execute(null);
    }
}

