using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NWindViewModel
{
    internal class UserCommand:ICommand
    {
        private Action<Object> action;
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null) action(parameter);
            else action(0);
        }
        public UserCommand(Action<Object> action)
        {
            this.action = action;
        }
    }
}
