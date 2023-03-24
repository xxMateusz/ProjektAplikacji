using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Projekt.Commands;
using System.Windows;

namespace Projekt.ViewModels
{
  public  class MainViewModel :INotifyPropertyChanged
    {
        //        private string _screenVal;

        //        public  ScreenVal
        //        {
        //            get { return _screenVal; }
        //            set {
        //        _screenVal = value; 
        //        OnPropertyChanged();
        //}
        //        }

        private string _screenVal;
        public MainViewModel() 
        {
            ScreenVal = "123";
            AddNumberCommand = new RelayCommand(AddNumber);
        }
        private void AddNumber (object obj)
        {
            MessageBox.Show(obj as string);
        }
        public ICommand AddNumberCommand { get; set; }

        public string ScreenVal
        {
            get { return _screenVal; }
            set { _screenVal = value;
                OnPropertyChanged();
            }
        }
     
    public event PropertyChangedEventHandler
            PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
