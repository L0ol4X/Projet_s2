using SaveMgr;

namespace app;

public partial class Head : ContentView
{
    public ApplicationManager mgr = (Application.Current as App).Manager;

	public Head()
	{
		InitializeComponent();
	}

    void ImageButton_Clicked(System.Object sender, System.EventArgs e)
    {
        (App.Current.MainPage as Shell).FlyoutIsPresented ^= true;
    }

    async void Inscription_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushModalAsync(new Inscription());
    }

    async void Connexion_Clicked(System.Object sender, System.EventArgs e)
    {        
        if (mgr.MyApp.IsConnected)
        {
            await Navigation.PushAsync(new Connected());
        }
        else
        {
            await Navigation.PushModalAsync(new ConnexionPage());
        }
            
    }

}