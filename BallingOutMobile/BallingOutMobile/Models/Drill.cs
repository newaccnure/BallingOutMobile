using System.ComponentModel;

namespace BallingOutMobile.Models
{
    public class Drill : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool IsCompleted { get; set; }

        public int SecondsForExercise { get; set; }

        public int DifficultyId { get; set; }

        public int DrillId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string VideoReference { get; set; }

    }
}
