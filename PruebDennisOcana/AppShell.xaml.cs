using PruebDennisOcana.Views;

namespace PruebDennisOcana;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(Views.ImageList), typeof(ImageList));
        Routing.RegisterRoute(nameof(Views.AddUpdateImage), typeof(AddUpdateImage));
    }
	
}
