namespace MajorBeat.ViewModels;

public class MusicianRegisterViewModel : ContentView
{
	public MusicianRegisterViewModel()
	{
		Content = new VerticalStackLayout
		{
			Children = {
				new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}