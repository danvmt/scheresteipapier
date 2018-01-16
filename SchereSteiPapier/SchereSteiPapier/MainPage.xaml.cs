using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SchereSteiPapier
{

	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        async void OnStartClicked(object sender, EventArgs e)
        {
            Console.WriteLine("start clicked");

            AppContext.Game = new Game();

            await Navigation.PushAsync(new SelectionPage());

        }
    }
}
