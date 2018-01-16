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
	public partial class ResultPage : ContentPage
	{
        Dictionary<Choice, string> choiceImages = new Dictionary<Choice, string>
        {
            { Choice.Rock, "rock.jpg" },
            { Choice.Paper, "paper.jpg" },
            { Choice.Scissors, "scissors.jpg" }
        };

        public ResultPage()
		{
            InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            UpdateUI();

            SpeakText();
    }

    private void UpdateUI()
        {
            if (AppContext.Game.LastResult == Result.Draw)
            {
                Console.WriteLine("draw");
                resultLabel.Text = "Draw";
            }
            else if (AppContext.Game.LastResult == Result.PlayerWins)
            {
                Console.WriteLine("user won");
                resultLabel.Text = "Win";
            }
            else if (AppContext.Game.LastResult == Result.RandomWins)
            {
                Console.WriteLine("user lost");
                resultLabel.Text = "Defeat";
            }
        }

        private void SpeakText()
        {
            string text;
            string choice = AppContext.Game.LastPlayerChoice.ToString();
            string result = AppContext.Game.LastResult.ToString();

            int count = GetCount();

            if (count == 1)
            {
                text = result + "! You selected " + choice + " once!";
            }
            else if (count == 2)
            {
                text = result + "! You selected " + choice + " twice!";
            }
            else
            {
                text = result + "! You selected " + choice + " " + count + " times!";
            }

            var dependencyService = DependencyService.Get<ITextToSpeech>();
            if (dependencyService != null)
            {
                dependencyService.Speak(text);
            }
        }

        private static int GetCount()
        {
            int count = 0;

            if (AppContext.Game.LastPlayerChoice == Choice.Rock)
            {
                count = AppContext.Statistics.Rock;
            }
            else if (AppContext.Game.LastPlayerChoice == Choice.Paper)
            {
                count = AppContext.Statistics.Paper;
            }
            else if (AppContext.Game.LastPlayerChoice == Choice.Scissors)
            {
                count = AppContext.Statistics.Scissors;
            }

            return count;
        }

        async void OnStartNewClicked(object sender, EventArgs e)
        {
            Console.WriteLine("start new clicked");
            await Navigation.PopAsync();

        }

        async void OnHomeClicked(object sender, EventArgs e)
        {
            Console.WriteLine("home clicked");
            await Navigation.PopToRootAsync();

        }

    }
}