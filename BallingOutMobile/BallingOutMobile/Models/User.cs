﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BallingOutMobile.Models
{
    public class User : INotifyPropertyChanged
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public List<int> PracticeDays { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
