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
	public partial class StatisticsPage : ContentPage
	{
		public StatisticsPage ()
		{

            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            MessagingCenter.Subscribe<Game>(this, "lastChoice", UpdateLabel);

            var list = new List<int> { 1, 2, 3, 4, 5, 6 };

            //Binding example code
            //BindingContext = AppContext.Statistics;
            //rockLabel.SetBinding(Label.TextProperty, "Rock");
            //paperLabel.SetBinding(Label.TextProperty, "Paper");
            //scissorsLabel.SetBinding(Label.TextProperty, "Scissors");

        }

        private void UpdateLabel(object sender)
        {
            var theGame = sender as Game;
            if (theGame != null)
            {
                string msg = theGame.LastPlayerChoice.ToString();
                selectLabel.Text = msg;
            }
        }
    }
}