using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication3.Common
{
    public class Command<T> : ICommand
    {
        readonly Action<object> _action;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action(parameter);
            }
        }

        public Command(Action<object> action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;
    }

    public class Command : ICommand
    {
        readonly Action _action;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
            {
                _action();
            }
        }

        public Command(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;
    }
}
