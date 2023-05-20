using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NotaGUI.MVVM
{
    public class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute = x => true; 

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object? parameter)
        {
            return this._canExecute(parameter) == null || this._canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            this._execute(parameter);
        }
    }
}
