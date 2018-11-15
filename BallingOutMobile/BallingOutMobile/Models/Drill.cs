using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BallingOutMobile.Models
{
    public class Drill : INotifyPropertyChanged
    {
        private bool isCompleted;
        public bool IsCompleted {
            get { return isCompleted; }
            set {
                isCompleted = value;
                OnPropertyChanged("IsCompleted");
            }
        }

        public int SecondsForExercise { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoReference { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
