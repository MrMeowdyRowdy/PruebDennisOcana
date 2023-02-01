using PruebDennisOcana.Views;

namespace PruebDennisOcana;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ImageList), typeof(ImageList));
        Routing.RegisterRoute(nameof(AddUpdateImage), typeof(AddUpdateImage));
    }
	
}
