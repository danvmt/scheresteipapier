using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SchereSteiPapier
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectionPage : ContentPage
	{
        public SelectionPage ()
		{
			InitializeComponent ();
            Title = "Select your move";

            NavigationPage.SetHasNavigationBar(this, false);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
            };
        }

        void OnRockClicked(object sender, EventArgs e)
        {
            Console.WriteLine("rock clicked");
            AppContext.Statistics.Rock++;
            AppContext.Game.PlayGame(Choice.Rock);
            Showresult();
        }

        void OnPaperClicked(object sender, EventArgs e)
        {
            Console.WriteLine("paper clicked");
            AppContext.Statistics.Paper++;
            AppContext.Game.PlayGame(Choice.Paper);
            Showresult();
        }

        void OnScissorsClicked(object sender, EventArgs e)
        {
            Console.WriteLine("scissors clicked");
            AppContext.Statistics.Scissors++;
            AppContext.Game.PlayGame(Choice.Scissors);
            Showresult();
        }

        async void Showresult()
        {
            var resultPage = new ResultPage();

            await Navigation.PushAsync(resultPage);
        }
    }
}