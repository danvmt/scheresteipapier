using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;


namespace SchereSteiPapier
{
    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    public enum Result
    {
        PlayerWins,
        RandomWins,
        Draw
    }

    public class Game
    {
        public Choice LastRandomChoice { get; set; }
        public Choice LastPlayerChoice { get; set; }
        public Result LastResult { get; set; }

        public Result PlayGame(Choice choice)
        {
            Random rnd = new Random();
            int i = rnd.Next(0, 3);

            LastRandomChoice = (Choice)i;
            LastPlayerChoice = choice;

            //string msg = LastPlayerChoice.ToString();
            MessagingCenter.Send<Game>(this, "lastChoice");


            Console.WriteLine("random: " + LastRandomChoice);
            Console.WriteLine("user: " + LastPlayerChoice);


            if (LastPlayerChoice == LastRandomChoice)
            {
                LastResult = Result.Draw;
            }
            else if (
                (choice == Choice.Paper && LastRandomChoice == Choice.Rock) ||
                (choice == Choice.Scissors && LastRandomChoice == Choice.Paper) ||
                (choice == Choice.Rock && LastRandomChoice == Choice.Scissors)
            )
            {
                LastResult = Result.PlayerWins;
            }
            else
            {
                LastResult = Result.RandomWins;
            }

            return LastResult;
        }
    }
}
