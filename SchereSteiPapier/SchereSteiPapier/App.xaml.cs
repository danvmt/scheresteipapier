using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SchereSteiPapier
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            AppContext.Statistics = new Statistics();

            var tabs = new TabbedPage();

            var tab1 = new NavigationPage(new MainPage());
            tab1.Title = "Game";
            

            var statisticsPage = new StatisticsPage();
            statisticsPage.BindingContext = AppContext.Statistics;
            var tab2 = new NavigationPage(statisticsPage);
            tab2.Title = "Statistics";

            tabs.Children.Add(tab1);
            tabs.Children.Add(tab2);

            tabs.BackgroundColor = Color.Gray;
            

            MainPage = tabs;
		}

		protected override void OnStart ()
		{
            // Handle when your app starts            
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
