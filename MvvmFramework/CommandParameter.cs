using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmFramework
{
    public class CommandParameter : Request
    {
       private Action<object> CommandAction;

       public CommandParameter(Action<object> commandAction, bool canExecute = true)
        {
            CommandAction = commandAction;
            this.canExecute = canExecute;
        }

        public override void Execute(object parameter)
        {
            CommandAction?.Invoke(parameter);
        }
    }
}
