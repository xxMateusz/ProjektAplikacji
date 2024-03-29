﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Projekt.Commands
{
    class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        private ICommand? resultCommand;

        public RelayCommand(Action<object> execute)
            :this(execute,null)
        {
         
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
_execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        public RelayCommand(ICommand? resultCommand)
        {
            this.resultCommand = resultCommand;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }


        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;

            }
        }

        private void CommandManager_RequerySuggested(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

      

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
