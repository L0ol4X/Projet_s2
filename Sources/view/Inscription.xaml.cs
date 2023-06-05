using Modele;
using SaveMgr;

namespace app;

public partial class Inscription : ContentPage
{

    public ApplicationManager mgr = (Microsoft.Maui.Controls.Application.Current as App).Manager;
    public Account First { get; set; } = new Account();

    public string SecondPassword { get; set; }  


    public Inscription()
	{
		InitializeComponent();
	    BindingContext = this;
	}

    private void Cancel_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void Valider_Clicked(object sender, EventArgs e)
    {
        Account to_add_if_valid = new Account(First.UserName, First.Passwd);
        if (mgr.MyApp.Accounts.IsTheSame(to_add_if_valid.UserName, SecondPassword, to_add_if_valid.Passwd))
        {
            mgr.MyApp.Accounts.AddUser(to_add_if_valid);
            Navigation.PopModalAsync();
        }
        else
        {
            Navigation.PopModalAsync();
        }        
    }
}