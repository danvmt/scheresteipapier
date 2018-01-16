using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchereSteiPapier
{
    public class Statistics : INotifyPropertyChanged
    {
        private int rock;
        public int Rock
        {
            get { return rock; }
            set {
                rock = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Rock"));
            }
        }

        private int paper;
        public int Paper
        {
            get { return paper; }
            set {
                paper = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Paper"));
            }
        }

        private int scissors;
        public int Scissors
        {
            get { return scissors; }
            set {
                scissors = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Scissors"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
