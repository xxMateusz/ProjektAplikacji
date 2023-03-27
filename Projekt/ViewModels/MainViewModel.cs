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
using System.Data;

namespace Projekt.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
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
        private DataTable _dataTable = new DataTable();
        private string _screenVal;
       
        private List<string> _avaibleOperations = new List<string> { "+", "-", "/", "*" };
        public MainViewModel() 
        {
            ScreenVal = "0";
            AddNumberCommand = new RelayCommand(AddNumber);
            AddOperationCommand = new RelayCommand(AddOperation);
            ClearScreenCommand = new RelayCommand(ClearScreen);
            ResultCommand = new RelayCommand(Result);
        }

        private void Result(object obj)
        {
          var result  = _dataTable.Compute(ScreenVal, " ");
            ScreenVal = result.ToString();

        }

        private void ClearScreen(object obj)
        {
            ScreenVal = "0";
        }
        
        private void AddOperation(object obj)
        {
            var operation = obj as string;
            ScreenVal += operation;


        }

        private void AddNumber (object obj)
        {
            var number = obj as string;
            if (ScreenVal == "0" && number != ",")
                ScreenVal = string.Empty;

            else if (number == "," && _avaibleOperations.Contains(ScreenVal.Substring(ScreenVal.Length - 1)))
                number = "0";

            ScreenVal += number;
        }
        public ICommand AddNumberCommand { get; set; }
        public ICommand AddOperationCommand { get; set; }
        public ICommand ClearScreenCommand { get; set; }
        public ICommand ResultCommand { get; set; }
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
